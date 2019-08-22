using Const;
using System;
using Utilities;
using System.Reflection;
using System.Windows.Forms;

public class Program
{
	public static void Main(string[] args)
	{
		Logger.Start();

		if(args.Length > 0)
        {
            Debug.Items.Instance.Debug = args[0].Equals("-d");
            Debug.Menu.Instance.Debug = args[0].Equals("-d");
			Logger.Message("itmes = "+Debug.Items.Instance.Debug.ToString()+", menu = "+Debug.Menu.Instance.Debug.ToString());
        }

		InitParam();

		GameForm form = new GameForm();
		
		form.Show();

		float oldtime = (float)System.Environment.TickCount;
		float wait = 1000 / 30;
		// float wait = 1000 / 60;

		while(form.Created)
		{
			// if(System.Environment.TickCount - oldtime > 66)
			if((float)System.Environment.TickCount>=oldtime)
			{
				// Console.WriteLine(System.Environment.TickCount - oldtime);
				oldtime = System.Environment.TickCount;
				form.Update();
				// form.Draw();
				// Console.WriteLine("Upadate!");
				if((float)System.Environment.TickCount<oldtime+wait){
				// 	// Console.WriteLine("Draw!");
					form.Draw();
				// 	form.Update();
					oldtime += wait;
				}
				Debug.FrameRate.Instance.CalculationFPS();
				// Console.WriteLine(Debug.FrameRate.Instance.FPS);
			}
			Application.DoEvents();
		}

		Logger.End();
	}

	public static void InitParam()
	{
		Config.Instance.Reload();
		// 実行中のアセンブリーを取得
        Assembly ass = Assembly.GetExecutingAssembly();
        Type[] typ = ass.GetTypes();
		// 名前空間ConstであるクラスはすべてUpdateParamを実行する。
        foreach(Type t in typ)
        {
			if(t.Namespace != null && t.Namespace.Equals("Const"))
			{
				t.InvokeMember(
					"UpdateParam",
					BindingFlags.InvokeMethod,
					null,
					null,
					new object[]{}
				);
			}
        }
	}
}
