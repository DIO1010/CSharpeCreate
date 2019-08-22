using System;
using System.IO;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace  States
{
    public class SettingState : State
    {
        private SettingLayerManager SLM_;
        private bool isTransBack_;
        private bool controlFlag_ = false;
        private bool modified_;

        public SettingState(Form form,int width,int height)
        {
            SLM_ = new SettingLayerManager();
            isTransBack_ = false;

            form.KeyDown += new KeyEventHandler(this.OnKeyDown);
            Control[] con = form.Controls.Find("drawImage",true);
            con[0].MouseUp += new MouseEventHandler(this.MouseUp);
            con[0].MouseDown += new MouseEventHandler(this.MouseDown);
            con[0].MouseMove += new MouseEventHandler(this.MouseMove);
        }

        public override void Update(StateManage SM, Form GM)
        {
            // scriptMachine_.Execute(SLM_);
            if(isTransBack_)
            {
                if(modified_)
                {
                    string filename = "./Config/config.conf";
                    string[] strs = File.ReadAllLines(filename);
                    if(Const.CheckBoxList.Information != null)
                    {
                        strs[0] = Const.CheckBoxList.Information[0];
                        strs[1] = Const.CheckBoxList.Information[1];
                    }
                    if(Const.Slider.Information != null)
                    {
                        strs[2] = Const.Slider.Information;
                    }
                    File.WriteAllLines(filename,strs,System.Text.Encoding.GetEncoding("UTF-8"));
                    ((GameForm)GM).ReloadConfig();
                    // Console.WriteLine("SettingState.Update modified_");
                }
                isTransBack_ = false;
                // Control = false;
                SM.Pop();
            }
        }

        public override Bitmap GetDrawImage()
        {
            // scriptMachine_.Execute(SLM_);
            // return SLM_.GetDrawLayerImage();
            return SLM_.GetDrawLayerImage();
        }

        public void OnKeyDown(object sender,KeyEventArgs e)
        {
            if(!Control) return;
            string key = e.KeyCode.ToString();
            switch(key)
            {
                case "Return":
                // isTransBack_ = true;
                break;
                default:
                break;
            }
        }

        // 準TODO
        // 引数参照渡しでisTransBackを考えている。
        // それをメソッドの帰り値で変更できるように。
        public void MouseUp(object sender,MouseEventArgs e)
        {
            if(!Control) return;
            if(!(e.Button == MouseButtons.Left))return;
            if(SLM_.SelectedCheckBoxList() && !modified_) modified_ = true;
            if(SLM_.SelectedSlider() && !modified_) modified_ = true;
            // Console.WriteLine("SettingState.MouseUp:"+SLM_.SelectedCheckBoxList());
            Layers.ButtonLayer b = (Layers.ButtonLayer)SLM_.SelectedButton();
            if(b == null) return;
            Type type = b.GetType();
            MethodInfo m = type.GetMethod(b.Method);
            if(m==null)return;
            object[] args = new object[]{null};
            m.Invoke(b,args);
            // Console.WriteLine(args[0]);
            if(b.Method.Contains("back"))
            {
                isTransBack_ = (bool)args[0];
            }
        }

        public void MouseMove(object sender,MouseEventArgs e)
        {
            if(!Control) return;
            if(!(e.Button == MouseButtons.Left))return;
            SLM_.SelectedSlider();
        }

        public void MouseDown(object sender,MouseEventArgs e)
        {
            if(!Control) return;
            if(!(e.Button == MouseButtons.Left))return;
            // SLM_.SelectedSlider();
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