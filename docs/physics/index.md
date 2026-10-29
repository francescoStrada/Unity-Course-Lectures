---
title: ES04 - Physics
nav_order: 4
---

# Physics

An introduction to the main concepts associated with Physics simulations in Unity are covered in [this](https://youtube.com/playlist?list=PLk0p6RIhmcfnrVFCpKnPvYr6SZqTEiTAx) YouTube playlist.

In this page you can find an overview of the [project contents](#project-material).

## Project Material

All the videos refer to scenes and scripts contained in the "Assets/\_Physics" folder.  

- [00-Rigidbodies](#00-rigidbodies)
- [01-Colliders](#01-colliders)
- [02-Joints](#02-joints)
- [03-Explosions](#03-explosions)
- [04-Rigidbody-Movement](#04-rigidbody-movement)
- [05-Collision-Matrix](#05-collision-matrix)

<blockquote class="callout callout_default" theme="">
<p>Most of the scenes in the Physics collection are intended to be viewed from the <b>Scene</b> tab of the Unity Editor as the Camera is not correctly positioned. Thus, simply press play in the editor and then navigate the environment in the <b>Scene</b> view.</p> </blockquote>

### 00-Rigidbodies

![](imgs/physics-00-rigidbodies.gif)

In this scene it is possible to see several stations (delimited by the white square perimeter) each showing a different behaviour associated with the Rigidbody component. In order, from left to right:

- **Rigidbody vs No Rigidbody**: two cubes: only the right (yellow) cube falls to the ground having a Rigidbody component attached to it.
- **Different Mass Rigidbodies**: we have cubes of different dimensions, each with a Rigidbody component, with a growing value in the mass property. The rightmost cube has the least (1) vs the rightmost which has the highest (1000). When the objects fall we see that they fall at the same speed, to show that mass does not affect the speed of fall but will be determinant when object collide (01-Colliders).
- **Different Drag Rigidbodies**: in this section, the same cubes as above, instead of having different masses, they have different drag values (from 10 to 0.001) and equal mass. In this case the falling behaviour changes as their speed falling to the ground is affected as it happens in reality where drag with the atmosphere makes objects fall at different speeds.
- **Kinematic Movement**: for this area, activate the **Game** and click on it to enable input reading. Once the objects are on the ground you can press the **space bar** to move the cubes upwards. You will see different behaviours as the two cubes translation is performed differently. They are both moved by changing the transform.position value, but the red cube is not setted as Kinematic when the translation is applied, thus causing a conflict between the Physics and regular Update loops. Thus, it is important to remember that **if a rigidbody position will be controlled not from the physics simulation, IT MUST BE SETTED AS KINEMATIC.** 

### 01-Colliders

![](imgs/physics-01-colliders.gif)

As a general reference to the concepts associated with physics simulation and collisions, give a read to the Unity Manual [page](https://docs.unity3d.com/Manual/CollidersOverview.html).

As in the previous scene, this contains a series of "areas" displaying different features of the Unity colliders. Once you click Play, navigate the environment from the Scene view, from left to right:

- **Collider Types**: this shows the different type of collider which can be assigned on any given Game Object. For further details refer to the the Unity Manual Page for [Capsule](https://docs.unity3d.com/Manual/class-CapsuleCollider.html), [Box](https://docs.unity3d.com/Manual/class-BoxCollider.html) and [Sphere](https://docs.unity3d.com/Manual/class-SphereCollider.html).
- **Colliders vs No Colliders**: this box simply shows the difference of having or not having a collider component attached to a Game Object whith a Rigidbody component.
- **Static vs Dynamic Collider**: here we display the different reaction to collision based on the interaction between Colliders and Rigidbodies. The red pyramid shows how the blue falling objects which have a *higher* mass assigned to the Rigidbody will destroy the structure, "moving" the red cubes. Contrarily, in the green pyramid, the falling objects have a *smaller* mass compared to the green cubes. Resulting in a collision forces which do not displace the green cubes from their original position. Finally, the yellow pyramid displays cubes with ONLY a collider and NO rigidbody (also named [Static Colliders](https://docs.unity3d.com/Manual/CollidersOverview.html#:~:text=compound%20primitive%20colliders.-,Static%20colliders,-You%20can%20add)). Here we can see that the green cubes remain in their position as well as the falling spheres, this is because no collision force is generated when the colliders are static (only collider and no rigidbody).
- **Physics Materials**: this scene simply shows the different behaviours associated to colliders when a specific Physics Material is assigned to them. For details on the Physics Material check the [manual](https://docs.unity3d.com/Manual/class-PhysicMaterial.html). In general, the objects sliding on the green platform show the behaviour of different friction properties, whereas the red sphere show the effects of the bounciness property of the assigned physics material. 

### 02-Joints

![](imgs/physics-02-joints.gif)

Here we display the behaviours of the different [Joints](https://docs.unity3d.com/Manual/Joints.html) available in Unity. From left to right we see [Fixed Joints](https://docs.unity3d.com/Manual/class-FixedJoint.html), [Hindge Joints](https://docs.unity3d.com/Manual/class-HingeJoint.html)and [Spring Joints](https://docs.unity3d.com/Manual/class-SpringJoint.html). For further details on the scene refer to the associated YouTube [video](https://youtu.be/zqEQGy88Ftw).  
### 03-Explosions

![](imgs/physics-03-explosions.gif)

This scene shows how Rigidbodies can be controlled via scripting using the functions available in the [Rigidbody class](https://docs.unity3d.com/ScriptReference/Rigidbody.html). To run the scene, press Play, make sure to gain input control by pressing with the cursor inside the Game window and **press Spacebar**. You will see an explosion of cubes!

This is achieved through the CubeOfCubesDetonators.cs script (available in \_Physics/Scripts folder) attached to the different CubeOfCubes prefab.

![](imgs/physics-03-explosions-component.png)

The script get a reference to all child Rigidbodies and then when the Spacebar key is pressed it invokes the custom method Detonate:

```csharp
private void Detonate()
{
    for (int i = 0; i < _rigidbodies.Length; i++)
    {   _rigidbodies[i].isKinematic = false;
        _rigidbodies[i].AddExplosionForce(DetonationForce, transform.position, Radius);
	}
}
```

By cycling through each Rigidbody reference, it sets it to isKinematic = false to ensure that its movement will be driven by the Physics simulation and then applies an explosive force using the method [AddExplosionForce](https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html). The method receives as input: (1) a value for the force to be applied (DetonationForce variable), (2) a position identifying the center of the sphere within which the explosion has its effect (transform.position, i.e., the center of the cube) and (3) the the radius of the sphere within which the explosion has its effect (Radius variable)
### 04-Rigidbody-Movement

![](imgs/physics-04-rigidbody-movement.gif)

This scene demonstrates how Rigidbody components can be moved (using the appropriate methods) to control a "physics sensitive" character controller which in the scene is the GameObject named "RigidBody_ThirdPersonMovement". Generally speaking, the controller moves using the function [Rigidbody.Move()](https://docs.unity3d.com/ScriptReference/Rigidbody.Move.html). 

Press Play and move the character controller using the WASD keys.

You can compare another character controller by activating in the hierarchy the game object "CharacterController_ThirdPersonMovement". You can control it using the same keys as before. 

This controller moves using the [CharacterController](https://docs.unity3d.com/Manual/class-CharacterController.html) component which is mainly used for third-person or first-person player control that does not make use of Rigidbody physics.
### 05-Collision-Matrix

![](imgs/physics-05-collision-matrix.gif)

This scene is the same as the previous but the purple cubes are assigned to a specific [Layer](https://docs.unity3d.com/Manual/Layers.html) named *NoCollision* which prevents objects to collide with them. This is achieved by setting the [**collision matrix**](https://docs.unity3d.com/Manual/LayerBasedCollision.html) which can be accessed in the Unity menu bar, go to **Edit** > **Project Settings**, then select the **Physics** category to open the [Physics](https://docs.unity3d.com/Manual/class-PhysicsManager.html) window. From there scroll down and you can select which layers on the Collision Matrix will interact with the other layers by checking them.

![](imgs/physics-05-collision-matrix-example.png)
