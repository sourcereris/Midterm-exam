# Midterm Assignment: Game Project

## 1. Armored Enemy AI

The enemy's behavior is managed using a **State Machine Pattern** (`StateMachine.cs`, `BaseState.cs`) that controls movement and player interaction.

### Patrol Logic

* Patrol logic is handled within `EnemyController.cs`'s `FixedUpdate` method.
* The enemy uses two child `Transform` objects (`CheckWall` and `CheckCliff`) to detect its surroundings.
* `Physics2D.OverlapCircle` checks for obstacles (on `whatIsGround` or `whatIsBox` layers) or the absence of ground (a cliff).
* If a wall or cliff edge is detected, the `Flip()` function is called to reverse the `moveDirection` and rotate the enemy's transform, satisfying the patrol requirements.

### State Management

* The `StateMachine` switches between two states: `IdleState` and `ArmoredState`.
* **`IdleState`**: This is the default state. The enemy plays its "Walk" animation and patrols. It continuously checks the distance to the player. If the player comes within the 3-meter detection radius, it transitions to `ArmoredState`.
* **`ArmoredState`**: Upon entering this state, the "Start Defending" animator trigger is set. The enemy remains in this state until the player moves back outside the detection radius, at which point it transitions back to `IdleState` triggering coresponding animation.

## 2. Key and Chest System

This system implements a one-to-one relationship between a key and a chest.

* The `KeyController.cs` script is placed on a Key GameObject, which is a child of its corresponding Chest GameObject.
* On `Start`, the key automatically gets a reference to its parent `ChestController`.
* When the player's collider enters the key's trigger (`OnTriggerEnter2D`), the `KeyController` sets the parent `ChestController`'s `isOpening` property to `true`.
* The `ChestController`'s `Update` method detects this boolean change and sets the "Opening" parameter in its Animator to trigger the open animation.
* After being collected, the Key GameObject is destroyed.

## 3. Animation Event Relay

The `AnimationEvenetRelay.cs` script acts as a communication bridge between `Animator` components and C# scripts. This allows animation clips to trigger game logic at specific frames.

* **Chest System**: An animation event on the chest's "Opening" animation calls `ChestIsOpen()`. This sets the `chest.isOpen` property to `true`, allowing the Animator to transition from the opening animation to the final "Open" looped state.
* **Enemy System**: The relay is also used by the enemy's animations. For example, an event on the "Start Defending" animation clip can call `Armored()`. This sets the `Armored` boolean parameter in the Animator, which can be used to loop the "Defend Walk" animation while the enemy is in the `ArmoredState`. Similarly, `Unarmored()` can be called by the "Stop Defending" animation.