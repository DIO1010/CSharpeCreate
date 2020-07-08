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

#if DEBUG
    Debug.Items.Instance.Debug = true;
    Debug.Menu.Instance.Debug = true;
    Utilities.Logger.WriteLog = true;
#endif

    // コンソールウィンドウを表示
    if (Utilities.Logger.WriteLog) AllocConsole();

    Logger.Start();
    Logger.Message("itmes = " + Debug.Items.Instance.Debug.ToString() + ", menu = " + Debug.Menu.Instance.Debug.ToString());


    GameForm form = new GameForm();

    form.Show();

    int oldtime = System.Environment.TickCount;
    int wait = 1000 / 60;

    while (form.Created)
    {
      if (Environment.TickCount >= oldtime)
      {
        oldtime = Environment.TickCount;
        form.Update();
        Logger.Message(Environment.TickCount + " ? " + oldtime + wait );
        if (Environment.TickCount < oldtime + wait/*true*/)
        {
          form.Draw();
          oldtime += wait;
        }
        Debug.FrameRate.Instance.CalculationFPS();
      }
      Application.DoEvents();
    }

    Logger.End();
  }
}
