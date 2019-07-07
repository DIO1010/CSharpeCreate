using System;
using System.Drawing;
using System.Windows.Forms;

public class LinkStop : Command{
    private string text;
    private DataStorage storage;

    public LinkStop(string message){
        storage = DataStorage.GetInstance;
        text = message;
        storage.WriteLog("Stop..ctor.Message:Complete!");
    }

    public int Execute(){
        if(!storage.State.IsChoice){
            storage.State.IsChoice = true;
        }
        if(storage.State.GetIsOK){
            storage.Script.CurLabNam = storage.State.ChoiceIndexToString;
            storage.State.SetChoiceLabelClear();
            storage.State.IsChoice = false;
            storage.WriteLog("Stop.Execute.Message:CurrentLabelName = "+storage.Script.CurLabNam);
            return 1;
        }else{
            return 0;
        }
    }
}
