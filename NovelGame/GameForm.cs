using System;
using System.Drawing;
using System.Windows.Forms;

public class GameForm : Form
{
    private Panel prePanel;
    private Panel backPanel;
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

        prePanel = Utility.PanelInit(false);
        backPanel = Utility.PanelInit(true);
    }

    public new void Show()
    {
        base.Show();
    }

    public new void Update()
    {
    }

    private void GameForm_Load(object sender,EventArgs e)
    {
    }
}
