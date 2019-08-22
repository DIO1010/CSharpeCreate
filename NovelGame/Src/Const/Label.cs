using System;
using Utilities;

namespace Const
{
    public class Label
    {
        private static string name_ = "LabelLayer";
        private static int width_ = (int)(800*Config.Instance.Width);
        private static int height_ = (int)(600*Config.Instance.Height);
        private static int fontSize_ = (int)(20*Config.Instance.Height);

        // public Label()
        // {
        //     float t = 800*Config.Instance.Width;
        //     width_ = (int)t;

        //     t = 600*Config.Instance.Height;
        //     height_ = (int)t;

        //     t = 20*Config.Instance.Height;
        //     fontSize_ = (int)t;
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
            width_ = (int)(800*Config.Instance.Width);

            height_ = (int)(600*Config.Instance.Height);
            
            fontSize_ = (int)(20*Config.Instance.Height);
        }

    }
}