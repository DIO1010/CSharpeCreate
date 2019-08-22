using System;
using Utilities;

namespace Const
{
    public class Window
    {
        // private static int currentTime_ = System.Environment.TickCount;
        private static int width_ = 800;
        private static int height_ = 600;

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
            float t = 800*Config.Instance.Width;
            width_ = (int)t;

            t = 600*Config.Instance.Height;
            height_ = (int)t;
        }

        // public static int FPS
        // {
        //     get
        //     {
        //         int fps = System.Environment.TickCount - currentTime_;
        //         currentTime_ = System.Environment.TickCount;
        //         return fps;
        //     }
        // }
    }
}