using Const;
using System;
using States;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

// Formを継承したクラス。
// 具体的描写や入力関係は違うクラスで実装する。
public class GameForm : Form
{
    // 描写する内容はすべてここに張り付ける
    private PictureBox drawImage_;
    // 状態を管理する
    private StateManage stateManage_;

    // ゲームフォームの初期化。
    public GameForm()
    {
        // 幅指定
        Width = Const.Window.WIDTH;
        // 高さ指定
        Height = Const.Window.HEIGHT;
        // 最大化をできないようする。
        FormBorderStyle = FormBorderStyle.FixedSingle;
        BackgroundImageLayout = ImageLayout.Stretch;
        MaximumSize = Size;

        // タイトルを設定
        Text = "タイトル（仮）";

        // Loadイベントハンドラを追加。
        this.Load += new EventHandler(this.GameForm_Load);

        // 状態管理を初期化。
        stateManage_ = new StateManage();

        // 描写するコントローラを初期化
        drawImage_ = Initialization.InitPictureBox();
        drawImage_.MouseMove += new MouseEventHandler(this.MouseMove);
    }

    // 描写する内容はこちらで取得している。
    // 状態管理のPeekの内容を描写する。
    public void Draw()
    {
        drawImage_.Image = stateManage_.Peek().GetDrawImage();
    }

    // 更新内容をアップデートします。
    // 状態管理のPeekの内容を更新する。
    public new void Update()
    {
        stateManage_.Peek().Update(stateManage_, this);
    }

    // コンフィグが変更された場合は、この関数を呼び込む。
    public void ReloadConfig()
    {
        ConstUpdateParam();
        // 最大化のサイズをリサイズ
        MaximumSize = new Size(Const.Window.WIDTH,Const.Window.HEIGHT);

        // フォームとコントローラの幅高さを再定義
        Width = Const.Window.WIDTH;
        Height = Const.Window.HEIGHT;
        drawImage_.Width = Const.Window.WIDTH;
        drawImage_.Height = Const.Window.HEIGHT;
    }

    // 読み込むScriptを変更する際は、この関数を呼び込む。
    // この関数は、ゲーム状態の有効。
    // 状態管理のPeekでScriptをリロードする。
    // ゲーム状態以外はこのメソッドを定義していない。
    // test用
    public void ReloadScript()
    {
        stateManage_.Peek().ReloadScript(Utilities.String.Script+"jamp_test.fnms");
    }

    // ゲームフォームが読み込まれたら自動一回だけで呼び出される。
    // ゲームフォーム自身を引数とするメソッドを含むものはここに記入する。
    // 状態管理に初期状態であるタイトル状態に遷移するようにする。
    private void GameForm_Load(object sender,EventArgs e)
    {
        // コントローラを追加。
        this.Controls.Add(drawImage_);
        // タイトル状態を状態管理にプッシュ
        stateManage_.Push(new TitleState(this,this.Width,this.Height));
    }

    // このフォーム内でマウスが動いたら毎回呼び出される関数。
    // UIの配置の座標取得等に用いる。
    public new void MouseMove(object sender,MouseEventArgs e)
    {
        Utilities.MousePoint.Instance.Set(e.X,e.Y);
        // Console.WriteLine(e.X+","+e.Y);
    }

    // リサイズ後の大きさを再定義する関数。
    private void ConstUpdateParam()
    {
        // 以下の再定義内容は以下を示している。
        // コンフィグの更新。
        // これを先に行わないと、後の処理に影響を与える。
        Config.Instance.Reload();
		// 実行中のアセンブリーを取得
        Assembly ass = Assembly.GetExecutingAssembly();
        Type[] typ = ass.GetTypes();
		// 名前空間ConstであるクラスはすべてUpdateParamを実行する。
        foreach(Type t in typ)
        {
			if(t.Namespace != null && t.Namespace.Equals("Const"))
			{
				t.InvokeMember(
					"UpdateParam",
					BindingFlags.InvokeMethod,
					null,
					null,
					new object[]{}
				);
			}
        }
    }
}
