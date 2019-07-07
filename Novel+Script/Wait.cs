using System;

public class Wait : Command{
    private int time;
    private DataStorage storage;

    public Wait(string messagr){
        storage = DataStorage.GetInstance;
        string line = messagr.Replace(" ","");
        int startIndex = line.IndexOf("time=");
        startIndex += 5;
        int endIndex = line.Length-1;
        time = Int32.Parse(line.Substring(startIndex,endIndex - startIndex));
        this.time = (int)time / 33;
        storage.WriteLog("Wait..ctor.Message:Complete!");
    }

    public int Execute(){
        System.Threading.Thread.Sleep(time);
        storage.WriteLog("WaitExecute.Message:" + time.ToString() + " msec!");
        return 1;
    }
}
