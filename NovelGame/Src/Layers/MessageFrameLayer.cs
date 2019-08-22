using System;
using Utilities;
using System.Drawing;
using System.Collections.Generic;

namespace Layers
{
    public class MessageFrameLayer : Layer
    {
        private Bitmap image_;
        // private Point point_;
        // private bool isReDraw_ = true;

        public MessageFrameLayer()
        {
            image_ = Const.Image.GetImage("Transparent");
            // point_ = new Point(Const.MessageFrame.LEFT,Const.MessageFrame.TOP);
        }

        public MessageFrameLayer(int left,int top)
        {
            image_ = Const.Image.GetImage("Transparent");
            // point_ = new Point(Const.MessageFrame.Left(left),Const.MessageFrame.Top(top));
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

        public override void DrawLayer(Graphics g)
        {
            g.DrawImage(
                this.image_,
                Const.MessageFrame.LEFT,
                Const.MessageFrame.TOP,
                Const.MessageFrame.WIDTH,
                Const.MessageFrame.HEIGHT
            );
        }

        public override string ToString()
        {
            return System.String.Format(
                "MessageFrameLayer(left,top):({0,3},{1,3})]",
                Const.MessageFrame.LEFT,
                Const.MessageFrame.TOP
            );
        }
    }
}