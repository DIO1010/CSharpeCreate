using System;
using Utilities;
using System.Drawing;

namespace Const
{
    public class Button
    {
        private static string name_ = "ButtonLayer";

        public static string NAME
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
            }
        }


        public static void UpdateParam()
        {
            return;
        }
    }
}