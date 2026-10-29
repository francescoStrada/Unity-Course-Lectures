# Unity-Course-Lectures

Unity educational material for the Virtual Reality course held @ Politecnico di Torino.

![A selection of the project's scenes: scripting, physics, interactions, animations, NPCs, lighting and optimization](docs/assets/scenes-collage.jpg)

> [!WARNING]
> **This repository is under heavy maintenance.** The course is receiving a major update throughout this year, so things may break or not work as expected. Apologies for the inconvenience!
> If you run into a problem, please [open an issue](https://github.com/francescoStrada/Unity-Course-Lectures/issues/new): it lets me know what to fix and it is very much appreciated.

## Documentation

Lecture notes and explanations of the project material are available on the course site:

**https://francescostrada.github.io/Unity-Course-Lectures/**

## The Project

The Unity project is in the [`Unity-Course-Lectures/`](Unity-Course-Lectures) folder. It targets **Unity 6.3** (6000.3.27f1) with the **Universal Render Pipeline (URP)**. The Scripting, Interactions and Animations material also uses the new **Input System**; the other topics are being updated in turn.

The Blender files used in the 3D Assets lecture are in the [`Blender/`](Blender) folder, next to the Unity project. They are not needed to run the project, and the third-party buildings kit (downloaded from the internet, source unknown) is not included (see the [3D Assets page](https://francescostrada.github.io/Unity-Course-Lectures/3d-assets/)).

## Getting Started

1. **Get the project**: clone the repository (`git clone https://github.com/francescoStrada/Unity-Course-Lectures.git`) or download it from **Code > Download ZIP** and extract it.
2. **Install the editor**: install [Unity Hub](https://docs.unity.com/en-us/hub/install-hub) and, from it, **Unity 6000.3.27f1**. A later Unity 6.3 version works as well.
3. **Add the project to the Hub**: in **Projects**, click **Add > Add project from disk** and select the inner `Unity-Course-Lectures` folder, the one containing `Assets`, `Packages` and `ProjectSettings` (not the repository root). If the required editor version is missing, the Hub offers to install it.
4. **Open it**: the first opening takes a few minutes, while Unity imports all the assets.
5. **Play a scene**: the scenes of each topic are in `Assets/_<Topic>/Scenes` (for example `Assets/_Scripting/Scenes`). Open one, press **Play** and click inside the **Game** view before using the keyboard and the mouse.

## Branches

- `main`: stable version of the material
- `develop`: ongoing work
- `6.3-update`: upgrade of the project to Unity 6.3

## Contributing

Found a bug? Please [open an issue](https://github.com/francescoStrada/Unity-Course-Lectures/issues/new). If you have a fix or an improvement, feel free to fork the repository and open a pull request.
