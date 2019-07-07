using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

public class Script{
    private string[] Lines;
    private Dictionary<string,Queue<Command>> Commands;
    private DataStorage Storage;
    private string CurrentLabelName;

    public Script(string filename){
        Storage = DataStorage.GetInstance;

        Lines = File.ReadAllLines(filename);
        Commands = new Dictionary<string,Queue<Command>>();
        CurrentLabelName = "*start";
        Commands.Add(CurrentLabelName,new Queue<Command>());

        string Text = null;

        string Line = "";
        Storage.WriteLog("Script..ctor.Message:Lines.Length=" + Lines.Length);
        for(int i = 0;i < Lines.Length;i++){
            int StartIndex = Lines[i].IndexOf("[");
            if(Lines[i].IndexOf(";") == 0){
                continue;
            }
            if(Lines[i].IndexOf("*") == 0 && !Lines[i].Equals("*start")){
                Storage.WriteLog("Script..ctor.ChangeCurrentLabelName:"+CurrentLabelName+" -> "+Lines[i]);
                CurrentLabelName = Lines[i];
                Commands.Add(CurrentLabelName,new Queue<Command>());
                continue;
            }
            if(StartIndex != -1){
                if(Lines[i].IndexOf("[wait") != -1){
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(Wait)");
                    Commands[CurrentLabelName].Enqueue(new Wait(Lines[i]));
                }else if(Lines[i].IndexOf("[cm]") != -1){
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(ClearMessage)");
                    Commands[CurrentLabelName].Enqueue(new ClearMessage());
                }else if(Lines[i].IndexOf("[l]") != -1){
                    Line = Lines[i].Replace(" ","");
                    Line = Line.Replace("[l]","");
                    Text += Line;
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(Display)");
                    Commands[CurrentLabelName].Enqueue(new DisplayText(Text));
                    Commands[CurrentLabelName].Enqueue(new ClickWait());
                    Text = null;
                }else if(Lines[i].IndexOf("[r]") != -1){
                    Line = Lines[i].Replace(" ","");
                    Line = Line.Replace("[r]","");
                    Text += Line + "\n";
                }else if(Lines[i].IndexOf("[image") != -1){
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(ImageCommand)");
                    Commands[CurrentLabelName].Enqueue(new ImageCommand(Lines[i]));
                }else if(Lines[i].IndexOf("[trans") != -1){
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(Transiton)");
                    Commands[CurrentLabelName].Enqueue(new Transiton(Lines[i]));
                }else if(Lines[i].IndexOf("link") != -1 && Lines[i].IndexOf("[linkstop]") == -1){
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(Link)");
                    Commands[CurrentLabelName].Enqueue(new Link(Lines[i]));
                }else if(Lines[i].IndexOf("[linkstop]") != -1){
                    Storage.WriteLog("Script..ctor.Message:Commands[CurrentLabelName].Enqueue(LinkStop)");
                    Commands[CurrentLabelName].Enqueue(new LinkStop(Lines[i]));
                }
            }else if(Lines[i].IndexOf("*start") == 0){
                continue;
            }else{
                Text += Lines[i];
            }
        }
        CurrentLabelName = "*start";
        Storage.WriteLog("Script..ctor.Message:Complete!");
    }

    public void Execute(){
        if(Commands[CurrentLabelName].Count > 0){
            int isNext = Commands[CurrentLabelName].Peek().Execute();
            if(isNext == 1){
                Storage.WriteLog("Script.Execute.Message:isNext = 1.");
                Commands[CurrentLabelName].Dequeue();
            }
        }
    }

    public string CurLabNam{
        set{this.CurrentLabelName = value;}
        get{return this.CurrentLabelName;}
    }
}
