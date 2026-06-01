using System;
using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;

namespace Sts2BlindMap;

/// <summary>
/// Entry point. Installs a single Harmony patch on <c>NNormalMapPoint.UpdateIcon</c>
/// that repaints every non-exempt map node with the game's "unknown" (?) icon.
/// Purely a client-side visual overlay: no map data, room contents, RNG, or
/// multiplayer sync is touched. Disable at runtime via env var
/// <c>STS2_BLIND_MAP_DISABLED=1</c>.
/// </summary>
[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "Sts2BlindMap";

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; }
        = new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        try
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll(typeof(MainFile).Assembly);
            Logger.Info($"[{ModId}] Harmony patches applied.");
            Logger.Info($"[{ModId}] initialized (v0.1.0).");
        }
        catch (Exception ex)
        {
            Logger.Warn($"[{ModId}] init failed: {ex.Message}");
        }
    }
}
