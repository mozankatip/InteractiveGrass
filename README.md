# InteractiveGrass
## Introduction
Interactive Grass is a Unity URP shader made with Unity Shader Graph. 

https://github.com/mozankatip/InteractiveGrass/assets/47041584/1c981777-5654-4ad4-bd10-4b60776485c9


## Features

![MaterialSettings](https://github.com/mozankatip/InteractiveGrass/assets/47041584/b569be97-f861-4ba3-9a79-88a85a949946)


## Usage 
To use the Interactive Grass Shader, follow these steps:

1. Open the Unity project.
2. Make sure the project is set to use the Universal Render Pipeline (URP) template.
3. Create a new scene or open the provided "TestScene" scene.
4. For new scenes, create a grass prefab with your grass model.
5. Make sure your grass model has certain vertex paint(shader uses Red Channel on vertex colors) like below image for smooth interaction and wind settings.
![VertexPaint](https://github.com/mozankatip/InteractiveGrass/assets/47041584/e3e25ae0-1b88-4674-a65f-960c78d5dbb8)
7. For the interactivity, add "Interactor.cs" script to grass prefab.
8. Create an object to interact with the grass, put into grass prefab's interactor component.
9. Make grass placement on your scene and hit play button!

## Additional Scripts
* Interactor.cs




