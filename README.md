# StS2 Blind Map

A **Slay the Spire 2** mod that hides every map node behind an unknown (`?`) icon — turning act navigation into a fog-of-war challenge.

> You pick your path *blind*. Is that next node a shop, an elite, or an easy fight? You won't know until you walk into the room.

[한국어 README](README.ko.md)

---

## What it does

Every node on the map is repainted with the game's generic unknown (`?`) sprite, **except** the few nodes whose identity you're meant to plan around:

- **Boss** — always visible (it's a fixed destination).
- **The rest site right before the boss** — the "fire" you can see ahead of the boss fight.
- **Your starting node**.
- **Fixed treasure (relic) nodes** — the guaranteed relic stops stay marked.

Everything else — monsters, elites, shops, events, other rest sites — shows as `?`. You commit to a route without knowing what's on it, and discover each room only when you arrive.

## Important: this is fog-of-war, not random rooms

The mod **does not change what any room actually is**. A hidden shop is still a shop when you get there; an elite is still an elite. Only the *icon* is hidden — the underlying room type, encounter, rewards, and RNG are completely untouched. This is a pure visual overlay, not a map-randomizer.

(Genuinely converting nodes to "?" event rooms would make ~85% of the map roll into random events and delete the act's elite/shop structure — so this mod deliberately doesn't do that.)

## Behavior details

- **Nodes stay `?` until you've passed them.** The node you're entering stays hidden through the fade into combat and while you're in the room — it only reveals once you move on to the *next* node, so the room is never spoiled a moment early.
- **Your trail is readable.** Nodes you've already cleared and walked past reveal their true type, so you can see where you've been.
- **Boss / Ancient nodes are rendered by their own game classes** and are never touched, so they stay visible automatically.

## How it works

1. The mod patches `MegaCrit.Sts2.Core.Nodes.Screens.Map.NNormalMapPoint.UpdateIcon` with Harmony (HarmonyX, bundled with the game).
2. After the game draws a node's real icon, the postfix swaps the node's `_icon` / `_outline` textures for the `map_unknown` sprite — unless the node is exempt (boss-adjacent rest, fixed treasure, or the starting node).
3. The node's `MapPointType` is **never modified**, so room resolution, saves, and multiplayer sync all see the unchanged map.

## Multiplayer

Fully client-side. The DLL only loads for the player who installed it; it doesn't write to game state or send any network messages, and it doesn't change room contents — so other players see an unmodified game and there is no desync. The manifest declares `"affects_gameplay": false`.

## Installation

1. Download the latest `Sts2BlindMap-vX.Y.Z.zip` from [GitHub Releases](../../releases) (or the Files tab on Nexus).
2. Extract the `Sts2BlindMap/` folder into:
   ```
   <Slay the Spire 2 install>/mods/
   ```
   so you end up with:
   ```
   <Slay the Spire 2>/mods/Sts2BlindMap/Sts2BlindMap.dll
   <Slay the Spire 2>/mods/Sts2BlindMap/Sts2BlindMap.json
   ```
3. Launch the game.

## Building from source

Requirements:
- .NET SDK 9.0
- Godot.NET.Sdk 4.5.1 (resolved automatically)
- A local Slay the Spire 2 install (auto-detected via Steam registry / standard paths by `Sts2PathDiscovery.props`)

```sh
dotnet build Sts2BlindMap.csproj -c Release
```

The build automatically copies `Sts2BlindMap.dll` and `Sts2BlindMap.json` into `<sts2>/mods/Sts2BlindMap/`.

## Configuration

Set the environment variable `STS2_BLIND_MAP_DISABLED=1` before launching the game to disable the blind effect without uninstalling the mod.

## Notes & limits

- **Boss nodes are intentionally always visible** — they're a fixed destination, so hiding them would serve no purpose.
- **Other map-info mods may still reveal a node's type.** Mods that read the node data directly (for example a potion-drop-chance badge that only appears on combat nodes) don't know the map is blinded, so they can leak what a `?` node really is. For the intended challenge, run Blind Map on its own, or disable other map-overlay mods.
- The mod only swaps icon textures on the visual layer. If a future game patch changes the map-point class or the `map_unknown` asset path, the source may need an update.

## Credits

- **MegaCrit** — for Slay the Spire 2.
- **HarmonyX** — runtime patching library used by this mod (bundled with the game; not redistributed here).

## License

[MIT](LICENSE).
