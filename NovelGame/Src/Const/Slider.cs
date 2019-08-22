using System;
using Utilities;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace Const
{
    public class Slider
    {
        public static string name_ = "SliderLayer";
        public static int fontSize_ = (int)(20*Config.Instance.Height);
        private static SolidBrush brush_ = new SolidBrush(Color.FromArgb(255,0,0,0));
        private static string information_;

        // public Slider()
        // {
        //     string filename = "./Config/config.conf";
		// 	string[] strs = File.ReadAllLines(filename);
		// 	information_ = strs[Utilities.Config.TEXT_SPEED_INFO];
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

        public static SolidBrush BRUSH
        {
            get
            {
                return brush_;
            }
        }

        public static string Information
        {
            get
            {
                return information_;
            }
        }

        public static void UpdateInformation(string str)
        {
            information_ = str;
        }

        public static void UpdateParam()
        {
            fontSize_ = (int)(20*Config.Instance.Height);

            string filename = "./Config/config.conf";
			string[] strs = File.ReadAllLines(filename);
			information_ = strs[Utilities.Config.TEXT_SPEED_INFO];
        }
    }
}