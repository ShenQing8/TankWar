# TankWar
使用unity开发的一款3D坦克对战游戏

## 🎮 在线试玩
[点击进入 WebGL 版本](https://ShenQing8.github.io/TankWar/) 

## 📦 本地运行
1. 克隆仓库：`git clone https://github.com/你的ID/仓库名.git`
2. 用 Unity **202x.x.x** 打开项目
3. 运行 `Assets/Scenes/MainScene.unity`

## 🔧 技术亮点
- **自主 UI 框架**：基于 IMGUI 实现分辨率自适应 [...]
- **数据管理工具**：PlayerPrefsManager 泛型封装 [...]
- **敌人 AI 系统**：状态机 + 视野检测算法 [...]

## 🖼️ 游戏截图
![游戏截图1](/Picture/Begin.png)
![游戏截图2](/Picture/SettingPanel.png)
![游戏截图3](/Picture/Game.png)
![游戏截图4](/Picture/RankPanel.png)

## 📚 代码结构
`/Assets/Scripts/`
- `Player/`：坦克控制/射击/生命值  
- `AI/`：敌人状态机/寻路  
- `UI/`：自定义 UI 组件 [...]
