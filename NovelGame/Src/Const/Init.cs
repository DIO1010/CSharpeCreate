using System;
using Utilities;

namespace Const
{
    public class Init
    {
        private static int width_ = (int)(800*Config.Instance.Width);
        private static int height_ = (int)(600*Config.Instance.Height);
        private static int left_ = 0;
        private static int top_ = 0;
        // public Init()
        // {
        //     float t = 800*Config.Instance.Width;
        //     width_ = (int)t;

        //     t = 600*Config.Instance.Height;
        //     height_ = (int)t;

        //     t = 0*Config.Instance.Width;
        //     left_ = (int)t;
            
        //     t = 0*Config.Instance.Height;
        //     top_ = (int)t;
        // }
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
            width_ = (int)(800*Config.Instance.Width);
            
            height_ = (int)(600*Config.Instance.Height);
        }

    }
}