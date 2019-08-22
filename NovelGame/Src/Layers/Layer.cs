using System;
using System.Drawing;


namespace Layers{
    public abstract class Layer
    {
        private Bitmap image_ = Const.Image.GetImage("Transparent");
        private Point point_ = new Point(0,0);
        private Size size_ = new Size(0,0);
        private string str_ = "";
        private bool isReDraw_ = false;

        public virtual Bitmap Image
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


        public virtual Point Point
        {
            get{
                return this.point_;
            }
            set
            {
                this.Point = value;
            }
        }

        public virtual Size Size
        {
            get
            {
                return this.size_;
            }
            set
            {
                this.size_ = value;
            }
        }

        public virtual string MessageText
        {
            get
            {
                return this.str_;
            }
            set
            {
                this.str_ = value;
            }
        }

        public virtual string Target
        {
            get
            {
                return this.str_;
            }
            set
            {
                this.str_ = value;
            }
        }

        public virtual bool IsReDraw
        {
            get
            {
                return isReDraw_;
            }
            set
            {
                isReDraw_ = value;
            }
        }

        public virtual void SetTextIndexMax(){}

        public virtual void DrawLayer(Graphics g){}

        public virtual bool IsTextCountMax(){return true;}
        protected string GetNeedInfomation(string rawStr)
        {
            rawStr = rawStr.Replace("\"","");
            return rawStr.Substring(rawStr.IndexOf("=")+1);
        }
    }
}