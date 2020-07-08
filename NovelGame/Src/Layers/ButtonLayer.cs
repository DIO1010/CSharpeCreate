using System;
using Utilities;
using System.Drawing;
using System.Collections.Generic;

namespace Layers
{
    public class ButtonLayer : Layer
    {
        private Point point_;
        private Dictionary<string,Bitmap> images_;
        private bool isSelect_ = false;
        private string method_ = ""; 

        public ButtonLayer(int left,int top, string storage)
        {
            images_ = new Dictionary<string, Bitmap>();
            images_.Add("on",Const.Image.GetImage(storage+"_on"));
            images_.Add("off",Const.Image.GetImage(storage+"_off"));
            point_ = new Point(left,top);
            method_ = "none";
        }

        public ButtonLayer(int left,int top, string storage,string method)
        {
            images_ = new Dictionary<string, Bitmap>();
            images_.Add("on",Const.Image.GetImage(storage+"_on"));
            images_.Add("off",Const.Image.GetImage(storage+"_off"));
            point_ = new Point(left,top);
            if(method != ""){
                method_ = method;
            }
            else
            {
                method_ = "none";
            }
        }

        public ButtonLayer(Queue<string> line)
        {
            images_ = new Dictionary<string, Bitmap>();

            int left = 0;
            int top = 0;
            string filename = "Transparent";
            string method = "none";

            while(line.Count > 0)
            {
                if(line.Peek().Contains("left"))
                {
                    left = Int32.Parse(GetNeedInformation(line.Dequeue()));
                }
                else if(line.Peek().Contains("top"))
                {
                    top = Int32.Parse(GetNeedInformation(line.Dequeue()));
                }
                else if(line.Peek().Contains("storage"))
                {
                    filename = GetNeedInformation(line.Dequeue());
                }
                else if(line.Peek().Contains("method"))
                {
                    method = GetNeedInformation(line.Dequeue());
                }
            }

            images_.Add("on",Const.Image.GetImage(filename+"_on"));
            images_.Add("off",Const.Image.GetImage(filename+"_off"));
            point_ = new Point(left,top);
            method_ = method;
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
            }
        }

        public string Method
        {
            get
            {
                return method_;
            }
        }

        public bool isSelect
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

        public override string ToString()
        {
            return ("ButtonLayer:[Method:"+method_+"]");
        }

        public override void DrawLayer(Graphics g)
        {
            if(MouseHover())
            {
                DrawImage(g,"on");
                isSelect_ = true;
            }
            else
            {
                DrawImage(g,"off");
                isSelect_ = false;
            }
        }

        public void none(ref bool a)
        {
            Utilities.Logger.Message("");
            a = false;
            return;
        }

        public void gamestart(ref bool isTransGameState)
        {
            // if(!s.GetType().Name.Contains("TitleState")) return;
            // States.TitleState t = (States.TitleState)s;
            // t.IsTransGameState = true;
            Utilities.Logger.Message("OK!");
            isTransGameState = true;
            return;
        }

        public void setting(ref bool isTransSetting)
        {
            Utilities.Logger.Message("OK!");
            isTransSetting = true;
            return;
        }

        public void back(ref bool isTransBack)
        {
            Utilities.Logger.Message("OK!");
            isTransBack = true;
            return;
        }

        private bool MouseHover()
        {
            int x = Utilities.MousePoint.Instance.X;
            int y = Utilities.MousePoint.Instance.Y;
            if(x < (int)point_.X*Config.Instance.Width) return false;
            if((point_.X+images_["on"].Width)*Config.Instance.Width < x) return false;
            if(y < point_.Y*Config.Instance.Height) return false;
            if((point_.Y+images_["on"].Height)*Config.Instance.Height < y) return false;
            return true;
        }

        private void DrawImage(Graphics g,string key)
        {
            if(images_.ContainsKey(key))
            {
                g.DrawImage(
                    images_[key],
                    point_.X*Config.Instance.Width,
                    point_.Y*Config.Instance.Height,
                    images_[key].Width*Config.Instance.Width,
                    images_[key].Height*Config.Instance.Height
                );
            }
            else
            {
                Utilities.Logger.ErrorKey(key);
            }
        }
    }
}