本ディレクトリ構造

./CSharpeCreate  
	│  
	├/Novel+Script  
	│	…とりあえず、うごくものを作るために制作したディレクトリ  
	│  
	└/NovelGame  
		…可読性をよくしようと努力したディレクトリ  
		…疎結合になっていないため、何とかしたい！  	
  
以下にNovelGameディレクトリの構造示す。（内容一部略）  
  
./NobelGame  
	│  
	├/Config  
	│	└*（ファイル名省略）  
	│  
	├/Font  
	│	└*（ファイル名省略）  
	│  
	├/Image  
	│	└*（ファイル名省略）  
	│  
	├/Script  
	│	└*（ファイル名省略）  
	│  
	├/Src（ソースコードの部品。）  
	│	├/Commands（Script処理に必要な部品）  
	│	│	├ChangeImage.cs  
	│	│	├Command.cs  
	│	│	├EndQueue.cs　（未使用）  
	│	│	├JampScript.cs  
	│	│	├Link.cs  
	│	│	├LinkStop.cs  
	│	│	├Message.cs  
	│	│	├MessageClear.cs  
	│	│	├Transition.cs  
	│	│	└Wait.cs  
	│	│  
	│	├/Const（定数の役割を逸脱。TODO。）  
	│	│	├Background.cs  
	│	│	├Button.cs  
	│	│	├Character.cs  
	│	│	├CheckBox.cs  
	│	│	├Choice.cs  
	│	│	├DebugItems.cs  
	│	│	├DebugMenu.cs  
	│	│	├Image.cs  
	│	│	├Init.cs  
	│	│	├Label.cs  
	│	│	├Message.cs  
	│	│	├MessageFrame.cs  
	│	│	├Slider.cs  
	│	│	└Window.cs  
	│	│  
	│	├/Debug（デバッグ画面表示関連）  
	│	│	├FrameRate.cs  
	│	│	├Items.cs  
	│	│	└Menu.cs  
	│	│  
	│	├/LayerManager（各状態のレイヤー管理。ここが問題。）  
	│	│	├GamelLayerManager.cs  
	│	│	├SettingLayerManager.cs  
	│	│	└TitleLayerManager.cs  
	│	│  
	│	├/Layers（レイヤーの部品。）  
	│	│	├BackgroundLayer.cs  
	│	│	├ButtonLayer.cs  
	│	│	├CharacterLayer.cs  
	│	│	├CheckBoxLayer.cs  
	│	│	├ChoiceLayer.cs  
	│	│	├DebugItemsLayer.cs  
	│	│	├DebugMenuLayer.cs  
	│	│	├LabelLayer.cs  
	│	│	├Layer.cs  
	│	│	├MessageFrameLayer.cs  
	│	│	├MessageTextLayer.cs  
	│	│	└SliderLayer.cs  
	│	│  
	│	├/States（状態の部品。）  
	│	│	├NovelState.cs  
	│	│	├SettingState.cs  
	│	│	├State.cs  
	│	│	└TitleState.cs  
	│	│  
	│	├/Utilities（その他部品。）  
	│	│	├Config.cs  
	│	│	├ControlReturn.cs  
	│	│	├Format.cs  
	│	│	├Initializatio.cs  
	│	│	├Keybord.cs  
	│	│	├Logger.cs  
	│	│	├MousePoint.cs  
	│	│	├PointF.cs  
	│	│	├String.cs  
	│	│	└TransMethod.cs  
	│	│  
	│	└/Xml（Xmlもどき。）  
	│		└XmlMachine.cs  
	│  
	├/Xml  
	│	└*（ファイル名省略）  
	│  
	├compile.bat（コンパイルを自動化）  
	├debuglog.bat  （起動を自動化）
	├GameForm.cs  
	├memo.txt（日記的なサムシング）  
	├NovelGame.csproj（dotnetのプロジェクト）  
	├NovelGame.exe  
	├NovelGame.pdb  
	├Program.cs  
	├Program.exe  
	├release.bat （起動を自動化）  
	├releaselog.bat （起動を自動化）  
	├ScriptMachine.cs（Scriptを管理する。）  
	└StateManage.cs （状態を管理する。）  
  
以上。  
