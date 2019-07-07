using System;
using System.Windows.Forms;

public class ClearMessage : Command{
    private DataStorage Storage;
    private NovelState State;

    public ClearMessage(){
        Storage = DataStorage.GetInstance;
        Storage.WriteLog("ClearMessage..ctor.Message:Complete!");
    }

    public int Execute(){
        Storage.WriteLog("ClearMessage.Execute.Message:Execute!");
        State = Storage.State;
        State.SetSpeechLabel("");

        return 1;
    }
}
