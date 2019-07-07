using System;

public class ClickWait : Command{
    private DataStorage storage;

    public ClickWait(){
        storage = DataStorage.GetInstance;
        storage.WriteLog("ClickWait..ctor.Message:Complete!");
    }

    public int Execute(){
        if(storage.State.GetIsKeyDown){
            storage.WriteLog("ClickWait.Execute.Message:return 1.");
            return 1;
        }else{
            return 0;
        }
    }
}
