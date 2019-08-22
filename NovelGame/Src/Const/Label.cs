using System;
using Utilities;

namespace Const
{
    public class Label
    {
        private static string name_ = "LabelLayer";
        private static int    width_    = 800;
        private static int    height_   = 600;
        private static int    fontSize_ = 20;


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
            float t = 800*Config.Instance.Width;
            width_ = (int)t;

            t = 600*Config.Instance.Height;
            height_ = (int)t;

            t = 20*Config.Instance.Height;
            fontSize_ = (int)t;
        }
    }
}