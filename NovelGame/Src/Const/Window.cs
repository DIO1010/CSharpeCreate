using System;
using Utilities;

namespace Const
{
    public class Window
    {
        private static int width_ = (int)(800*Config.Instance.Width);
        private static int height_ = (int)(600*Config.Instance.Height);

        public static int WIDTH
        {
            get
            {
                return width_;
            }
        }

        public static int HEIGHT
        {
            get
            {
                return height_;
            }
        }

        public static void UpdateParam()
        {
            width_ = (int)(800*Config.Instance.Width);

            height_ = (int)(600*Config.Instance.Height);
        }
    }
}