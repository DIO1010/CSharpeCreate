using Const;
using System;
using Utilities;
using System.Drawing;

namespace Layers
{
    public class ChoiceLayer : Layer
    {
        private Bitmap onImage_;
        private Bitmap offImage_;
        private bool isDraw_;
        private bool isSelect_;
        private string value_;
        private string target_;
        private int id_;
        // private bool isReDraw_ = true;

        public ChoiceLayer(int id)
        {
            onImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            Graphics g = Graphics.FromImage(onImage_);
            g.FillRectangle(Choice.ON_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            offImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            g = Graphics.FromImage(offImage_);
            g.FillRectangle(Choice.OFF_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            isDraw_ = true;
            isSelect_ = false;

            value_ = "Null";
        }

        public ChoiceLayer(int x,int y,int id)
        {
            onImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            Graphics g = Graphics.FromImage(onImage_);
            g.FillRectangle(Choice.ON_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            offImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            g = Graphics.FromImage(offImage_);
            g.FillRectangle(Choice.OFF_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            isDraw_ = true;
            isSelect_ = false;
        }

        public ChoiceLayer(int x,int y,int id,string value)
        {
            onImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            Graphics g = Graphics.FromImage(onImage_);
            g.FillRectangle(Choice.ON_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            offImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            g = Graphics.FromImage(offImage_);
            g.FillRectangle(Choice.OFF_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            isDraw_ = true;
            isSelect_ = false;

            id_ = id;

            value_ = value;
        }

        public ChoiceLayer(int x,int y,int id,string target,string value)
        {
            onImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            Graphics g = Graphics.FromImage(onImage_);
            g.FillRectangle(Choice.ON_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            offImage_ = new Bitmap(Choice.WIDTH,Choice.HEIGHT);
            g = Graphics.FromImage(offImage_);
            g.FillRectangle(Choice.OFF_BRUSH,0,0,Choice.WIDTH,Choice.HEIGHT);

            isDraw_ = true;
            isSelect_ = false;

            id_ = id;

            target_ = target;

            value_ = value;
        }

        public bool IsDraw
        {
            get
            {
                return isDraw_;
            }
            set
            {
                isDraw_ = value;
            }
        }

        public bool IsSelect
        {
            get
            {
                return isSelect_;
            }
            set
            {
                isSelect_ = value;
            }
        }

        public override string Target
        {
            get
            {
                return target_;
            }
        }

        public override void DrawLayer(Graphics g)
        {
            if(!IsDraw) return;

            if(MouseHover())Const.Choice.INDEX = id_;

            if(id_ == Const.Choice.INDEX)
            {
                g.DrawImage(
                    onImage_,
                    Choice.LEFT,
                    Choice.TOP*(id_+1),
                    Choice.WIDTH,
                    Choice.HEIGHT
                );
            }
            else
            {
                g.DrawImage(
                    offImage_,
                    Choice.LEFT,
                    Choice.TOP*(id_+1),
                    Choice.WIDTH,
                    Choice.HEIGHT
                );
            }

            g.DrawString(
                value_,
                new Font(
                    DebugItems.FONT_STYLE, 
                    DebugItems.FONT_SIZE
                ),
                Choice.FONT_BRUSH,
                Choice.LEFT + Choice.FONT_PADDING,
                Choice.TOP * (id_ + 1) + Choice.FONT_PADDING
            );
        }

        public override string ToString()
        {
            return ("ChoiceLayer:[IsDraw:"+IsDraw+"],[IsSelect:"+IsSelect+"],[Id:"+id_+"]");
        }

        private bool MouseHover()
        {
            int x = Utilities.MousePoint.Instance.X;
            int y = Utilities.MousePoint.Instance.Y;
            if(x < Choice.LEFT) return false;
            if(Choice.LEFT+Choice.WIDTH < x) return false;
            if(y < Choice.TOP*(id_+1)) return false;
            if(Choice.TOP*(id_+1)+Choice.HEIGHT < y) return false;
            return true;
        }
    }
}