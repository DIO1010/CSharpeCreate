using System;
using System.Drawing;
using System.Windows.Forms;

public class GameForm : Form
{
    private PictureBox drawImage;
    private State currentState;

    private enum Const
    {
        WIDTH = 800,
        HEIGHT = 600,
        StartLeft = 0,
        StartTop = 0
    };

    public GameForm()
    {
        Width = (int)Const.WIDTH;
        Height = (int)Const.HEIGHT;
        Text = "タイトル(仮)";
        this.Load += new EventHandler(this.GameForm_Load);

        drawImage = Utility.PictureBoxInit();
    }

    public new void Show()
    {
        base.Show();
    }

    public new void Update()
    {
        drawImage.BackgroundImage = currentState.GetDrawImage();
    }

    private void GameForm_Load(object sender,EventArgs e)
    {
        currentState = new NovelState(this,this.Width,this.Height);
        this.Controls.Add(drawImage);
    }
}
