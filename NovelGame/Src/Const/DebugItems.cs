using System;
using Utilities;
using System.Drawing;

// UpdateParamはDebugMenuから先にする。

namespace Const
{
    public class DebugItems
    {
        private static int width_ = (int)(800*Config.Instance.Width);
        private static int fontSize_ = (int)(20*Config.Instance.Height);
        private static int height_ = (int)(FONT_SIZE+DebugMenu.ITEM_PADDING);
        private static int top_ = (int)(FONT_SIZE+DebugMenu.ITEM_PADDING);
        private static int left_ = 0;
        private static SolidBrush brushFont_ = new SolidBrush(Color.FromArgb(100,0,0,0));
        private static SolidBrush brushBack_ = new SolidBrush(Color.FromArgb(100,200,200,200));
        
        // public DebugItems()
        // {
        //     float t = 800*Config.Instance.Width;
        //     width_ = (int)t;

        //     t = 20*Config.Instance.Height;
        //     fontSize_ = (int)t;

        //     t = FONT_SIZE+DebugMenu.ITEM_PADDING;
        //     height_ = (int)t;

        //     t = FONT_SIZE+DebugMenu.ITEM_PADDING;
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

        public static string FONT_STYLE
        {
            get
            {
                return "MS UI Gothic";
            }
        }

        // 文字表示に問題が発生したら考える
        public static int FONT_SIZE
        {
            get
            {
                return fontSize_;
                // Utilities.Logger.Message("FontSize:"+n.ToString());
            }
        }


        public static SolidBrush BRUSH_BACK
        {
            get
            {
                return brushBack_;
            }
        }

        public static SolidBrush BRUSH_FONT
        {
            get
            {
                return brushFont_;
            }
        }

        public static void UpdateParam()
        {
            width_ = (int)(800*Config.Instance.Width);

            fontSize_ = (int)(20*Config.Instance.Height);
            
            height_ = (int)(FONT_SIZE+DebugMenu.ITEM_PADDING);
            
            top_ = (int)(FONT_SIZE+DebugMenu.ITEM_PADDING);
        }

    }
}