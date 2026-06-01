using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Screens.Map;

namespace Sts2BlindMap.Patches;

/// <summary>
/// UpdateIcon is the single private method that loads a node's icon/outline texture from
/// its <c>PointType</c> (sts2.dll:152040). It runs on _Ready and on every RefreshState
/// (Untravelable → Travelable → Traveled), so a postfix here re-asserts the blind icon
/// after any of the game's own visual refreshes. Boss / Ancient have their own classes
/// and are intentionally not patched. UpdateIcon is non-public, so target it by name.
/// </summary>
[HarmonyPatch(typeof(NNormalMapPoint), "UpdateIcon")]
internal static class NNormalMapPoint_UpdateIcon_Patch
{
    private static void Postfix(NNormalMapPoint __instance) =>
        BlindMapService.ApplyBlind(__instance);
}
