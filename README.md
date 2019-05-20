# AR Mini Games
_AR Mini Games_ (working title) is a project for mini games in Augmented Reality. Using the Unity engine in combination with ARCore and ARKit functionality we can bring these experiences to our users. Current game planned for production is AR Darts.

## Requirements
Minimum operating system requirements and UML diagrams are available [here](https://github.com/nyu-software-engineering/ar-mini-games/blob/master/REQUIREMENTS.md).

## Contributing
If you are interested in contributing, please see our contributing guidelines [here](https://github.com/nyu-software-engineering/ar-mini-games/blob/master/CONTRIBUTING.md).

## Installation
We plan to have app store releases once we reach a stable build. In the meantime check on our progress by cloning:
```
https://github.com/nyu-software-engineering/ar-mini-games.git
```
## Building and Testing The Project

## iOS Build 
Download the app directly to your iPhone from here: https://testflight.apple.com/join/QqSIY2N0

### Building onto iPhone from XCode Build W/O Using Unity  
1. Download iphone build for xcode here: https://www.dropbox.com/s/kj1ceviod5cnufi/DartsARBuild1.zip?dl=0
2. Unzip from the downloaded file: "DartsARBuild1". In the unzipped folder, open the following file in XCode: "Unity-iPhone.xcodeproj".
3. Connect iPhone to Mac
4. Afer opening, in XCode click the root folder: "Unity-iPhone". In the top left corner of XCode change "Generic  iOS Device" click and change the  device  to your connected iPhone

### Building and running in Unity Editor
1. Download Unity 2018.3.6f1 (later versions should be compatible, but this is our development Unity build) 
2. Open the ar-mini-games project in Unity by navigating to the "Assets/Scenes" folder from root directory.
3. Open "MainMenu.Unity"
4. Go to File -> Build Settings and choose Android or iOS, then click "Switch Platform"
5. Press the "Play" Button to launch the game. And The "Pause" Button to Stop
Note: Required to go to main menu scene every new test

### Building onto a iOS or Android Device From Unity 
1. In the Unity Editor go to File -> Build Settings
2. Pick the desired platform and click "Switch Platform"
3. Click "Build and Run", then run and follow additional instructions (e.g. build to phone in XCode)

For iOS we also have a prebuilt XCode project [here](https://www.dropbox.com/s/kj1ceviod5cnufi/DartsARBuild1.zip?dl=0).


### Testing
1. In Unity, navigate to the "Editor" folder, open "UnitTests.cs" to view code for unit tests 
2. From navigation bar, under the "Window" tab select "General" > "Test Runner"
3. "Test Runner" will open in a new pane. Select the "EditMode" tab, then click "Run All" to run tests  

## Developers
[**Antony Sunwoo**](https://github.com/asunwoo98) | NYU '19

Antony is a third-year Computer Science and Mathematics major at NYU. His main interest is artificial intelligence and software engineering.

[**Charles Dickstein**](https://github.com/charleswdickstein) | NYU '19

Charles is a fourth-year Computer Science major at NYU. He's experienced in web, mobile, and game development. He is passionate about augmented reality development and sushi. 

[**Tavius Koktavy**](https://github.com/kotavy) | NYU '19

Tavius is a fourth-year at Gallatin with a self-designed major in Emerging Technologies. His primary interest is developing immersive, persistent, and artistic XR experiences.

### License
This project is liscensed under [GNU Public License v3.0](https://github.com/nyu-software-engineering/ar-mini-games/blob/master/LICENSE).
