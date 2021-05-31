# Scene Object

A reference management package for scene assets in Unity

## Installation
Follow the steps [Here](https://github.com/FedoraDevStudios/Installation-Unity) to add this package to your Unity project using this package's URL.

## Usage
#### Scene Layout
If you're using empty objects with descriptive names to organize your scene, then you may find use with Scene Layouts. Use `Create -> Scene Object -> Scene Layout` to create a neat scriptable object that has a list of strings and a wrapper string. When using the `Scene Creator` menu, you can assign a layout object during creation. Doing so will automatically create an empty object for each item in the list with a name surrounded by the wrapper. By default, any item you add to the list will create an object in the format `===== Object Name =====`.

#### Create a Scene (optional)
Use `Scene Creator` in the right-click menu of the project panel to get a window. The `Location` is automatically populated with the path that you right-clicked to open the menu. You can freely select any folder and use `Set to Active` to automatically populate the path. Next, `Scene Name` is where you will name the scene. This name is used for the scene asset, the scene object, and the folder that they will reside in. If you have a layout defined, you can select it and even modify it in the `Layout` box. After everything is created, click `Create`. The new directory should be created with 2 files within, a scene asset and a scene object.

#### Scene Loader
The included implementation of `ISceneLoader` (called `Instant Loader`) will likely handle most situations. It unloads the current scene, then loads the next scene. You can choose to show a loading screen as it does this. If you do use a loading screen, the loader will automatically search for a `LoadingBarBehaviour` component in the scene and push progress updates to it. The `LoadingBarBehaviour` has 1 field where you can drop in an `IDisplayProgress` object. I've included an implementation called `SliderProgressDisplay` which will show the progress on a `Slider` component from Unity. To get this to work, create a `Slider` in the loading scene and attach both a `SliderProgressDisplay` component and a `LoadingBarBehaviour` component to it, then drag the `SliderProgressDisplay` component into the `Progress Display` field of `LoadingBarBehaviour`. Now, whenever this loading scene is used, the slider will automatically keep track of progress. This may seem like a lot of steps to get this to work, however it is intended for those that want to use something other than Unity's `Slider`. You can quickly implement your own `IDisplayProgress` for whatever component you create and the system can still latch on automatically.

#### Create Metadata (optional)
Metadata is useful if you want to add some additional information about your scenes to be used elsewhere in code. I did include `SimpleMetadata` as an example, however I would highly recommend against using it as you cannot change it and in order to fully utilize it, you would need to reference the `Implementations` portion of the code, which is not the intent of the system. Instead, you should create a new class that implements `ISceneMetadata` where you can add any amount of information you please. This interface does not require any methods or properties, however the implementing object should be a class. After creating the class, it should pop up in the Scene Object's `Metadata` dropdown.