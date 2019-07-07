using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;

public class NovelForm : Form{
	private StateManagement staMan;
	private DataStorage storage;
	private MenuStrip mainMenu;

	public NovelForm(){
		Width = 800;
		Height = 600;
		Text = "ノベルゲームテスト";
		Icon = new Icon(@"./Image/icon.ico");

		mainMenu = new MenuStrip();

		this.SuspendLayout();
		this.mainMenu.SuspendLayout();

		ToolStripMenuItem FileItem = new ToolStripMenuItem();
		FileItem.Text = "ファイル(&F)";
		this.mainMenu.Items.Add(FileItem);

		ToolStripMenuItem Exit = new ToolStripMenuItem();
		Exit.Text = "終了(&X)";
		Exit.ShortcutKeys = Keys.Control | Keys.X;
		Exit.ShowShortcutKeys = true;
		Exit.Click += Exit_Click;
		FileItem.DropDownItems.Add(Exit);

		this.Controls.Add(mainMenu);
		this.MainMenuStrip = this.mainMenu;

		this.mainMenu.ResumeLayout(false);
		this.mainMenu.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();

		storage = DataStorage.GetInstance;
		storage.PrintImageData();
		storage.PrintFontData();

		storage.Script = new Script(@"./Script/Script.fnms");

		staMan = new StateManagement();

		storage.WriteLog("NovelForm..ctor.Message:Complete!");
	}

	public void Show(){
		base.Show();
		storage.Form = this;
		staMan.Push(new NovelState());
		storage.WriteLog("NovelForm.Show.Message:Complete!");
	}

	public void Update(){
		staMan.UpDate();
	}

	public void Exit_Click(object sender,EventArgs e){
		DialogResult DR = MessageBox.Show("終了しますか？","確認",MessageBoxButtons.YesNo);

		if(DR == DialogResult.Yes){
			this.Dispose();
		}else if(DR == DialogResult.No){

		}
	}
}
