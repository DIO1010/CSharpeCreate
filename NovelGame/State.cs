using System;
using System.Drawing;
using System.Windows.Forms;

public abstract class State
{
    public virtual Panel DrawDesign()
    {
        return new Panel();
    }
}

public class NovelState : State
{
    private PictureBox image;
    private Label message;

    public NovelState()
    {
        
    }

    public override Panel DrawDesign()
    {
        Panel panel = Utility.PanelInit();

    }
}
