# TankWar
使用unity开发的一款3D坦克对战游戏

## 🎮 在线试玩
[点击进入 WebGL 版本](https://ShenQing8.github.io/TankWar/) 

## 📦 本地运行
- **第一种方式：下载release版本，直接运行**
- 
步骤在release页面简介中
- **第二种方式：克隆仓库，在Unity中运行**
1. 克隆仓库：`git clone https://github.com/ShenQing8/TankWar.git`
2. 用 Unity **2022.3.24f1c1**或之后版本 打开项目
3. 运行 `Assets/Scenes/BeginScene.unity`

## 🔧 技术亮点
- **自主 UI 框架**：基于 IMGUI ，对其进行封装，实现 UI元素层级管理 及 分辨率自适应
- **数据管理工具**：对PlayerPrefs进行封装，开发了一个PlayerPrefsManager工具类，简化了数据的存取
- **敌人 AI 系统**：实现敌人的基础AI行为，巡逻、视野检测算法与攻击行为。

- ## 📚 代码结构
`/Assets/Scripts/`
- `Game/BeginScripts/……`：开始界面各组件（设置面板、背景音乐、排行榜面板、……）的脚本
- `Game/Data/……`：管理游戏数据的脚本
- `Game/GameScene/Object/……`：管理游戏中各物体基础属性的脚本（如：坦克基类、子弹类、枪支类、……）
- `Game/GameScene/Reward/……`：游戏中奖励物品挂载的脚本
- `Game/GameScene/UI/……`：游戏中管理UI面板的脚本（退出面板、游戏UI面板、胜利面板、失败面板）

- `PlayerprefsManager/……`：对PlayerPrefs封装后的工具类

- `PrefabScrips/……`：对IMGUI进行封装后用来控制`/Assets/Prefabs/GUI/`中的预设体所用的脚本

## 🖼️ 游戏截图
![游戏截图1](/Pictures/Begin.png)
![游戏截图2](/Pictures/SettingPanel.png)
![游戏截图3](/Pictures/Game.png)
![游戏截图4](/Pictures/RankPanel.png)
