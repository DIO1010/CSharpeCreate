using System;
using Utilities;

namespace Const
{
    public class Character
    {
        private static string name_ = "CharacterLayer";
        private static int width_ = 400;
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

        // public static int Width(int w)
        // {
        //     width_ = w;
        //     float n = w*Config.Instance.Width;
        //     return n;
        // }
        
        // public static int Height(int h)
        // {
        //     height_ = h;
        //     float n = h*Config.Instance.Width;
        //     return n;
        // }

        public static int Left(int x)
        {
            left_ = x;
            float n = x*Config.Instance.Width;
            return (int)n;
        }

        public static int Top(int y)
        {
            top_ = y;
            float n = y*Config.Instance.Width;
            return (int)n;
        }

        public static void UpdateParam()
        {
            float t = 400*Config.Instance.Width;
            width_ = (int)t;

            t = 600*Config.Instance.Height;
            height_ = (int)t;

            t = 0*Config.Instance.Height;
            top_ = (int)t;
            left_ = (int)t;
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
    }
}