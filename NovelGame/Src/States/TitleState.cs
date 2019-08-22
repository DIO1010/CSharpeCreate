using System;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace  States
{
    public class TitleState : State
    {
        private TitleLayerManager TLM_;
        private bool isTransGameState_;
        private bool isTransSettingState_;
        private bool controlFlag_ = false;

        public TitleState(Form form,int width,int height)
        {
            TLM_ = new TitleLayerManager();
            isTransGameState_ = false;
            isTransSettingState_ = false;

            form.KeyDown += new KeyEventHandler(this.OnKeyDown);
            Control[] con = form.Controls.Find("drawImage",true);
            con[0].MouseUp += new MouseEventHandler(this.MouseUp);
        }

        public override void Update(StateManage SM, Form GF)
        {
            // scriptMachine_.Execute(TLM_);
            if(isTransGameState_)
            {
                isTransGameState_ = false;
                // Control = false;
                SM.Push(new NovelState(GF,Const.Window.WIDTH,Const.Window.HEIGHT,"Script/start.fnms"));
            }
            else if(isTransSettingState_)
            {
                isTransSettingState_ = false;
                // Control = false;
                SM.Push(new SettingState(GF,Const.Window.WIDTH,Const.Window.HEIGHT));
            }
        }

        public override Bitmap GetDrawImage()
        {
            // scriptMachine_.Execute(TLM_);
            // return TLM_.GetDrawLayerImage();
            return TLM_.GetDrawLayerImage();
        }

        public void OnKeyDown(object sender,KeyEventArgs e)
        {
            if(!Control) return;
            string key = e.KeyCode.ToString();
            switch(key)
            {
                case "Return":
                // isTransGameState_ = true;
                break;
                default:
                break;
            }
        }

        public void MouseUp(object sender,MouseEventArgs e)
        {
            if(!Control) return;
            if(!(e.Button == MouseButtons.Left))return;
            Layers.ButtonLayer b = (Layers.ButtonLayer)TLM_.SelectedButton();
            if(b == null) return;
            Type type = b.GetType();
            MethodInfo m = type.GetMethod(b.Method);
            if(m==null)return;
            object[] args = new object[]{null};
            m.Invoke(b,args);
            // Console.WriteLine(args[0]);
            if(b.Method.Contains("gamestart"))
            {
                isTransGameState_ = (bool)args[0];
            }
            else if(b.Method.Contains("setting"))
            {
                isTransSettingState_ = (bool)args[0];
            }
        }

        public override bool Control
        {
            get
            {
                return controlFlag_;
            }
            set
            {
                controlFlag_ = value;
            }
        }
    }
}