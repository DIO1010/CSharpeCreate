using System;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public class Initialization
    {
        public static Panel InitPanel()
        {
            Panel panel = new Panel();
            panel.Location = new Point(Const.Init.LEFT,Const.Init.TOP);
            panel.Size = new Size(Const.Init.WIDTH,Const.Init.HEIGHT);

            return panel;
        }

         public static PictureBox InitPictureBox()
        {
            PictureBox imageBox = new PictureBox();
            imageBox.Location = new Point(Const.Init.LEFT,Const.Init.TOP);
            imageBox.Size = new Size(Const.Init.WIDTH,Const.Init.HEIGHT);
            imageBox.Name = "drawImage";

            return imageBox;
        }
    }
}