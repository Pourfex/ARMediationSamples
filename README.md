# AR Mediation Samples

Example AR scenes that use 
- [AR Foundation 5.1](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/index.html) 
- [Niantic ARDK 3](https://lightship.dev/docs/ardk/)

and demonstrate mediation for some AR features. 

Each medication of feature is used in a minimal sample scene with example code that you can modify or copy into your project.

## Which version should I use ?

The `master` branch of this repository uses AR Foundation 5.1 and Niantic ARDK 3 and is compatible with Unity 6 and newer. 

| Unity Version | AR Foundation Version | Niantic ARDkK Version |
|---------------|-----------------------|-----------------------|
| Unity 2023      | 5.1                 | 3                     |

## How to use these samples

### Build and run on device

You can build the AR Mediation Samples project directly to device, which can be a helpful introduction to using AR features for new users.

To build to device, follow the steps below:

1. Install Unity 2023 or later and clone this repository.

2. Open the Unity project at the root of this repository.

3. As with any other Unity project, go to [Build Settings](https://docs.unity3d.com/Manual/BuildSettings.html), select your target platform, and build this project.

### Understand the sample code

All sample scenes in this project can be found in the `Assets/Scenes` folder. To learn more about the AR Mediation components used in each scene, please refer to the documentation link below.

| Sample scene(s)        | Description |
|:-----------------------| :---------- |
| [HubScene](#Hub Scene) | Hub scene to choose the mediation sample you want to open

## Hub Scene

This is a good starting point as it will enables to choose which mediation sample you want to showcase.

Launching any samples from this Hub Scene will load scene additively ; with a minimal expendable interface to come back clicking "Go to menu" button once you've finish; unloading the chosen mediation scene.

| Action              | Meaning                                                                                                                                       |
|---------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| Any Mediation Scene | Open additively a mediation scene                                                                                                             |
| Burger Menu Button  | Expand or close the Hub Scene menu                                                                                                            |
| Go to menu          | Unload the chosen mediation scene                                                                                                             |
