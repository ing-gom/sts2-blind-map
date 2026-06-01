using System;
using System.Reflection;
using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Map;
using MegaCrit.Sts2.Core.Nodes.Screens.Map;
using MegaCrit.Sts2.Core.Runs;

namespace Sts2BlindMap;

/// <summary>
/// Repaints a map node with the game's generic "unknown" (?) sprite unless the node
/// is exempt. Exempt = the boss-adjacent rest ("fire before the boss"), fixed treasure
/// (relic) nodes, and the run's starting node. Boss / second-boss / Ancient-start nodes
/// are rendered by their own classes (<c>NBossMapPoint</c>, <c>NAncientMapPoint</c>) and
/// never reach this code, so they stay visible automatically.
///
/// Only the <see cref="TextureRect.Texture"/> of the node's icon/outline is swapped — the
/// underlying <see cref="MapPoint.PointType"/> and the room's actual contents are left
/// untouched, so this is a pure visual change with no gameplay/state/sync effect.
/// </summary>
internal static class BlindMapService
{
    // Resource paths mirror NNormalMapPoint.IconName("map_unknown") + IconPath/OutlinePath.
    // ImageHelper.GetImagePath prepends "res://images/".
    private const string UnknownIconPath =
        "res://images/atlases/ui_atlas.sprites/map/icons/map_unknown.tres";
    private const string UnknownOutlinePath =
        "res://images/atlases/compressed.sprites/map/map_unknown_outline.tres";

    private static readonly bool _disabled =
        System.Environment.GetEnvironmentVariable("STS2_BLIND_MAP_DISABLED") == "1";

    // PAST visited nodes (the trail behind you) are revealed for readability. Only the
    // unexplored path ahead — AND the current node — stay blinded. Flip to false to keep
    // even the past trail blinded (full ? map).
    private const bool RevealTraveled = true;

    /// <summary>
    /// Godot node meta flag set to <c>true</c> on a node while it is shown blinded (and
    /// <c>false</c> when revealed/exempt). Other mods that read <see cref="MapPoint.PointType"/>
    /// to overlay info (e.g. potion-drop badges) can honor this to avoid leaking the hidden
    /// room type. Loose coupling — no assembly reference required, key is a stable string.
    /// </summary>
    public const string BlindMetaKey = "Sts2BlindMap_Blinded";

    private static Texture2D? _unknownIcon;
    private static Texture2D? _unknownOutline;

    // _icon / _outline are private TextureRect fields on NNormalMapPoint (sts2.dll:151827/151831).
    // Resolved by name so the patch is robust regardless of Publicizer.
    private static FieldInfo? _iconField;
    private static FieldInfo? _outlineField;
    private static bool _fieldsResolved;

    /// <summary>Called from the <c>UpdateIcon</c> postfix on every node visual refresh. Idempotent.</summary>
    public static void ApplyBlind(NNormalMapPoint nmp)
    {
        if (_disabled) return;

        try
        {
            var point = nmp.Point;
            if (point == null) return;

            var state = RunManager.Instance?.State;
            if (state == null) return;

            // Reveal only PAST nodes (traveled but no longer the current position). The current
            // node — the one being entered, fought in, or stood on after returning — stays
            // blinded so the room type isn't spoiled during the fade-into-combat. It reveals
            // only once the player moves on to the next node.
            if (RevealTraveled && nmp.State == MapPointState.Traveled && !IsCurrent(point, state))
            { SetBlindMeta(nmp, false); return; }

            var map = state.Map;
            if (map == null) return;

            if (IsExempt(point, map)) { SetBlindMeta(nmp, false); return; }

            EnsureFields();
            if (_iconField?.GetValue(nmp) is TextureRect icon)
            {
                var tex = UnknownIcon();
                if (tex != null) icon.Texture = tex;
            }
            if (_outlineField?.GetValue(nmp) is TextureRect outline)
            {
                var tex = UnknownOutline();
                if (tex != null) outline.Texture = tex;
            }
            SetBlindMeta(nmp, true);
        }
        catch (Exception ex)
        {
            MainFile.Logger.Warn($"[{MainFile.ModId}] blind apply failed: {ex.Message}");
        }
    }

    /// <summary>True if this node is the player's current position (last visited coord).</summary>
    private static bool IsCurrent(MapPoint p, IRunState state) =>
        state.CurrentMapCoord is { } cur && cur.col == p.coord.col && cur.row == p.coord.row;

    private static void SetBlindMeta(NNormalMapPoint nmp, bool blinded) =>
        nmp.SetMeta(BlindMetaKey, blinded);

    /// <summary>
    /// True when the node keeps its real icon: fixed treasure (relic) node, the run's
    /// starting node, or a node that connects directly into a boss (the visible rest).
    /// </summary>
    private static bool IsExempt(MapPoint p, ActMap map)
    {
        if (p.PointType == MapPointType.Treasure) return true;   // fixed relic spot
        if (p.PointType == MapPointType.Ancient) return true;    // safety; usually a separate class
        if (SameCoord(p, map.StartingMapPoint)) return true;     // starting node
        if (FeedsInto(map.BossMapPoint, p)) return true;         // rest before the boss
        if (map.SecondBossMapPoint != null && FeedsInto(map.SecondBossMapPoint, p)) return true;
        return false;
    }

    /// <summary>True if <paramref name="p"/> is a parent of <paramref name="boss"/> (i.e. one step before it).</summary>
    private static bool FeedsInto(MapPoint boss, MapPoint p)
    {
        foreach (var parent in boss.parents)
            if (SameCoord(parent, p)) return true;
        return false;
    }

    private static bool SameCoord(MapPoint a, MapPoint b) =>
        a.coord.col == b.coord.col && a.coord.row == b.coord.row;

    private static void EnsureFields()
    {
        if (_fieldsResolved) return;
        _iconField = AccessTools.Field(typeof(NNormalMapPoint), "_icon");
        _outlineField = AccessTools.Field(typeof(NNormalMapPoint), "_outline");
        _fieldsResolved = true;
    }

    private static Texture2D? UnknownIcon() =>
        _unknownIcon ??= ResourceLoader.Load<Texture2D>(UnknownIconPath, null, ResourceLoader.CacheMode.Reuse);

    private static Texture2D? UnknownOutline() =>
        _unknownOutline ??= ResourceLoader.Load<Texture2D>(UnknownOutlinePath, null, ResourceLoader.CacheMode.Reuse);
}
