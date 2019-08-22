using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Utilities
{
    public class Format
    {
        public static Queue<Queue<string>> ScriptFormat(string[] rawLines)
        {
            Queue<Queue<string>> formatScript = new Queue<Queue<string>>();
            foreach(var rawLine in rawLines)
            {
                Queue<string> formatLine = new Queue<string>();

                string message = rawLine.Replace(" ","");

                if(message.IndexOf("\n") == 0)
                {
                    continue;
                }
                else if(message.IndexOf(";") == 0)
                {
                    formatLine.Enqueue("Comment");
                }
                else if(message.IndexOf("<") == 0)
                {
                    message = message.Replace("<","");
                    message = message.Replace(">","");

                    formatLine.Enqueue("Command");
                    string[] messageSplit = message.Split(',');
                    foreach(string str in messageSplit)
                    {
                        formatLine.Enqueue(str);
                        // Utilities.Logger.Message(str);
                    }
                }
                else if(message.IndexOf("*")== 0)
                {
                    formatLine.Enqueue("Label");
                    formatLine.Enqueue(message);
                }
                else
                {
                    formatLine.Enqueue("Message");
                    message = message.Replace("\n","");
                    message = message.Replace("]","]\n");
                    message = message.Replace("<r>","\n");
                    formatLine.Enqueue(message);
                }
                formatScript.Enqueue(formatLine);
            }

            return formatScript;
        }

        public static Queue<Queue<string>> XmlFormat(string[] rawLines)
        {
            Queue<Queue<string>> formatXml = new Queue<Queue<string>>();
            foreach(var rawLine in rawLines)
            {
                Queue<string> formatLine = new Queue<string>();

                string message = rawLine.Replace(" ","");
                message = message.Replace(":",",");

                if(message.IndexOf(";") == 0)
                {
                    formatLine.Enqueue("Comment");
                }
                else if(message.IndexOf("<") == 0)
                {
                    message = message.Replace("<","");
                    message = message.Replace(">","");

                    formatLine.Enqueue("Command");
                    string[] messageSplit = message.Split(',');
                    foreach(string str in messageSplit)
                    {
                        formatLine.Enqueue(str);
                    }
                }
                formatXml.Enqueue(formatLine);
                // Logger.Message(formatLine.Peek());
                // Logger.Message(rawLine);
            }

            return formatXml;
        }
    }
}