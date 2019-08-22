using System;
using Utilities;
using System.Drawing;

namespace Layers
{
    public class MessageTextLayer : Layer
    {
        private string text_;
        private int textCount_;
        private int oldtime_msec_;
        private int wait_msec_;
        // private bool isReDraw_ = true;


        public MessageTextLayer()
        {
            text_ = " ";
            textCount_ = 0;
            wait_msec_ = 90;
        }

        public override string MessageText
        {
            get
            {
                return this.text_;
            }
            set
            {
                this.textCount_ = 0;
                this.text_ = value;
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

        public override void DrawLayer(Graphics g)
        {

            // Bitmap canvas = new Bitmap(Const.Message.WIDTH,Const.Message.HEIGHT);
            // Graphics myG = Graphics.FromImage(canvas);

            if(System.Environment.TickCount>=oldtime_msec_){
                oldtime_msec_ = System.Environment.TickCount;
                if(System.Environment.TickCount<oldtime_msec_+wait_msec_){
                    oldtime_msec_ += wait_msec_;
                    textCount_ += (int)Config.Instance.TextSpeed;
                }
            }

            if(this.textCount_ >= this.text_.Length)
            {
                textCount_ = this.text_.Length;
            }
            
            g.DrawString(
                this.text_.Substring(0,textCount_),
                new Font(
                    Const.Message.FONT_STYLE,
                    Const.Message.FONT_SIZE
                ),
                Brushes.Black,
                new RectangleF(
                    Const.Message.LEFT ,
                    Const.Message.TOP  ,
                    Const.Message.WIDTH,
                    Const.Message.HEIGHT
                )
            );
        }

        public override void SetTextIndexMax()
        {
            this.textCount_ = this.text_.Length;
        }

        public override bool IsTextCountMax()
        {
            return this.textCount_ == this.text_.Length;
        }

        public override string ToString()
        {
            return System.String.Format(
                "Message:[TextIndex:{0,2}],[(left,top):({1,2},{2,2})]",
                textCount_,
                Const.Message.LEFT,
                Const.Message.TOP
            );
        }
    }
}

