# Laws of Creation

**A 3D tower defense game built with Unity, where you shape the battle by choosing the rules that affect enemies and your defenses.**

Protect your main castle, build and upgrade towers, and survive enemy waves across multiple levels. Choose up to three active rule cards to modify enemy stats and abilities, with some rules also changing tower performance. Adapt your defenses to the rules you select and manage your gold between construction, upgrades and selling towers.

## Core Mechanics & Code

| System | Implementation | Key code |
| --- | --- | --- |
| Rule selection | Choose up to three active rules from randomized card offers, with availability tied to wave progression. | [RuleManager](Assets/Project/Components/RulesComponents/RuleManager.cs), [AllRulesController](Assets/Project/Components/RulesComponents/AllRulesController.cs) |
| Rule effects | Modify enemy health, damage and speed, add shields or death-triggered bombs, and apply tower modifiers. | [RuleConfig](Assets/Project/ScriptableConfigs/RuleConfig.cs), [RuleSO](Assets/Project/ScriptableConfigs/RuleSO) |
| Tower construction & economy | Build on designated spots, respect wave-specific tower limits, spend gold and sell towers for a partial refund. | [TowerBuildController](Assets/Project/Components/ClickManager/TowerBuildController.cs), [GameEconomy](Assets/Project/Components/Economy/GameEconomy.cs) |
| Tower upgrades | Upgrade tower stats and visual models through configurable level data. | [CastleLevelSystem](Assets/Project/Components/CastleComponents/CastleLevelSystem.cs), [TowerUpgradeService](Assets/Project/Components/CastleComponents/TowerUpgradeService.cs) |
| Automated combat | Acquire nearby enemies within attack range and coordinate tower attacks. | [FindEnemySystem](Assets/Project/Components/CastleComponents/FindEnemySystem.cs), [CastleAttackController](Assets/Project/Components/CastleComponents/CastleAttackController.cs) |
| Enemy waves | Configure enemy groups, paths, spawn intervals, wave duration and rewards. Apply selected rules when enemies spawn. | [EnemyWaveController](Assets/Project/Components/EnemyComponents/EnemyWaveController.cs), [GameFlowController](Assets/Project/Components/GameComponents/GameFlowController.cs) |
| Level progression | Carry main castle health and selected rules between level scenes. | [LevelSceneController](Assets/Project/Components/LevelScenes/LevelSceneController.cs), [GameStateController](Assets/Project/Components/GameComponents/GameStateController.cs) |

## Technical Highlights

- **Component-based design:** separate systems for construction, targeting, combat, upgrades, economy and UI.
- **ScriptableObject configurations:** define towers, upgrade levels, enemies, attacks, waves and rule effects outside gameplay logic.
- **Extensible rule system:** individual rule classes implement effects through a shared configuration base.
- **C# events:** connect wave progression, enemy deaths, selection changes, economy and interface updates.
- **Interface-based communication:** use shared contracts for damage, selling, selection and enemy access.
- **Audio pooling:** reuse `AudioSource` instances for positional sound effects through [AudioService](Assets/Project/Components/GameComponents/AudioService.cs).

**Stack:** Unity 2021.3 LTS · C# · 3D Physics · Input System · URP · TextMesh Pro

## Run

Clone or download the repository, open it in **Unity 2021.3.45f2**, then open `Assets/Scenes/MenuScene.unity` and press **Play**.

**Controls:** Use the mouse to interact with build spots, towers, rule cards and menus. Press `Esc` to pause.
