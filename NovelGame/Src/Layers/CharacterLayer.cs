using System;
using Utilities;
using System.Drawing;
using System.Collections.Generic;

namespace Layers
{
    public class CharacterLayer : Layer
    {
        private Bitmap image_;
        private Point point_;
        // private bool isReDraw_ = true;

        public CharacterLayer()
        {
            image_ = Const.Image.GetImage("Transparent");
            point_ = new Point(Const.Character.LEFT,Const.Character.TOP);
        }

        public CharacterLayer(int left,int top)
        {
            image_ = Const.Image.GetImage("Transparent");
            point_ = new Point(left,top);
        }

        public CharacterLayer(Queue<string> line)
        {
            int left = 0;
            int top = 0;

            while(line.Count > 0)
            {
                if(line.Peek().Contains("left"))
                {
                    left = Int32.Parse(GetNeedInfomation(line.Dequeue()));
                }
                else if(line.Peek().Contains("top"))
                {
                    top = Int32.Parse(GetNeedInfomation(line.Dequeue()));
                }
            }

            image_ = Const.Image.GetImage("Transparent");
            point_ = new Point(left,top);
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

        public override Point Point
        {
            get
            {
                return this.point_;
            }
            set
            {
                this.point_ = value;
                // int x = Const.Character.Left(point_.X);
                // int y = Const.Character.Top(point_.Y);
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

        public override string ToString()
        {
            return ("CharacterLayer:[(left,top):("+point_.X*Config.Instance.Width+","+point_.Y*Config.Instance.Height+")]");
        }

        public override void DrawLayer(Graphics g)
        {
            g.DrawImage(
                image_,
                point_.X*Config.Instance.Width,
                // Const.Character.TOP,
                point_.Y*Config.Instance.Height,
                Const.Character.WIDTH,
                Const.Character.HEIGHT
            );
        }
    }
}