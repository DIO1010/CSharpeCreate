using System;
using Utilities;
using System.Drawing;

// UpdateParamはこれから先にする。

namespace Const
{
    public class DebugMenu
    {
        private static int width_ = (int)(300*Config.Instance.Width); 
        private static int height_ = (int)(600*Config.Instance.Height); 
        private static int left_ = (int)(500*Config.Instance.Width); 
        private static int top_ = (int)(0*Config.Instance.Height); 
        private static int padding_ = (int)(10*Config.Instance.Height); 
        private static int itemWidth_ = (int)(WIDTH);
        private static int itemHeight_ = (int)(24*Config.Instance.Height);
        private static int itemLeft_ = (int)(LEFT+PADDING);
        private static int itemTop_ = (int)((FONT_SIZE+ITEM_PADDING)+1*Config.Instance.Height);
        private static int itemPadding_ = (int)(6*Config.Instance.Height);
        private static int fontSize_ = (int)(20*Config.Instance.Height);
        private static int checkSize_ = (int)(12*Config.Instance.Height);
        private static SolidBrush brushBack_ = new SolidBrush(Color.FromArgb(255,  0,  0,  0));
        private static SolidBrush brushFalse_  = new SolidBrush(Color.FromArgb(100,200,200,200));
        private static SolidBrush brushSelect_ = new SolidBrush(Color.FromArgb(100,  0,255,  0));
        private static SolidBrush brushTrue_ = new SolidBrush(Color.FromArgb(100,255,  0,255));

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
            width_ = (int)(300*Config.Instance.Width); 
            height_ = (int)(600*Config.Instance.Height); 
            left_ = (int)(500*Config.Instance.Width); 
            top_ = (int)(0*Config.Instance.Height); 
            padding_ = (int)(10*Config.Instance.Height); 
            itemWidth_ = (int)(WIDTH);
            itemHeight_ = (int)(24*Config.Instance.Height);
            itemLeft_ = (int)(LEFT+PADDING);
            itemTop_ = (int)((FONT_SIZE+ITEM_PADDING)+1*Config.Instance.Height);
            itemPadding_ = (int)(6*Config.Instance.Height);
            fontSize_ = (int)(20*Config.Instance.Height);
            checkSize_ = (int)(12*Config.Instance.Height);
        }

    }
}