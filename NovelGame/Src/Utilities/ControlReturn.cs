using System;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public sealed class ControlReturn
    {
        private static ControlReturn myself_ = new ControlReturn();
        private static bool isControl_;

        public static ControlReturn Instance
        {
            get
            {
                return myself_;
            }
        }

        public bool Flag
        {
            get
            {
                return isControl_;
            }
            set
            {
                isControl_ = value;
            }
        }
    }
}