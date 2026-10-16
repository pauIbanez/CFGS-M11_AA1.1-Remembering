# **CFGS - M11_AA1.1 - Remembering**

The full exercise brief is in Google Drive: [AA1 Refresh – Exercise Doc](AA1_Refresh_IbanezGonzalezPau). It covers the requirements, plus a few questions and answers.

## **Doc**

### **Intro**
Here's a video of the finished exercise: [Final Result – Demo Video](https://drive.google.com/file/d/1xrbh4TIE8xM8vDXSNImzmqM3h0p3wiUq/view?usp=sharing).

Your project needs to have the same elements shown in the video.
This document has instructions on what to do, plus some optional hints. Mark the hints you've read. If you manage to do the exercises without reading the hints, even better.
You'll also need to explain in this document how you solved each exercise.


### **Turret movement**
Make the turret move so it aims with the mouse.
The turret should have 3 parts:
- Base: Rotates horizontally with mouse input
- Torso: Rotates vertically with mouse input
- Muzzle: An empty object at the tip of the torso that marks where the bullets will come out from

On top of that, the base and the torso of the turret have to be represented with 3D cubes

#### **Explanation**
Everything is in [Movement.cs](./Assets/Scripts/Movement.cs). In this script there are the following `private` but [Serialized <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>
](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/SerializeField.html) variables:

- `2` `Vector2` variables, each with its own [Tooltip <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/TooltipAttribute.html) explaining what they do.

- `2` References for the turret parts

And these non-serialized `private` variables:
- `2` decimal numbers


All variables are private because no other part of our program needs them, but some are serialized so they are configurable from the Inspector.


The script first stores the initial yaw and pitch components of the turret in their respective variables and locks the mouse to the screen.

Then, in each update, it reads the mouse delta, multiplies it by the configured sensitivity, and assigns new values to the *stored* pitch and yaw values based on the read mouse delta, each run through a controlling `Mathf` function.
- The yaw is passed through [Mathf.Repeat <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/ScriptReference/Mathf.Repeat.html), which makes the number wrap back around to 0 if it goes past 360 degrees.
- The pitch component is passed through [Mathf.Clamp <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Mathf.Clamp.html), which limits the pitch to the configured angles.

Lastly, it takes these controlled pitch and yaw values and assigns them as the current local rotation of the respective turret parts.

---

### **Shooting**
Small capsules should be fired from the muzzle when you press space. These capsules need to have the muzzle's orientation and be shot in the direction it's facing. The capsules should have gravity and collide with the scene.

#### **Explanation**
All shooting is handled in [Shoot.cs](./Assets/Scripts/Shoot.cs). In this script there are the following `private` but [Serialized <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>
](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/SerializeField.html) variables:

- `1` number to store the projectile force
- `2` references to store the muzzle point and projectile prefab

All variables are private because no other part of our program needs them, but serialized so they are configurable from the Inspector.

In each update, this script checks if the space key was pressed and if it was it does the following:

1. It first spawns a new GameObject based on the configured prefab in the position and orientation of the muzzle point

2. It grabs the spawned projectile's `Rigidbody` component and adds the configured muzzle force to it as an impulse

3. It tells Unity to [Destroy <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Object.Destroy.html) the projectile after `3` seconds, so the bullets don't pile up in the scene

