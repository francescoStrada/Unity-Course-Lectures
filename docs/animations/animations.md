# Animations

An introduction to the main concepts associated with animations in Unity are covered in [this](https://youtube.com/playlist?list=PLk0p6RIhmcfn7cVwDWtoLBl7eFoiMqfN9) YouTube playlist.

In this page you can find an overview of the [project contents](#project-material) seen in the video and an [exercise](#Exercise) to practice the acquired knowledge. 

# Project Material

All the videos refer to scenes and scripts contained in the "Assets/\_Scripting" folder.

- [00-Simple-Animations](interactions.md#00-Simple-Animations)
- [01-Character-Animations](interactions.md#01-Character-Animations)
- [02-Timeline](interactions.md#02-Timeline)
- [03-DOTween](interactions.md#03-DOTween)
- [04-Coroutines](interactions.md#04-Coroutines)

### 00-Simple-Animations

TBD
### 01-Character-Animations

TBD

### 02-Timeline

TBD

### 03-DOTween

TBD

### 04-Coroutines

TBD

# Exercise

The goal of this exercise is to practice with the basic concepts and tools needed for handling animations in Unity.

The objective is to create an animation sequence (cut-scene) managed with the Unity timeline similar to the one described in [this video lecture](https://youtu.be/F56o6NAZ0HE) from the [animation playlist](https://youtube.com/playlist?list=PLk0p6RIhmcfn7cVwDWtoLBl7eFoiMqfN9).

Specifically, the cut-scene should be composed of **3 independent camera** which show a different animation realized with a different technique.

- **CAMERA 1:** a generic object of your choice whose components are animated directly inside Unity, using either the animation tab or the timeline tab. To do this, refer to [this video lecture](https://www.youtube.com/watch?v=mZWYVFmtU_s).

- **CAMERA 2**: a humanoid character animated with an Animator Controller. To download the Humanoid and its animation use the [Mixamo](https://www.mixamo.com/) platform. A detailed description on the steps to follow can be found in these two video lectures: [video 1](https://www.youtube.com/watch?v=wfGKYs-og9M) and [video 2](https://www.youtube.com/watch?v=Az0NLduoNo4).

- **CAMERA 3**: an object animated entirely via scripting using the DOTWeen asset, as shown in the [video lectures](https://www.notion.so/Scripting-Animations-c8a59955140c46aca13c90a5df2c1b37?pvs=4). 

In addition, try to add a camera movement to each of the 3 different cameras. For example, bringing the camera closer (or further) to the center of attention or performing a pan in the environment.