本ディレクトリ構造

./CSharpeCreate  
	├/Novel+Script  
	│　…とりあえず、うごくものを作るために制作したディレクトリ  
	└NovelGame:"可読性をよくすることを重視"  
	　　…可読性をよくしようと努力したディレクトリ  
	　　　ただ、絵を表示させるだけ  

ソースコードの概要を以下に示す  

|所属ディレクトリ名|属性|名前|概要|
|:--:|:--:|:--:|:---|
|Novel+Script|ファイル|Character.cs|登場人物のクラス。|
|Novel+Script|ファイル|ClearMessage.cs|Commandを継承したメッセージ部分クリアするクラス。|
|Novel+Script|ファイル|ClickWait.cs|Commandを継承したクリックを待機するクラス。|
|Novel+Script|ファイル|Command.cs|Commandの抽象クラス。|
|Novel+Script|ファイル|DataStorage.cs|グローバル変数的扱いを行うクラス。(要修正)|
|Novel+Script|ファイル|DisplayText.cs|Commandを継承したメッセージ部分の文字を表示するクラス。|
|Novel+Script|フォルダ|Font|フォントが入ったディレクトリ。|
|Novel+Script|フォルダ|Image|画像、アイコンファイルが格納されたディレクトリ。|
|Novel+Script|ファイル|ImageCommand.cs|Commandを継承した画像を表示させるクラス。|
|Novel+Script|ファイル|Link.cs|Commandを継承した選択肢に使う(targetで指定されたラベルに飛ぶ)クラス。|
|Novel+Script|ファイル|log.txt|起動するごとに内容を上書きしたログのテキストファイル。|
|Novel+Script|ファイル|NovelForm.cs|Formを継承したノベルのフォームを設定しているクラス。|
|Novel+Script|ファイル|NovelState.cs|Stateを継承し、実際はここでノベルのデザインを設定しているクラス。|
|Novel+Script|ファイル|Program.cs|main関数を含んだクラス。|
|Novel+Script|ファイル|Program.exe|実行ファイル。|
|Novel+Script|ファイル|readme.txt|メモ書き程度に記したメモ。確認しなくていい。|
|Novel+Script|フォルダ|Script|Script(.fnms:オリジナルテキストファイル拡張子)ファイルを格納したディレクトリ。|
|Novel+Script|ファイル|Script.cs|Scriptの内容に応じたFIFOを実装したクラス。|
|Novel+Script|ファイル|State.cs|Stateの抽象クラス。|
|Novel+Script|ファイル|StateManagement.cs|Stateを継承したクラスを管理するクラス。|
|Novel+Script|ファイル|Stop.cs|Commandを継承したLinkの後に必ず書く必要がある停止クラス。|
|Novel+Script|ファイル|Transition.cs|Commandを継承したトランジョン(画像を変化させる)クラス。|
|Novel+Script|ファイル|Wait.cs|Commandを継承した一定時間待つクラス。|
|NovelGame|ファイル|2019_07_05_log.txt|2019/07/05に作成されたログファイル。(日付が変わるごとにファイルが新しく作成される。)|
|NovelGame|フォルダ|Font|フォントファイルを格納したディレクトリ。|
|NovelGame|ファイル|GameForm.cs|Fromを継承したクラス。実際のデザインはStateクラスで実装。|
|NovelGame|フォルダ|Image|画像ファイルを格納したディレクトリ。|
|NovelGame|ファイル|Program.cs|main関数を含んだクラス。|
|NovelGame|ファイル|Program.exe|実行ファイル。|
|NovelGame|ファイル|ReadMe.txt|メモ。特にレビューに関係ない。読む必要なし。|
|NovelGame|ファイル|State.cs|State抽象クラスとそれを継承した具体的なクラスを実装。|
|NovelGame|ファイル|Utility.cs|あると便利なSingletonで実装されたクラス。|


以上。
