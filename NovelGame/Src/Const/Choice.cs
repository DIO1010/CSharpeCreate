using System;
using Utilities;
using System.Drawing;

namespace Const
{
    public class Choice
    {
        private static int height_ = (int)(50*Config.Instance.Height);
        private static int width_ = (int)(700*Config.Instance.Width);
        private static int left_ = (int)(50*Config.Instance.Width);
        private static int top_ = (int)(85*Config.Instance.Height);
        private static int fontSize_ = (int)(20*Config.Instance.Height);
        private static int fontPadding_ = (int)(10*Config.Instance.Height);
        private static SolidBrush onBrush_ = new SolidBrush(Color.FromArgb(200,255,  0,255));
        private static SolidBrush offBrush_ = new SolidBrush(Color.FromArgb(200, 0,200,255));
        private static SolidBrush fontBrush_ = new SolidBrush(Color.FromArgb(200, 0,  0,  0));
        private static bool IsSelect_ = false;
        private static int count_ = 0;
        private static int index_ = 0;

        // public Choice()
        // {
        //     float t = 50*Config.Instance.Height;
        //     height_ = (int)t;

        //     t = 700*Config.Instance.Width;
        //     width_ = (int)t;

        //     t = 85*Config.Instance.Height;
        //     top_ = (int)t;

        //     t = 50*Config.Instance.Width;
        //     left_ = (int)t;

        //     t = 20*Config.Instance.Height;
        //     fontSize_ = (int)t;

        //     t = 10*Config.Instance.Height;
        //     fontPadding_ = (int)t;
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

        public static SolidBrush ON_BRUSH
        {
            get
            {
                return onBrush_;
            }
        }

        public static SolidBrush OFF_BRUSH
        {
            get
            {
                return offBrush_;
            }
        }

        public static SolidBrush FONT_BRUSH
        {
            get
            {
                return fontBrush_;
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

        public static int Count
        {
            get
            {
                return count_;
            }
            set
            {
                count_ = value;
            }
        }

        public static int INDEX
        {
            get
            {
                return index_;
            }
            set
            {
                index_ = value;
            }
        }

        public static int FONT_PADDING
        {
            get
            {
                return fontPadding_;
            }
        }

        public static bool IsSelect
        {
            get
            {
                return IsSelect_;
            }
            set
            {
                IsSelect_ = value;
            }
        }

        public static void Up()
        {
            index_ = (count_ + --index_) % count_;
            Utilities.MousePoint.Instance.CursorSet(LEFT+WIDTH-20,TOP*(INDEX+1)+HEIGHT-20);
            // Console.WriteLine(index_);
        }

        public static void Down()
        {
            index_ = ++index_ % count_;
            Utilities.MousePoint.Instance.CursorSet(LEFT+WIDTH-20,TOP*(INDEX+1)+HEIGHT-20);
        }

        public static void Enter()
        {
            IsSelect = true;
        }

        public static void UpdateParam()
        {
            height_ = (int)(50*Config.Instance.Height);

            width_ = (int)(700*Config.Instance.Width);
            
            left_ = (int)(50*Config.Instance.Width);
            
            top_ = (int)(85*Config.Instance.Height);
            
            fontSize_ = (int)(20*Config.Instance.Height);
            
            fontPadding_ = (int)(10*Config.Instance.Height);
        }

    }
}