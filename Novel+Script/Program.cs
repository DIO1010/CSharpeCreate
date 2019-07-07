using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;

public class Program{
	private static DataStorage Storage;

	public static void Main(){
		Storage = DataStorage.GetInstance;
		Storage.WriteLog("Program:Start!");

		int oldtime = System.Environment.TickCount;

		NovelForm Form = new NovelForm();
		Form.Show();

		Storage.WriteLog("Program:LoadTime = " + (System.Environment.TickCount - oldtime));

		int fps = 0;
		while(Form.Created){
			fps++;
			if(oldtime + 33 <= System.Environment.TickCount){
				//Console.WriteLine(fps.ToString());
				// Storage.WriteLog("Program:FPS = " + fps);
				oldtime = System.Environment.TickCount;
				fps = 0;
				Form.Update();
			}
			Application.DoEvents();
		}
		Storage.WriteLog("Program:End!");
	}
}
