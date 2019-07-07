using System;
using System.Windows.Forms;

public class Program
{
	public static void Main()
	{
		Utility.WriteStart();

		GameForm Form = new GameForm();
		Form.Show();

		int fps = 0;
		int oldtime = System.Environment.TickCount;

		while(Form.Created)
		{
			fps++;
			if(oldtime + 33 <= System.Environment.TickCount)
			{
				// Console.WriteLine(fps);
				oldtime = System.Environment.TickCount;
				fps = 0;
				Form.Update();
			}
			Application.DoEvents();
		}

		Utility.WriteEnd();
	}
}
