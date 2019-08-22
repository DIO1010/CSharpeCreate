using System;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace States
{
    public abstract class State
    {
        private bool controlFlag_ = false;
        public virtual Bitmap GetDrawImage()
        {
            return Const.Image.GetImage("Transparent");
        }
        
        public virtual void Update(StateManage SM, Form GF)
        {
            return;
        }

        public virtual void ReloadScript(string filename)
        {
            return;
        }
        public virtual bool Control
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