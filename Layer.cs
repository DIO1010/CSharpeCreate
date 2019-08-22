using System;
using System.IO;

public class Layer
{
	public static void Main(string[] args)
	{
		if(args.Length > 0)
		{
			string text = 
				"using System;\n"+
				"using Utilities;\n"+
				"using System.Drawing;\n"+
				"\n"+
				"namespace Const\n"+
				"{\n"+
				"	public class "+args[0]+"\n"+
				"	{\n"+
				"		private static string name_ = \""+args[0]+"Layer\";\n"+
				"		private static int height_ = 600;\n"+
				"		private static int width_ = 800;\n"+
				"		private static int left_ = 0;\n"+
				"		private static int top_ = 0;\n"+
				"       private static int fontSize_ = 10;\n"+
				"		private static SolidBrush brush_ = new SolidBrush(Color.FromArgb(0,0,0,0));\n"+
				"\n"+
				"		public static int HEIGHT\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return height_;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public static int WIDTH\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return width_;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public static int TOP\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return top_;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public static int LEFT\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return left_;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public static string NAME\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return name_;\n"+
				"			}\n"+
				"			set\n"+
				"			{\n"+
				"				name_ = value;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public static SolidBrush BRUSH_BACK\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return brush_;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public static string FONT_STYLE\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return \"MS UI Gothic\";\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		// 文字表示に問題が発生したら考える\n"+
				"		public static int FONT_SIZE\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return fontSize_;\n"+
				"			}\n"+
				"		}\n"+
				"		public static void UpdateParam()\n"+
				"		{\n"+
				"			float t = 600*Config.Instance.Height;\n"+
				"			height_ = (int)t;\n"+
				"\n"+
				"			t = 20*Config.Instance.Height;\n"+
            	"			fontSize_ = (int)t;\n"+
				"\n"+
				"			t = 800*Config.Instance.Width;\n"+
				"			width_  = (int)t;\n"+
				"\n"+
				"			t = 0  *Config.Instance.Height;\n"+
				"			left_   = (int)t;\n"+
				"			\n"+
				"			t = 0  *Config.Instance.Width;\n"+
				"			top_    = (int)t;\n"+
				"		}\n"+
				"	}\n"+
				"}\n"
			;
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
            StreamWriter sw = new StreamWriter("./NovelGame/Const/"+args[0]+".cs",true,encode);;
            sw.Write(text);
            sw.Close();

			text = 
			"using System;\n"+
			"using System.Drawing;\n"+
			"\n"+
			"namespace Layers{\n"+
			"	public class "+args[0]+"Layer : Layer\n"+
			"	{\n"+
			"		private Bitmap image_;\n"+
			"\n"+
			"		public "+args[0]+"Layer()\n"+
			"		{\n"+
			"		}\n"+
			"\n"+
			"		public override Bitmap Image\n"+
			"		{\n"+
			"			get\n"+
			"			{\n"+
			"				return this.image_;\n"+
			"			}\n"+
			"			set\n"+
			"			{\n"+
			"				this.image_ = value;\n"+
			"			}\n"+
			"		}\n"+
			"\n"+
			"		public override void DrawLayer(Graphics g)\n"+
			"		{\n"+
			"			g.DrawImage(image_,Const."+args[0]+".LEFT,Const."+args[0]+".TOP,Const."+args[0]+".WIDTH,Const."+args[0]+".HEIGHT);\n"+
			"		}\n"+
			"	}\n"+
			"}\n"
			;
            sw = new StreamWriter("./NovelGame/Layers/"+args[0]+"Layer.cs",true,encode);;
            sw.Write(text);
            sw.Close();
		}
	}
}
