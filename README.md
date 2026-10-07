# CFGS - M11_AA1.1 - Remembering

The full exercise brief is in Google Drive: [AA1 Refresh – Exercise Doc](AA1_Refresh_IbanezGonzalezPau). It covers the requirements, plus a few questions and answers.

## Doc

### Intro
Here's a video of the finished exercise: [Final Result – Demo Video](https://drive.google.com/file/d/1xrbh4TIE8xM8vDXSNImzmqM3h0p3wiUq/view?usp=sharing).

Your project needs to have the same elements shown in the video.
This document has instructions on what to do, plus some optional hints. Mark the hints you've read. If you manage to do the exercises without reading the hints, even better.
You'll also need to explain in this document how you solved each exercise.


### Turret movement
Make the turret move so it aims with the mouse.
The turret should have 3 parts:
- Base: Rotates horizontally with mouse input
- Torso: Rotates vertically with mouse input
- Muzzle: An empty object at the tip of the torso that marks where the bullets will come out from

On top of that, the base and the torso of the turret have to be represented with 3D cubes

#### Explanation

asd

---

### Shooting
Small capsules should be fired from the muzzle when you press space. These capsules need to have the muzzle's orientation and be shot in the direction it's facing. The capsules should have gravity and collide with the scene.

#### Explanation
asd

---
### Destruction
Download the target models and import them into your project: [Target Models (complete + broken)](https://drive.google.com/file/d/14DIW-703XmoH0jJhyFQxWj5QhyY2R8vm/view?usp=drive_link).

One of them is the complete target, the other one has the pieces taken apart. When a bullet hits one of the complete targets, it should disappear and spawn the broken target. The broken target should come apart into individual pieces and fall. 3 seconds after the complete target disappears, it has to show up again. The only thing that should be able to destroy the targets is the bullets.

#### Explanation
asd

---

### Score
When one of the bullets destroys a target, +100 points have to be added to the total score. The total score shows up in the UI at the top center of the screen.

#### Explanation
asd

---

### Obstacle
Reusing the target model, give it a fully red material. When a bullet hits this target, it shouldn't be destroyed; instead it should subtract 100 points. Make this obstacle move linearly across the scene. Also add another regular target that also moves around the scene and gives +500 points when it's destroyed by a bullet.

#### Explanation
asd
