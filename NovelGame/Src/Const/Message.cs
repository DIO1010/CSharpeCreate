using System;
using Utilities;

// MessageFrameを先にUpdateParamする。

namespace Const
{
    public class Message
    {
        private static string name_     = "MessageTextLayer";
        private static int    width_    = 600;
        private static int    height_   = 250;
        private static int    left_     = 0;
        private static int    top_      = 410;
        private static int    fontSize_ = 20;

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

        // public static int Left(int x)
        // {
        //     float n = x*Config.Instance.Width;
        //     return (int)n;
        // }

        // public static int Top(int y)
        // {
        //     float n = y*Config.Instance.Width;
        //     return (int)n;
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

        public static string FONT_STYLE
        {
            get
            {
                return "ＭＳ ゴシック";
            }
        }

        public static int FONT_SIZE
        {
            get
            {
                return fontSize_;
            }
        }

        public static void UpdateParam()
        {
            float t = 600*Config.Instance.Width;
            width_ = (int)t;

            t = 250*Config.Instance.Height;
            height_ = (int)t;

            t = (MessageFrame.LEFT+150)*Config.Instance.Width;
            left_ = (int)t;

            t = 410*Config.Instance.Height;
            top_ = (int)t;

            t = 20*Config.Instance.Height;
            fontSize_ = (int)t;
        }
    }
}