# Hired-Ops-Aimbot
### **Game** : Hired Ops ([Open Steam Page](https://store.steampowered.com/app/374280))

A small Base made in C# that includes an Aimbot and manipulates some game values so the Enemy gets highlighted. Can be used by beginners for cheating in Unity3D games. I did quit from this shitty game. As long a feature doesn't fly right into my hands I won't add more things to this simple base. Feel free to fork it.

### Features:
* **Aimbot** (Current Key: V)
* **Enemy Highlight** (Lets a small Icon appear at the Players Screen Position)

*Enemy Highlight doesn't work in the Game Mode "Deathmatch". They use another Highlight Method for it. Since it was obfuscated I didn't play a lot around with and ignored it.*


## Getting Started

### Prerequisites
To use this you will need a Tool that lets you inject Assemblies into some Mono embedded environment. I recommend you [SharpMonoInjector](https://github.com/warbler/SharpMonoInjector).

You also need some IDE to edit it in and if needed updating it. I recommend you the [Visual Studio IDE](https://visualstudio.microsoft.com/de/vs/).

### Build
To be able to Compile it you will need to declare some references from the Game **Hired Ops**.
```
using UnityEngine;
using Assets.Scripts.Engine.Network;
using Assets.Scripts.Game;
```
In order to use those you will need to reference these Game Files:
* **Assembly-CSharp.dll** - Can be found at : ``...\steamapps\common\Hired Ops\hops_Data\Managed\Assembly-CSharp.dll``
* **UnityEngine.dll** - Can be found at : ``...\steamapps\common\Hired Ops\hops_Data\Managed\UnityEngine.dll``

### Contributing
If you are interested to contribute something I would be more than happy. The more, the better.

## Authors
* **0xD3F** - *Main Dev*
* *And all the awesome peeps at [**Unknowncheats.me**](https://www.unknowncheats.me/) that shared Information in that one [thread](https://www.unknowncheats.me/forum/other-fps-games/350729-hired-ops-modified-assembly-esp-recoil.html).*
