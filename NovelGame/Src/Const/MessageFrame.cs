using System;
using Utilities;

// こちらを先にUpadateParamする。

namespace Const
{
    public class MessageFrame
    {
        private static string name_   = "MessageFrameLayer";
        private static int width_   = 768;
        private static int height_  = 261;
        private static int left_    = 10;
        private static int top_     = 300;

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

        // public static int Left(int x)
        // {
        //     left_ = x;
        //     float n = x*Config.Instance.Width;
        //     return n;
        // }

        // public static int Top(int y)
        // {
        //     top_ = y;
        //     float n = y*Config.Instance.Width;
        //     return n;
        // }

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
            float t = 768*Config.Instance.Width;
            width_ = (int)t;

            t = 261*Config.Instance.Height;
            height_ = (int)t;

            t = 10*Config.Instance.Width;
            left_ = (int)t;

            t = 300*Config.Instance.Height;
            top_ = (int)t;
        }
    }
}