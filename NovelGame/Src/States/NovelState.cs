using System;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace  States
{
    public class NovelState : State
    {
        private  GameLayerManager GML_;
        private ScriptMachine scriptMachine_;
        private bool controlFlag_ = false;
        private bool isTransSetting_ = false;

        public NovelState(Form form,int width,int height)
        {
            GML_ = new GameLayerManager();
            form.KeyUp += new KeyEventHandler(this.OnKeyUp);
            Control[] con = form.Controls.Find("drawImage",true);
            con[0].MouseUp += new MouseEventHandler(this.MouseUp);

            scriptMachine_ = new ScriptMachine("test.fnms");
            Debug.Items.Instance.ParamAdd("ScriptMachine",scriptMachine_);
            Debug.Items.Instance.ParamAdd("KeybordKey",Utilities.Keybord.Instance);
        }

        public NovelState(Form form,int width,int height,string filename)
        {
            GML_ = new GameLayerManager();
            form.KeyUp += new KeyEventHandler(this.OnKeyUp);
            Control[] con = form.Controls.Find("drawImage",true);
            con[0].MouseUp += new MouseEventHandler(this.MouseUp);

            scriptMachine_ = new ScriptMachine(filename);
            Debug.Items.Instance.ParamAdd("ScriptMachine",scriptMachine_);
            Debug.Items.Instance.ParamAdd("Key",Utilities.Keybord.Instance);
        }

        public override void Update(StateManage SM, Form GF)
        {
            scriptMachine_.Execute(GML_);
            // test
            if(isTransSetting_)
            {
                isTransSetting_ = false;
                SM.Push(new SettingState(GF,Const.Window.WIDTH,Const.Window.HEIGHT));
                // SM.Pop();
            }
        }

        public override Bitmap GetDrawImage()
        {
            return GML_.GetDrawLayerImage();
        }

        // test
        public override void ReloadScript(string filename)
        {
            scriptMachine_ = new ScriptMachine(filename);
        }
        // test finish

        public void OnKeyUp(object sender,KeyEventArgs e)
        {
            if(!Control) return;
            string key = e.KeyCode.ToString();
            Utilities.Keybord.Instance.Key = key;
            switch(key)
            {
                case "Return":
                if(GML_.IsTextCountMax() && Utilities.ControlReturn.Instance.Flag)
                {
                    GML_.IsNextMessage = true;
                }
                else
                {
                    GML_.SetMessageTextIndexMax();
                }
                if(GML_.ContainsLayer("ChoiceLayer0"))
                {
                    Const.Choice.Enter();
                }
                break;
                case "Up":
                if(Debug.Menu.Instance.DebugMode)
                {
                    Debug.Menu.Instance.Up();
                }
                else if(GML_.ContainsLayer("ChoiceLayer0"))
                {
                    Const.Choice.Up();
                }
                break;
                case "Down":
                if(Debug.Menu.Instance.DebugMode)
                {
                    Debug.Menu.Instance.Down();
                }
                else if(GML_.ContainsLayer("ChoiceLayer0"))
                {
                    Const.Choice.Down();
                }
                break;
                case "S":
                if(Debug.Menu.Instance.DebugMode)
                {
                    Debug.Menu.Instance.Enter();
                }
                break;
                default:
                break;
            }

            if(e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                Debug.Menu.Instance.DebugMode = !Debug.Menu.Instance.DebugMode;
            }
        }

        public void MouseUp(object sender,MouseEventArgs e)
        {
            if(!Control) return;
            if(!(e.Button == MouseButtons.Left))return;
            Layers.ButtonLayer b = (Layers.ButtonLayer)GML_.SelectedButton();
            if(b == null) return;
            Type type = b.GetType();
            MethodInfo m = type.GetMethod(b.Method);
            if(m==null)return;
            object[] args = new object[]{null};
            m.Invoke(b,args);
            // Console.WriteLine(args[0]);
            // if(b.Method.Contains("back"))
            if(b.Method.Contains("setting")) // test
            {
                isTransSetting_ = (bool)args[0];
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