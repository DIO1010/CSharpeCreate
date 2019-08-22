using System;
using System.IO;
using Utilities;
using System.Drawing;

namespace Const
{
	public class CheckBoxList
	{
		private static string name_ = "CheckBoxListLayer";
		private static int height_ = 600;
		private static int width_ = 800;
		private static int left_ = 0;
		private static int top_ = 0;
		private static int padding_ = 15;
		private static int fontSize_ = 20;
		// private static string[] information_ = new string[2];
		private static string[] information_;
		private static SolidBrush brush_ = new SolidBrush(Color.FromArgb(255,0,0,0));

		public CheckBoxList()
		{
			string filename = "./Config/config.conf";
			string[] strs = File.ReadAllLines(filename);
			information_ = new string[]
				{
					strs[Utilities.Config.WIDTH_INFO],
					strs[Utilities.Config.HEIGHT_INFO]
				};
		}

		public static int HEIGHT
		{
			get
			{
				return height_;
			}
		}

		public static int WIDTH
		{
			get
			{
				return width_;
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

		public static int Padding{
			get
			{
				return padding_;
			}
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

		public static SolidBrush BRUSH
		{
			get
			{
				return brush_;
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

		public static string[] Information
		{
			get
			{
				return information_;
			}
		}

		public static void UpdateInformation(string[] strs)
		{
			information_ = strs;
		}

		public static void UpdateParam()
		{
			float t = 600*Config.Instance.Height;
			height_ = (int)t;

			t = 20*Config.Instance.Height;
			fontSize_ = (int)t;

			t = 800*Config.Instance.Width;
			width_  = (int)t;

			t = 0  *Config.Instance.Height;
			left_   = (int)t;
			
			t = 0  *Config.Instance.Width;
			top_    = (int)t;

			string filename = "./Config/config.conf";
			string[] strs = File.ReadAllLines(filename);
			information_ = new string[]
				{
					strs[Utilities.Config.WIDTH_INFO],
					strs[Utilities.Config.HEIGHT_INFO]
				};
		}
	}
}
