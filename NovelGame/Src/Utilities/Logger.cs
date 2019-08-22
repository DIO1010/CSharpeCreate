using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public class Logger
    {
        private static bool isLogger_ = false;

        public static bool WriteLog
        {
            get
            {
                return isLogger_;
            }
            set
            {
                isLogger_ = value;
            }
        }

        public static void Start(){
            Write(Utilities.String.Start());
        }

        public static void End(){
            Write(Utilities.String.End());
        }

        public static void Message(string message){
            Write(Utilities.String.Message(message));
        }
        
        public static void Warning(string message)
        {
            Write(Utilities.String.Warning(message));
        }

        public static void Error(string message)
        {
            Write(Utilities.String.Error(message));
        }

        public static void ErrorArgs(string errorArgs)
        {
            Write(Utilities.String.Error("引数："+errorArgs));
        }

        public static void ErrorKey(string errorKey)
        {
            Write(Utilities.String.Error("キー："+errorKey));
        }
        public static void Change(string message)
        {
            Write(Utilities.String.Change("場所："+message));
        }


        private static void Write(string message)
        {
            Console.WriteLine(message);
            if(WriteLog)
            {
                string directory = "Log/"+Utilities.String.Now("yyyy_MM_dd");
                if(!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                StreamWriter sw = WriteInit(directory+"/");
                sw.Write(message);
                sw.Close();
            }
        }

        private static StreamWriter WriteInit(string directory)
        {
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
            return new StreamWriter(Utilities.String.LogFilename(directory),true,encode);
        }
    }
}