---
### **Destruction**
Download the target models and import them into your project: [Target Models (complete + broken)](https://drive.google.com/file/d/14DIW-703XmoH0jJhyFQxWj5QhyY2R8vm/view?usp=drive_link).

One of them is the complete target, the other one has the pieces taken apart. When a bullet hits one of the complete targets, it should disappear and spawn the broken target. The broken target should come apart into individual pieces and fall. 3 seconds after the complete target disappears, it has to show up again. The only thing that should be able to destroy the targets is the bullets.

#### **Explanation**
All destruction is handled in [Target.cs](./Assets/Scripts/Target.cs), which goes on the root object of each target. In this script there are the following `private` but [Serialized <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>
](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/SerializeField.html) variables:

- `1` decimal number to store the respawn time (`3` seconds)
- `1` whole number to store the points the target gives when hit (`100` by default, it can be negative to take points away)
- `1` boolean to stop the target from breaking when hit (`false` by default, used by the [Obstacle](#obstacle))
- `2` references to the target's children: the complete model and the broken model
- `2` decimal numbers to store the impact force and the impact radius, used to push the broken pieces away from where the bullet hit

And this non-serialized `private` variable:
- `1` reference to the target's own `Collider`, grabbed in `Awake`

All variables are private because no other part of our program needs them, but some are serialized so they are configurable from the Inspector.

The target prefab has both models as children. The complete one starts active, and the broken one starts inactive, with a `Rigidbody` and a convex `MeshCollider` on each of its pieces so they fall apart on their own when they get enabled. The broken child is never shown directly, it is only used as a template to copy.

When something collides with the target, [OnCollisionEnter <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Collider.OnCollisionEnter.html) is called and the script does the following:

1. It checks if the object that hit it has the `Bullet` tag and if the complete model is currently visible. If not, it does nothing, so only bullets can destroy the targets and a target can't break twice

2. It adds the configured points to the total score by calling `Score.ModifyScore` (explained in the [Score](#score) section)

3. It destroys the bullet, so it can't bounce off and hit anything else

4. If the target is set to prevent being destroyed, it stops here

5. Otherwise, it starts the `Break` [Coroutine <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/MonoBehaviour.StartCoroutine.html), passing it the point where the bullet hit, taken from the first contact of the collision

The `Break` coroutine does the following:

1. It deactivates the complete model and the target's collider, so nothing can hit the invisible target and the broken pieces don't get stuck inside it

2. It spawns a copy of the broken model in the same position, activates it so the pieces fall, and tells Unity to [Destroy <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Object.Destroy.html) that copy after the respawn time, so the pieces don't stay in the scene forever

3. It waits for the next physics step, so the new pieces are part of the physics simulation before any force is applied to them

4. It goes through every `Rigidbody` in the copy and applies an [AddExplosionForce <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Rigidbody.AddExplosionForce.html) as an impulse from the impact point. Pieces closer to where the bullet hit get pushed harder. There is no global function to push every `Rigidbody` in an area, so each piece has to get the force on its own

5. It waits the respawn time

6. It activates the complete model and the collider again, so the target shows up and can be shot again

The broken model is copied instead of just being activated because its pieces move when they fall. If the original were used, it would have to be moved back piece by piece every time the target respawns.

---

### **Score**
When one of the bullets destroys a target, +100 points have to be added to the total score. The total score shows up in the UI at the top center of the screen.

#### **Explanation**
The score is handled in [Score.cs](./Assets/Scripts/Score.cs), which goes on an object in the scene. In this script there is the following `private` but [Serialized <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>
](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/SerializeField.html) variable:

- `1` reference to the `TMP_Text` in the UI that shows the score

And these non-serialized `private` variables:
- `1` `static` reference to the `Score` instance in the scene
- `1` whole number to store the current points

The script uses the [Singleton <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://gameprogrammingpatterns.com/singleton.html) pattern, so there is only ever one score and any script can reach it without needing a reference to it.

In `Awake`, it checks if there is already a `Score` instance stored. If there is one and it isn't this one, it destroys this component so there are never two scores. Otherwise, it stores itself as the instance.

To change the score, other scripts call the `public static` function `ModifyScore` with the amount of points to add (a negative amount subtracts them). This function passes the points to the stored instance, which does the following:

1. It adds the points to the current total

2. It writes the new total into the UI text

This way, the scripts that give or take points don't need to know anything about the UI. Right now it is called from:
- [Target.cs](./Assets/Scripts/Target.cs), which adds its configured points when a bullet hits it (see the [Destruction](#destruction) section). The obstacle uses the same script with negative points, so it subtracts them (see the [Obstacle](#obstacle) section)

---

### **Obstacle**
Reusing the target model, give it a fully red material. When a bullet hits this target, it shouldn't be destroyed; instead it should subtract 100 points. Make this obstacle move linearly across the scene. Also add another regular target that also moves around the scene and gives +500 points when it's destroyed by a bullet.

#### **Explanation**
The obstacle and the moving target don't need new hit logic. They reuse [Target.cs](./Assets/Scripts/Target.cs) (see the [Destruction](#destruction) section) with different settings, plus a new script to move them.

Both are saved as prefabs:
- [TargetBad](./Assets/Prefabs/TargetBad.prefab): the obstacle. It only has the complete model, with the red `Bad` material on all of it. In its `Target` component, the points are set to `-100` and *prevent destroy* is turned on, so when a bullet hits it the score goes down by 100, the bullet disappears and the obstacle stays where it is
- [TargetGood](./Assets/Prefabs/TargetGood.prefab): the moving target. It is a regular target with the complete and broken models, with the `Good` material on both. In the scene its points are set to `500`, so it gives +500 when it's destroyed

The movement is handled in [MovingTarget.cs](./Assets/Scripts/MovingTarget.cs), which goes on the root object of both prefabs. In this script there are the following `private` but [Serialized <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>
](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/SerializeField.html) variables:

- `1` array of `Transform` references, the points of the path the object follows
- `1` decimal number to store the movement speed (`2` for the obstacle, `5` for the moving target)

And this `public` variable:
- `1` whole number to store the index of the path point the object is currently moving towards

The paths are empty objects in the scene (`BadTargetPath` and `GoodTargetPath`), each with one child per point.

In each update, the script does the following:

1. It moves the object towards the current path point with [Vector3.MoveTowards <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
	<path d="M0 0h24v24H0z" fill="none" />
	<g fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
		<path stroke-dasharray="42" d="M11 5h-6v14h14v-6">
		</path>
		<path stroke-dasharray="12" d="M13 11l7 -7">
		</path>
		<path stroke-dasharray="8" d="M21 3h-6M21 3v6">
		</path>
	</g>
</svg>](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Vector3.MoveTowards.html), using the configured speed multiplied by `Time.deltaTime` so the speed doesn't depend on the frame rate. This moves it in a straight line and never overshoots the point

2. If the object is within `0.1` units of the point, it moves on to the next point. When it reaches the last point, it goes back to the first one, so the path loops forever

Because the broken pieces are spawned as a copy at the broken model's position at that moment (see the [Destruction](#destruction) section), the moving target breaks wherever it was hit.

---

### **Camera**
The camera has to pivot around the turret. It's controlled with WASD. When the camera touches an obstacle (the ground, for example), it moves closer to the turret until it stops colliding with any obstacle.

These have to be configurable from the Inspector:
- Vertical sensitivity
- Horizontal sensitivity
- Camera distance when it isn't colliding

Example of the camera: [Camera – Example Video](https://i.imgur.com/MoyjbSG.mp4).

#### **Explanation**
asd
