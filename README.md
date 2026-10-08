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
All shooting is handled in [Shooting.cs](./Assets/Scripts/Shooting.cs). In this script there are the following `private` but [Serialized <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
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

In each update, this script checks it the space key input was fired and if it was it does the following:

1. It first spawns a new GameObject based on the configured prefab in the position and orientation of the muzzle point

2. It grabs the spawned projectil's `Rigidbody` component and adds the configured mizzle force to it as an impulse

---
### **Destruction**
Download the target models and import them into your project: [Target Models (complete + broken)](https://drive.google.com/file/d/14DIW-703XmoH0jJhyFQxWj5QhyY2R8vm/view?usp=drive_link).

One of them is the complete target, the other one has the pieces taken apart. When a bullet hits one of the complete targets, it should disappear and spawn the broken target. The broken target should come apart into individual pieces and fall. 3 seconds after the complete target disappears, it has to show up again. The only thing that should be able to destroy the targets is the bullets.

#### **Explanation**
asd

---

### **Score**
When one of the bullets destroys a target, +100 points have to be added to the total score. The total score shows up in the UI at the top center of the screen.

#### **Explanation**
asd

---

### **Obstacle**
Reusing the target model, give it a fully red material. When a bullet hits this target, it shouldn't be destroyed; instead it should subtract 100 points. Make this obstacle move linearly across the scene. Also add another regular target that also moves around the scene and gives +500 points when it's destroyed by a bullet.

#### **Explanation**
asd
