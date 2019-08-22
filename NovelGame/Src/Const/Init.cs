using System;
using Utilities;

namespace Const
{
    public class Init
    {
        private static int width_ = 800;
        private static int height_ = 600;
        private static int left_ = 0;
        private static int top_ = 0;
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

        public static int LEFT
        {
            get
            {
                return left_;
            }
        }

        public static int TOP
        {
            get
            {
                return top_;
            }
        }

        public static void UpdateParam()
        {
            float t = 800*Config.Instance.Width;
            width_ = (int)t;

            t = 600*Config.Instance.Height;
            height_ = (int)t;

            t = 0*Config.Instance.Width;
            left_ = (int)t;
            
            t = 0*Config.Instance.Height;
            top_ = (int)t;
        }
    }
}