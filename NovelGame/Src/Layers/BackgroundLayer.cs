using System;
using System.Drawing;

namespace Layers{
    public class BackgroundLayer : Layer
    {
        private Bitmap image_;
        // private Point point_;
        // private Size size_;
        // private bool isReDraw_;

        public BackgroundLayer()
        {
            image_ = Const.Image.GetImage("Transparent");
            // isReDraw_ = true;
            Utilities.Logger.Message("width:"+Const.Background.WIDTH.ToString()+",height:"+Const.Background.HEIGHT.ToString());
        }

        public override Bitmap Image
        {
            get
            {
                return this.image_;
            }
            set
            {
                this.image_ = value;
            }
        }
        // public override bool IsReDraw
        // {
        //     get
        //     {
        //         return isReDraw_;
        //     }
        //     set
        //     {
        //         isReDraw_ = value;
        //     }
        // }

        // public override Point Point
        // {
        //     get
        //     {
        //         return this.point_;
        //     }
        //     set
        //     {
        //         this.point_ = value;
        //     }
        // }

        // public override Size Size
        // {
        //     get
        //     {
        //         return this.size_;
        //     }
        //     set
        //     {
        //         this.size_ = value;
        //     }
        // }

        public override void DrawLayer(Graphics g)
        {
            g.DrawImage(image_,Const.Background.LEFT,Const.Background.TOP,Const.Background.WIDTH,Const.Background.HEIGHT);
        }
    }
}