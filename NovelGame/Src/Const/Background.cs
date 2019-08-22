using System;
using Utilities;

namespace Const
{
    public class Background
    {
        private static string name_ = "BackgroundLayer";
        private static int height_ = (int)(600*Config.Instance.Height);
        private static int width_ = (int)(800*Config.Instance.Width);
        private static int left_ = 0;
        private static int top_ = 0;

        public static int HEIGHT
        {
            get
            {
                return height_;
            }
        }

        public static int WIDTH
        {
            get
            {
                return width_;
            }
        }

        public static int TOP
        {
            get
            {
                return top_;
            }
        }

        public static int LEFT
        {
            get
            {
                return left_;
            }
        }

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
            height_ = (int)(600*Config.Instance.Height);

            width_  = (int)(800*Config.Instance.Width);
        }
    }
}