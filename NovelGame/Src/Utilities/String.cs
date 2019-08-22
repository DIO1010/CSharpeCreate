using System;
using System.Diagnostics;

namespace Utilities
{
    public class String
    // public sealed class String
    {
        // private static String myself_ = new Items();
        private const int nFrame_Base_ = 4;
        private const int nFrame_Change_ = 5;
        private static string startTime_ = Now("HH-mm-ss");

        public static string Start()
        {
            string write = Program("Start");
            return write;
        }

        public static string End()
        {
            string write = Program("End");
            return write;
        }

        public static string Message(string message)
        {
            return Format(SetBrackets("Message"),nFrame_Base_)+message+"\n";
        }

        public static string Error(string message)
        {
            return Format(SetBrackets("Error  "),nFrame_Base_+1)+"不正です。"+message+"\n";
        }

        public static string Warning(string message)
        {
            return Format(SetBrackets("Warning"),nFrame_Base_+1)+"警告です。"+message+"\n";
        }

        public static string Change(string message)
        {
            return Format(SetBrackets("Change "),nFrame_Change_)+"変更しました。"+message+"\n";
        }

        public static string Image
        {
            get
            {
                return "Image/";
            }
        }

        public static string Font
        {
            get
            {
                return "Font/";
            }
        }
        
        public static string Script
        {
            get
            {
                return "Script/";
            }
        }

        public static string LogFilename(string directory)
        {
            return directory+startTime_+".log";
        }

        private static string Format(string message,int nFrame)
        {
            string write = SetBrackets(Now("HH:mm:ss"));
            write += message;
            write += Caller(nFrame);
            return write;
        }

        private static string Program(string message)
        {
            string write = SetBrackets(Now("HH:mm:ss"));
            write += SetBrackets("Message");
            write += "Program " + message + "\n";
            return write;
        }
        
        private static string Caller(int nFrame)
        {
            return SetBrackets(ClassName(nFrame)+"."+MethodName(nFrame));
        }

        private static string ClassName(int nFrame)
        {
            StackFrame sf = new StackFrame(nFrame);
            return sf.GetMethod().ReflectedType.FullName;
        }

        private static string MethodName(int nFrame)
        {
            StackFrame sf = new StackFrame(nFrame);
            return sf.GetMethod().Name;
        }

        public static string Now(string format)
        {
            return System.DateTime.Now.ToString(format);
        }

        private static string SetBrackets(string message)
        {
            return "["+message+"]";
        }
    }
}