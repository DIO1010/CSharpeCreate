using System;
using Utilities;
using System.Drawing;

// UpdateParamはこれから先にする。

namespace Const
{
    public class DebugMenu
    {
        private static int        width_       = 300; 
        private static int        height_      = 600; 
        private static int        left_        = 500; 
        private static int        top_         = 0; 
        private static int        padding_     = 10; 
        private static int        itemWidth_   = 300;
        private static int        itemHeight_  = 24;
        private static int        itemLeft_    = 510;
        private static int        itemTop_     = 0;
        private static int        itemPadding_ = 6;
        private static int        fontSize_    = 20;
        private static int        checkSize_   = 12;
        private static SolidBrush brushBack_   = new SolidBrush(Color.FromArgb(255,  0,  0,  0));
        private static SolidBrush brushFalse_  = new SolidBrush(Color.FromArgb(100,200,200,200));
        private static SolidBrush brushSelect_ = new SolidBrush(Color.FromArgb(100,  0,255,  0));
        private static SolidBrush brushTrue_   = new SolidBrush(Color.FromArgb(100,255,  0,255));
        // private static int itemWidth_;
        // private static int itemHeight_;
        // private static int itemLeft_;
        // private static int itemTop_;
        // private static int itemPadding_;

        // public DebugMenu()
        // {
        //     itemWidth_ = 375;
        //     itemHeight_ = 31;
        //     itemLeft_ = 637;
        //     itemTop_ = 33;
        //     itemPadding_ = 7;
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

        public static int PADDING
        {
            get
            {
                return padding_;
            }
        }

        public static int ITEM_WIDTH
        {
            get
            {
                return itemWidth_;
            }
        }

        public static int ITEM_HEIGHT
        {
            get
            {
                return itemHeight_;
            }
        }

        public static int ITEM_LEFT
        {
            get
            {
                return itemLeft_;
            }
        }

        public static int ITEM_TOP
        {
            get
            {
                // float n = Debug.Menu.Instance.Index*;
                // Console.WriteLine((DebugMenu.FONT_SIZE+DebugMenu.ITEM_PADDING)+1*Config.Instance.Height);
                float n = Debug.Menu.Instance.Index*(FONT_SIZE+ITEM_PADDING)+1*Config.Instance.Height;
                return (int)n;
            }
        }

        public static int ITEM_PADDING
        {
            get
            {
                return itemPadding_;
            }
        }

        public static int CHECK_SIZE
        {
            get
            {
                return checkSize_;
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
            }
        }


        public static SolidBrush BRUSH_BACK
        {
            get
            {
                return brushBack_;
            }
        }

        public static SolidBrush BRUSH_SELECT
        {
            get
            {
                return brushSelect_;
            }
        }

        public static SolidBrush BRUSH_FALSE
        {
            get
            {
                return brushFalse_;
            }
        }

        public static SolidBrush BRUSH_TRUE
        {
            get
            {
                return brushTrue_;
            }
        }

        public static void UpdateParam()
        {
            float t = 300*Config.Instance.Width;
            width_ = (int)t;

            t = 600*Config.Instance.Height;
            height_ = (int)t;

            t = 500*Config.Instance.Width;
            left_ = (int)t;

            t = 0*Config.Instance.Height;
            top_ = (int)t;

            t = 10*Config.Instance.Height;
            padding_ = (int)t;

            t = WIDTH;
            itemWidth_ = (int)t;

            t = 24*Config.Instance.Height;
            itemHeight_ = (int)t;

            t = LEFT+PADDING;
            itemLeft_ = (int)t;

            t = (FONT_SIZE+ITEM_PADDING)+1*Config.Instance.Height;
            itemTop_ = (int)t;

            t = 6*Config.Instance.Height;
            itemPadding_ = (int)t;

            t = 20*Config.Instance.Height;
            fontSize_ = (int)t;

            t = 12*Config.Instance.Height;
            checkSize_ = (int)t;
        }
    }
}