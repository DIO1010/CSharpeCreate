using System;
using System.IO;
using Utilities;
using System.Drawing;

namespace Const
{
	public class CheckBoxList
	{
		private static string name_ = "CheckBoxListLayer";
		private static int padding_ = (int)(15*Config.Instance.Height);
		private static int fontSize_ = (int)(20*Config.Instance.Height);
		private static string[] information_;
		private static SolidBrush brush_ = new SolidBrush(Color.FromArgb(255,0,0,0));

		// public CheckBoxList()
		// {
		// 	string filename = "./Config/config.conf";
		// 	string[] strs = File.ReadAllLines(filename);
		// 	information_ = new string[]
		// 		{
		// 			strs[Utilities.Config.WIDTH_INFO],
		// 			strs[Utilities.Config.HEIGHT_INFO]
		// 		};

		// 	float t = 20*Config.Instance.Height;
		// 	fontSize_ = (int)t;

		// 	t = 15*Config.Instance.Height;
		// 	padding_ = (int)t;

		// 	Console.WriteLine("CheckBox.ctor OK!");
		// }

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
			string filename = "./Config/config.conf";
			string[] strs = File.ReadAllLines(filename);
			information_ = new string[]
				{
					strs[Utilities.Config.WIDTH_INFO],
					strs[Utilities.Config.HEIGHT_INFO]
				};
				
				padding_ = (int)(15*Config.Instance.Height);
				
				fontSize_ = (int)(20*Config.Instance.Height);
		}
	}
}
