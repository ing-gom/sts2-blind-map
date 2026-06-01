# Nexus Mods listing copy

Reference text for the Nexus Mods page. Nexus uses BBCode in the long
description; the summary field is plain text. The blocks below are
ready to paste.

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

## Description (BBCode, 한국어)

```bbcode
[size=4][b]이 모드는 무엇을 하나요[/b][/size]

액트 맵의 모든 노드를 게임의 미지([?]) 아이콘으로 다시 그려, 경로를 [i]블라인드[/i]로 선택하게 합니다. 다음 노드가 상점일까, 엘리트일까, 쉬운 전투일까? 방에 들어가기 전까지는 알 수 없습니다.

원래 경로 계획에 필요한 몇몇 노드만 그대로 표시됩니다:
[list]
[*][b]보스[/b] — 항상 표시 (고정 목적지).
[*][b]보스 직전 휴식(불)[/b] — 보스전 앞에 보이는 모닥불.
[*][b]시작 노드[/b].
[*][b]고정 보물(유물) 노드[/b] — 유물 확정 지점은 그대로 표시.
[/list]

그 외 전부 — 몬스터, 엘리트, 상점, 이벤트, 다른 휴식 — 는 [?] 로 표시됩니다.

[size=4][b]랜덤 방이 아니라 포그 오브 워입니다[/b][/size]
이 모드는 방의 실제 정체를 [b]바꾸지 않습니다[/b]. 가려진 상점은 도착하면 여전히 상점이고, 엘리트는 여전히 엘리트입니다. [i]아이콘만[/i] 가릴 뿐 — 방 종류, 인카운터, 보상, RNG 는 전혀 건드리지 않습니다. 맵 랜덤화가 아니라 순수 시각 오버레이입니다. (노드를 진짜 "?" 이벤트 방으로 바꾸면 맵의 약 85% 가 랜덤 이벤트가 되고 엘리트/상점 구조가 사라지므로, 의도적으로 그렇게 하지 않습니다.)

[size=4][b]동작[/b][/size]
[list]
[*][b]지나치기 전까지 [?] 유지[/b] — 진입하는 노드는 전투 페이드 동안과 방 안에 있는 동안 계속 가려져 있다가, 다음 노드로 넘어가야 공개됩니다. 한 박자 일찍 새지 않습니다.
[*][b]지나온 길은 보입니다[/b] — 이미 클리어하고 지나친 노드는 본모습을 드러냅니다.
[*][b]보스 / Ancient 노드는 손대지 않아[/b] 자동으로 표시됩니다.
[/list]

[size=4][b]설치[/b][/size]
[list=1]
[*][url=https://github.com/ing-gom/sts2-blind-map/releases]GitHub Releases 페이지[/url] (또는 본 페이지 Files 탭) 에서 최신 [b]Sts2BlindMap-vX.Y.Z.zip[/b] 다운로드.
[*][i]Sts2BlindMap/[/i] 폴더를 [i]<Slay the Spire 2 설치 경로>/mods/[/i] 안에 압축 해제.
[*]게임 실행.
[/list]

다음 경로에 파일이 위치해야 합니다:
[code]
<Slay the Spire 2>/mods/Sts2BlindMap/Sts2BlindMap.dll
<Slay the Spire 2>/mods/Sts2BlindMap/Sts2BlindMap.json
[/code]

[size=4][b]멀티플레이[/b][/size]
완전한 클라이언트 사이드 모드입니다. DLL 은 본인 클라이언트에만 로드되고, 게임 상태에 쓰지 않으며, 네트워크 메시지를 보내지 않고, 방 내용을 바꾸지 않습니다 — 다른 플레이어는 변경 없는 게임을 보며 desync 가 없습니다. 매니페스트에 [i]affects_gameplay: false[/i] 표기.

[size=4][b]설정[/b][/size]
[list]
[*][b]환경 변수[/b] — 게임 실행 전 [i]STS2_BLIND_MAP_DISABLED=1[/i] 설정 시 모드 제거 없이 블라인드 효과만 끔.
[/list]

[size=4][b]주의사항[/b][/size]
[list]
[*][b]다른 맵 정보 모드는 노드 정체를 노출할 수 있습니다[/b] — 노드 데이터를 직접 읽는 모드(예: 전투 노드에만 뜨는 포션 드롭 배지)는 맵이 블라인드된 것을 몰라 [?] 노드의 실제 정체를 누출할 수 있습니다. 의도한 챌린지를 위해서는 단독 사용 또는 다른 맵 오버레이 모드 비활성화를 권장합니다.
[*]시각 레이어에서 아이콘 텍스처만 교체합니다. 향후 게임 패치가 맵 포인트 클래스나 [i]map_unknown[/i] 에셋 경로를 바꾸면 소스 갱신이 필요할 수 있습니다.
[/list]

[size=4][b]크레딧 / 소스[/b][/size]
[list]
[*]MegaCrit — Slay the Spire 2.
[*]HarmonyX — 런타임 패치 라이브러리 (게임에 번들, 재배포 안 함).
[*]소스: [url=https://github.com/ing-gom/sts2-blind-map]github.com/ing-gom/sts2-blind-map[/url] · [url=https://github.com/ing-gom/sts2-blind-map/blob/main/LICENSE]MIT License[/url]
[*]English description: [url=https://github.com/ing-gom/sts2-blind-map/blob/main/README.md]README.md[/url]
[/list]
```
