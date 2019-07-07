using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

public class Utility
{
    public static void WriteStart(){
        StreamWriter sw = WriteInit();
        string write = "*--------------------\"";
        write += System.DateTime.Now.ToString("HH:mm:ss");
        write += " Start!\"--------------------*\n";
        sw.Write(write);
        sw.Close();
    }
    public static void WriteLog(string Message){
        StreamWriter sw = WriteInit();
        string write = "[" + System.DateTime.Now.ToString("HH:mm:ss") + "]";
        write += Message+"\n";
        sw.Write(write);
        sw.Close();
    }
    public static void WriteEnd(){
        StreamWriter sw = WriteInit();
        string write = "*--------------------\"";
        write += System.DateTime.Now.ToString("HH:mm:ss");
        write += "   End!\"--------------------*\n";
        sw.Write(write);
        sw.Close();
    }

    private static StreamWriter WriteInit()
    {
        System.Text.Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
        return new StreamWriter(System.DateTime.Now.ToString("yyyy_MM_dd") + "_log.txt",true,encode);
    }

    public static Panel PanelInit(bool isVisible)
    {
        Panel panel = new Panel();
        panel.Location = new Point((int)Const.StartLeft,(int)Const.StartTop);
        panel.Size = new Size((int)Const.WIDTH,(int)Const.HEIGHT);
        panel.Visible = isVisible;

        return panel;
    }
}
