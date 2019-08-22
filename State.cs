using System;
using System.IO;

public class AddState
{
	public static void Main(string[] args)
	{
		if(args.Length > 0)
		{
			string text = 
				"using System;\n" + 
				"using Utilities;\n" +
				"using System.Drawing;\n"+
				"using System.Reflection;\n"+
				"using System.Collections;\n"+
				"using System.Windows.Forms;\n"+
				"\n"+
				"namespace  States\n"+
				"{\n"+
				"	public class "+args[0]+"State : State\n"+
				"	{\n"+
				"		private "+args[0]+"LayerManager "+args[0].Substring(0,1)+"LM_;\n"+
				"		private bool controlFlag_ = false;\n"+
				"\n"+
				"		public "+args[0]+"State(Form form,int width,int height)\n"+
				"		{\n"+
				"			"+args[0].Substring(0,1)+"LM_ = new "+args[0]+"LayerManager();\n"+
				"\n"+
				"			form.KeyDown += new KeyEventHandler(this.OnKeyDown);\n"+
				"			Control[] con = form.Controls.Find(\"drawImage\",true);\n"+
				"			con[0].MouseUp += new MouseEventHandler(this.MouseUp);\n"+
				"		}\n"+
				"\n"+
				"		public override void Update(StateManage SM, Form GF)\n"+
				"		{\n"+
				"\n"+
				"		}\n"+
				"\n"+
				"		public override Bitmap GetDrawImage()\n"+
				"		{\n"+
				"			return "+args[0].Substring(0,1)+"LM_.GetDrawLayerImage();\n"+
				"		}\n"+
				"\n"+
				"		public void OnKeyDown(object sender,KeyEventArgs e)\n"+
				"		{\n"+
				"			if(!Control) return;\n"+
				"			string key = e.KeyCode.ToString();\n"+
				"			switch(key)\n"+
				"			{\n"+
				"				case \"Return\":\n"+
				"				break;\n"+
				"				default:\n"+
				"				break;\n"+
				"			}\n"+
				"		}\n"+
				"\n"+
				"		public void MouseUp(object sender,MouseEventArgs e)\n"+
				"		{\n"+
				"			if(!Control) return;\n"+
				"		}\n"+
				"\n"+
				"		public override bool Control\n"+
				"		{\n"+
				"			get\n"+
				"			{\n"+
				"				return controlFlag_;\n"+
				"			}\n"+
				"			set\n"+
				"			{\n"+
				"				controlFlag_ = value;\n"+
				"			}\n"+
				"		}\n"+
				"	}\n"+
				"}\n"
			;
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
            StreamWriter sw = new StreamWriter("./NovelGame/States/"+args[0]+"State.cs",true,encode);;
            sw.Write(text);
            sw.Close();

			text = 
				"using Xml;\n"+
				"using Const;\n"+
				"using System;\n"+
				"using Layers;\n"+
				"using Utilities;\n"+
				"using System.Drawing;\n"+
				"using System.Reflection;\n"+
				"using System.Windows.Forms;\n"+
				"using System.Collections.Generic;\n"+
				"\n"+
				"public class "+args[0]+"LayerManager\n"+
				"{\n"+
				"	private Dictionary<string, Layer> layers_ = new Dictionary<string,Layer>();\n"+
				"\n"+
				"	public "+args[0]+"LayerManager()\n"+
				"	{\n"+
				"		XmlMachine x = new XmlMachine(\"./Xml/"+args[0]+".fnmx\");\n"+
				"		layers_ = x.GetXml();\n"+
				"	}\n"+
				"\n"+
				"	public Bitmap GetDrawLayerImage()\n"+
				"	{\n"+
				"		Bitmap canvas = new Bitmap(Const.Window.WIDTH,Const.Window.HEIGHT);\n"+
				"		Graphics g = Graphics.FromImage(canvas);\n"+
				"		g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;\n"+
				"\n"+
				"		foreach (KeyValuePair<string, Layer> keyValuePair in layers_)\n"+
				"		{\n"+
				"			keyValuePair.Value.DrawLayer(g);\n"+
				"		}\n"+
				"\n"+
				"		return canvas;\n"+
				"	}\n"+
				"\n"+
				"	public Layer SelectedButton()\n"+
				"	{\n"+
				"		foreach (KeyValuePair<string, Layer> keyValuePair in layers_)\n"+
				"		{\n"+
				"			if(keyValuePair.Value.GetType().Name.Contains(\"ButtonLayer\"))\n"+
				"			{\n"+
				"				ButtonLayer b = (ButtonLayer)keyValuePair.Value;\n"+
				"				if(b.isSelect)\n"+
				"				{\n"+
				"					return keyValuePair.Value;\n"+
				"				}\n"+
				"			}\n"+
				"		}\n"+
				"		return null;\n"+
				"	}\n"+
				"}\n"
			;
			sw = new StreamWriter("./NovelGame/LayerManager/"+args[0]+"LayerManager.cs",true,encode);;
            sw.Write(text);
            sw.Close();
			
			text = "<Background:name=BackgroundLayer0>";
			sw = new StreamWriter("./NovelGame/Xml/"+args[0]+".fnmx",true,encode);;
            sw.Write(text);
            sw.Close();
		}
	}
}
