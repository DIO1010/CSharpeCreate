using System;
using Commands;
using Utilities;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

public class ScriptMachine
{
    private Dictionary<string,Queue<Command>> scriptBody_;
    private string currentLabel_;

    public ScriptMachine(string filename)
    {
        Reload(filename);
    }

    public void Execute(GameLayerManager GML)
    {
        // ここでScriptに応じた処理を書く
        if(scriptBody_[currentLabel_].Count > 0)
        {
            // bool flag = scriptBody_[currentLabel_].Peek().Execute(GML,this);
            // if(flag)
            if(scriptBody_[currentLabel_].Peek().Execute(GML,this))
            {
                Utilities.Logger.Message(currentLabel_+":"+scriptBody_[currentLabel_].Dequeue().ToString());
            }
        }
        else
        {
            // Console.WriteLine("Finish");
        }
    }

    public void Reload(string filename)
    {
        Utilities.Logger.Message(filename+"をロードしました。");
        scriptBody_ = new Dictionary<string,Queue<Command>>();
        currentLabel_ = "*start";
        scriptBody_.Add(currentLabel_,new Queue<Command>());

        string[] Lines;
        try
        {
            Lines = File.ReadAllLines(filename);
        }
        catch(Exception e)
        {
            Lines = new string[1]{"ScriptMachine..ctor:File Not Found Exception!"};
            Logger.Error("File Not Found Exception!");
            Console.WriteLine(e);
            // Logger.Message(e.ToString());
        }

        Queue<Queue<string>> scriptQueue = Format.ScriptFormat(Lines);
        string message = "";

        // よくわからないけど、一番上のコマンドはうまく実行されない？
        // ScriptBody_にはしっかりEnqueueもされているし、コンストラクタも完了している
        // ただ、本来Commands.Command.Executeがうまくされない。。。
        // 対処的問題解決する。
        // うまく実行されないコマンドを最初から入れておくことで、ちゃんと実行してくれるようにさせる。
        Queue<string> q = new Queue<string>(); // TODO
        q.Enqueue("time=0"); // TODO
        scriptBody_[currentLabel_].Enqueue(new Wait(q)); // TODO
        // 上記の解決策でうまく解決できたが、原因が不明である。
        // 原因究明しないといけない。
        // TODO

        while(scriptQueue.Count > 0)
        {
            Queue<string> scriptLine = scriptQueue.Dequeue();
            // Utilities.Logger.Message("Tag["+currentLabel_+"]:"+scriptLine.Peek());
            if(scriptLine.Peek().Contains("Command"))
            {
                scriptLine.Dequeue();
                if(scriptLine.Peek().Contains("image"))
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new ChangeImage(scriptLine));
                }
                else if(scriptLine.Peek().Contains("wait"))
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new Wait(scriptLine));
                }
                else if(scriptLine.Peek().Contains("trans"))
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new Transion(scriptLine));
                }
                else if(scriptLine.Peek().IndexOf("linkstop") == 0)
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new LinkStop());
                    // Console.WriteLine("OK!");
                }
                else if(scriptLine.Peek().IndexOf("link") == 0)
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new Link(scriptLine));
                }
                else if(scriptLine.Peek().IndexOf("l") == 0)
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new Message(message));
                    // Utilities.Logger.Message("Tag["+currentLabel_+"]:"+message);
                    message = "";
                }
                else if(scriptLine.Peek().IndexOf("jamp") == 0)
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new JampScript(scriptLine));
                    // Utilities.Logger.Message("Tag["+currentLabel_+"]:jamp");
                    // message = "";
                }
                else if(scriptLine.Peek().IndexOf("mc") == 0)
                {
                    scriptLine.Dequeue();
                    scriptBody_[currentLabel_].Enqueue(new MessageClear());
                    // Utilities.Logger.Message("Tag["+currentLabel_+"]:mc");
                    // message = "";
                }
                // etc.
            }
            else if(scriptLine.Peek().Contains("Message"))
            {
                scriptLine.Dequeue();
                message += scriptLine.Dequeue();
            }
            else if(scriptLine.Peek().Contains("Label"))
            {
                scriptLine.Dequeue();
                // string preLabel = ;
                if(!scriptBody_.ContainsKey(scriptLine.Peek())){
                    // scriptBody_[currentLabel_].Enqueue(new EndQueue());
                    // currentLabel_ = preLabel;
                    currentLabel_ = scriptLine.Dequeue();
                    scriptBody_.Add(currentLabel_,new Queue<Command>());
                }
                // Utilities.Logger.Message(scriptLine.Dequeue());
            }
        }

        // scriptBody_[currentLabel_].Enqueue(new EndQueue());
        currentLabel_ = "*start";
    }

    public string CurrentLabel
    {
        set
        {
            currentLabel_ = value;
        }
    }

    public override string ToString()
    {
        return System.String.Format("Script:[CurreLabel:{0}],[index:{1,3}]",currentLabel_,scriptBody_[currentLabel_].Count);
    }
}
