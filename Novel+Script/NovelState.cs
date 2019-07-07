using System;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

public class NovelState : State{
	private Panel panel;
	private Bitmap currentImage;
	private DataStorage storage;
	private PictureBox background;
	private PictureBox textFrame;
	private PictureBox character;
	private Character[] characters;
	private Label speechLabel;
	private ArrayList choiceLabel;
	private Dictionary<int,string> choiceLabelToString;
	private Script scriptData;
	private int choiceLabelIndex;
	private bool isOperate;
	private bool isFirst;
	private bool isChoise;

	public NovelState(){
		storage = DataStorage.GetInstance;
		storage.WriteLog("NovelState..ctor.Message:Form = "+storage.Form);
		storage.Form.KeyDown += new KeyEventHandler(this.OnKeyDown);

		panel = new Panel();
		panel.Dock = DockStyle.Fill;
		panel.Parent = storage.Form;

		currentImage = new Bitmap(panel.Width, panel.Height);
		panel.DrawToBitmap(currentImage, new Rectangle(0, 0, panel.Width, panel.Height));


		this.scriptData = storage.Script;
		storage.WriteLog("NovelState..ctor.Message:ScriptData = "+scriptData);

		background = new PictureBox();
		background.Location = new Point(0,0);
		background.Size = new Size(800,600);
		background.Parent = panel;
		background.BackColor = Color.Transparent;
		background.Image = null;

		character = new PictureBox();
		character.Location = new Point(0,0);
		character.Size = new Size(800,600);
		character.Parent = background;
		character.BackColor = Color.Transparent;
		character.Image = null;

		characters = new Character[3];
		for(int i = 0;i < characters.Length;i++){
			characters[i] = new Character(storage.GetImage("Transparent.png"),0,0);
		}

		textFrame = new PictureBox();
		textFrame.Location = new Point(0,0);
		textFrame.Size = new Size(800,600);
		textFrame.Parent = character;
		textFrame.BackColor = Color.Transparent;

		speechLabel = new Label();
		speechLabel.Location = new Point(140,400);
		speechLabel.Size = new Size(800,600);
		speechLabel.Parent = textFrame;
		speechLabel.BackColor = Color.Transparent;

		speechLabel.Font = storage.GetFont("genkai-mincho.ttf");

		choiceLabel = new ArrayList();

		choiceLabelToString = new Dictionary<int,string>();

		storage.Form.Controls.Add(panel);
		panel.Controls.Add(background);
		background.Controls.Add(character);
		character.Controls.Add(textFrame);
		textFrame.Controls.Add(speechLabel);

		isOperate = false;
		isFirst = true;
		isChoise = false;
		choiceLabelIndex = 0;

		storage.WriteLog("NovelState..ctor.Message:Complete!");
	}

	public void Update(){
		if(isFirst){
			isFirst = false;
			storage.State = this;
		}
		scriptData.Execute();
		isOperate = false;
	}

	public PictureBox Background{
		set{
			this.background = value;
		}
		get{
			return this.background;
		}
	}

	public PictureBox TextFrame{
		set{
			this.textFrame = value;
		}
		get{
			return this.textFrame;
		}
	}

	public ArrayList ChoiceLabel{
		get{
			return this.choiceLabel;
		}
	}

	public string ChoiceIndexToString{
		set{
			choiceLabelToString.Add(ChoiceLabel.Count,value);
		}
		get{
			return this.choiceLabelToString[choiceLabelIndex];
		}
	}

	public bool IsChoice{
		set{
			this.isChoise = value;
		}
		get{
			return this.isChoise;
		}
	}

	public bool GetIsKeyDown{
		get{
			return this.isOperate;
		}
	}

	public bool GetIsOK{
		get{
			return this.isOperate;
		}
	}


	public void SetTransition(Image value){
		this.background.Image = value;
	}


	public void SetSpeechLabel(string value){
		storage.WriteLog("NovelState.SetSpeechLabel.Message:Execute!");
		this.speechLabel.Text = value;
	}

	public void SetCharacter(Image Img,int y,int x,int Type){
		storage.WriteLog("NovelState.SetCharacter.Message:Execute!");
		Bitmap Canvas = new Bitmap(storage.Form.Width,storage.Form.Height);
		Graphics g = Graphics.FromImage(Canvas);
		//Console.WriteLine("NovelState.Type:{0}",Type);
		characters[Type].Image = Img;
		characters[Type].X = x;
		characters[Type].Y = y;
		for(int i = 0;i < characters.Length;i++){
			g.DrawImage(characters[i].Image,characters[i].X,characters[i].Y,characters[i].Image.Width,characters[i].Image.Height);
		}
		character.Image = Canvas;
	}

	// 整形は向こうに投げる
	public void SetChoiceLabel(Label value){
		Label Label = value;
		Label.MouseEnter += new EventHandler(this.Label_MouseEnter);
		Label.MouseLeave += new EventHandler(this.Label_MouseLeave);
		choiceLabel.Add(Label);

		storage.WriteLog("NovelState.SetChoiceLabel:Execute!");

		textFrame.Controls.Add((Label)choiceLabel[choiceLabel.Count-1]);
	}

	public void SetChoiceLabelClear(){
		for(int i = 0;i < choiceLabel.Count;i++){
			textFrame.Controls.Remove((Label)choiceLabel[i]);
		}
		this.choiceLabel.Clear();
		this.choiceLabelToString.Clear();
	}

	public void OnKeyDown(object sender, KeyEventArgs e)
	{
		string key = e.KeyCode.ToString();
		string modifier = e.Modifiers.ToString();
		Point MousePoint;
		switch(key){
			case "Return":
			isOperate = true;
			break;
			case "Up":
			if(isChoise){
				choiceLabelIndex = (choiceLabel.Count + choiceLabelIndex - 1) % choiceLabel.Count;
				MousePoint = storage.Form.PointToScreen(new Point(725,100 * choiceLabelIndex + 75));
				System.Windows.Forms.Cursor.Position = MousePoint;
				storage.WriteLog("NovelState.OnKeyDown:ChoiceLabelIndex = "+choiceLabelIndex);
			}
			break;
			case "Down":
			if(isChoise){
				choiceLabelIndex = (choiceLabelIndex + 1) % choiceLabel.Count;
				MousePoint = storage.Form.PointToScreen(new Point(725,100 * choiceLabelIndex + 75));
				System.Windows.Forms.Cursor.Position = MousePoint;
				storage.WriteLog("NovelState.OnKeyDown:ChoiceLabelIndex = "+choiceLabelIndex);
			}
			break;
			default:
			storage.WriteLog("NovelState.OnKeyDown:Key = "+key);
			break;
		}
	}

	public void Label_MouseEnter(object sender,EventArgs e){
		Label Label = (Label)sender;
		Label.BackColor = Color.FromArgb(200,255,0,255);
		int Index = (int)(Label.Top / 100);
		choiceLabelIndex = Index;
	}

	public void Label_MouseLeave(object sender,EventArgs e){
		Label Label = (Label)sender;
		Label.BackColor = Color.FromArgb(200,0,200,255);
	}
}
