### 环境
Unity 2022.3.20f1c1

### 项目结构
+---Assets
|   +---AmplifyShaderEditor          	# ASE插件
|   +---Art			     	
|   |   +---Mesh						# 存放模型、贴图
|   |   +---Shader						# ASE源文件
|   |   \---SKY							# 天空材质
|   +---Editor							# 批量重命名功能
|   +---Material						# 存放材质
|   +---Plugins
|   |   \---Demigiant
|   |       \---DOTween					# DOTween插件，用于相机平滑过渡
|   +---QuickOutline					# Outline插件，用于物体高亮，不过没有使用
|   +---Resources
|   +---Scenes
|   |   |   SampleScene.unity			# 样例，无实现
|   |   |   Workshop.unity				# 工厂场景
|   \---Scripts
|       +---Camera						# 控制相机的脚本
|       |       CameraFrontSwitcher.cs	# 前视图，用于按钮点击后切换视角
|       |       CameraMoveByFrontend.cs	# 前端点击数据后移动到该物体视角
|       |       CameraMoveWithObject.cs	# Unity中点击物体后移动到该物体视角
|       |       CameraUpSwitcher.cs		# 俯视图，用于按钮点击后切换视角
|       |       MainCameraControl.cs	# 运行时移动相机，左键移动，右键旋转，中键放缩
|       \---Outline						# 物体高亮的脚本
|               ChangeColor.cs			# 使用Outline插件高亮，未使用
|               ChangeWhole.cs			# 通过改变材质的颜色来高亮，使用中

### Workshop目录结构
+---3D
|   +---Mesh
|   |   +---groud           # 地面模型
|   |   +---Plane           # 地面网格
|   |   \---architecture    # 建筑模型
|   +---Light               # 光源
|   \---FX
|   |   +---SKY             # 天空的星星效果
|   |   +---SMOG            # 冷却塔烟雾效果
+---Canvas                  # 两个按钮
+---Camera
|   +---Main Camera         # 主相机
|   +---Up                  # 存放俯视视角，不启用
|   +---Front               # 存放前视视角，不启用

### 已实现功能
- 点击按钮切换视角
- 运行后自由移动视角
- 点击物体后切换到该物体视角，需要给物体添加Mesh Collider
- 前端悬浮数据时，对应物体高亮
- 前端点击数据是，切换到对应物体视角