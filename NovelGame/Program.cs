using Const;
using System;
using Utilities;
using System.Reflection;
using System.Windows.Forms;

public class Program
{
	// Consoleウィンドウを表示させる
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    private static extern bool AllocConsole();

	public static void Main(string[] args)
	{
		Config.Instance.Reload();

		if(args.Length > 0)
        {
            Debug.Items.Instance.Debug = args[0].Equals("-d");
            Debug.Menu.Instance.Debug = args[0].Equals("-d");
			Utilities.Logger.WriteLog = args[0].Equals("-l");
        }
		if(args.Length > 1)
		{
			Utilities.Logger.WriteLog = args[1].Equals("-l");
		}

		// コンソールウィンドウを表示
		if(Utilities.Logger.WriteLog) AllocConsole();

		Logger.Start();
		Logger.Message("itmes = "+Debug.Items.Instance.Debug.ToString()+", menu = "+Debug.Menu.Instance.Debug.ToString());


		GameForm form = new GameForm();
		
		form.Show();

		float oldtime = (float)System.Environment.TickCount;
		// float wait = 1000 / 30;
		float wait = 1000 / 60;

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
					// Console.WriteLine("Draw!");
					form.Draw();
					// form.Update();
					oldtime += wait;
				}
				Debug.FrameRate.Instance.CalculationFPS();
			}
			Application.DoEvents();
		}

		Logger.End();
	}
}
