# Nexus Mods listing copy

Reference text for the Nexus Mods page. Nexus uses BBCode in the long
description; the summary field is plain text. The blocks below are
ready to paste. The Nexus listing is English-only; Korean is available
via the linked README.ko.md in the repo.

---

## Summary (≤200 chars)

Hides every map node behind a "?" icon for a fog-of-war run. Boss, the pre-boss rest, your start, and fixed relic nodes stay visible. Visual only — rooms are unchanged. Client-side, multiplayer-safe.

## Description (BBCode, English)

```bbcode
[size=4][b]What it does[/b][/size]

Every node on the act map is repainted with the game's unknown ([?]) icon, so you choose your path [i]blind[/i]. Is that next node a shop, an elite, or an easy fight? You won't know until you walk into the room.

A few nodes stay visible — the ones you're meant to plan around:
[list]
[*][b]Boss[/b] — always shown (fixed destination).
[*][b]The rest site right before the boss[/b] — the "fire" ahead of the boss fight.
[*][b]Your starting node[/b].
[*][b]Fixed treasure (relic) nodes[/b] — guaranteed relic stops stay marked.
[/list]

Everything else — monsters, elites, shops, events, other rest sites — shows as [?].

[size=4][b]This is fog-of-war, not random rooms[/b][/size]
The mod does [b]not[/b] change what any room actually is. A hidden shop is still a shop when you arrive; an elite is still an elite. Only the [i]icon[/i] is hidden — room type, encounter, rewards and RNG are completely untouched. It's a pure visual overlay, not a map randomizer. (Genuinely turning nodes into "?" event rooms would collapse ~85% of the map into random events and delete the act's elite/shop structure, so this mod deliberately doesn't do that.)

[size=4][b]Behavior[/b][/size]
[list]
[*][b]Nodes stay [?] until you've passed them[/b] — the node you're entering stays hidden through the fade into combat and while you're in the room; it reveals only once you move on to the next node, so nothing is spoiled a moment early.
[*][b]Your trail is readable[/b] — nodes you've already cleared and walked past reveal their true type.
[*][b]Boss / Ancient nodes are never touched[/b] and stay visible automatically.
[/list]

[size=4][b]Installation[/b][/size]
[list=1]
[*]Download the latest [b]Sts2BlindMap-vX.Y.Z.zip[/b] from the [url=https://github.com/ing-gom/sts2-blind-map/releases]GitHub Releases page[/url] (or the Files tab here).
[*]Extract the [i]Sts2BlindMap/[/i] folder into [i]<Slay the Spire 2 install>/mods/[/i].
[*]Launch the game.
[/list]

You should end up with:
[code]
<Slay the Spire 2>/mods/Sts2BlindMap/Sts2BlindMap.dll
<Slay the Spire 2>/mods/Sts2BlindMap/Sts2BlindMap.json
[/code]

[size=4][b]Multiplayer notes[/b][/size]
Fully client-side. The DLL only loads on your machine, doesn't write to game state or send network messages, and doesn't change room contents — other players see an unmodified game and there is no desync. The manifest declares [i]affects_gameplay: false[/i].

[size=4][b]Configuration[/b][/size]
[list]
[*][b]Environment variable[/b] — set [i]STS2_BLIND_MAP_DISABLED=1[/i] before launching the game to disable the blind effect without uninstalling the mod.
[/list]

[size=4][b]Caveats[/b][/size]
[list]
[*][b]Other map-info mods may still reveal a node's type[/b] — mods that read node data directly (e.g. a potion-drop badge that only appears on combat nodes) don't know the map is blinded, so they can leak what a [?] node really is. For the intended challenge, run Blind Map on its own or disable other map-overlay mods.
[*]The mod only swaps icon textures on the visual layer. If a future game patch changes the map-point class or the [i]map_unknown[/i] asset path, the source may need an update.
[/list]

[size=4][b]Credits / Source[/b][/size]
[list]
[*]MegaCrit — Slay the Spire 2.
[*]HarmonyX — runtime patching library used by this mod (bundled with the game; not redistributed).
[*]Source: [url=https://github.com/ing-gom/sts2-blind-map]github.com/ing-gom/sts2-blind-map[/url] · [url=https://github.com/ing-gom/sts2-blind-map/blob/main/LICENSE]MIT License[/url]
[*]한국어 설명: [url=https://github.com/ing-gom/sts2-blind-map/blob/main/README.ko.md]README.ko.md[/url]
[/list]
```
