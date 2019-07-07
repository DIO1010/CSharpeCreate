using System;
using System.Windows.Forms;

public class DisplayText : Command{
    private String text;
    private int textCount;
    private DataStorage storage;
    private NovelState state;

    public DisplayText(string text){
        this.text = text;
        storage = DataStorage.GetInstance;

        textCount = 0;
        storage.WriteLog("DisplayText..ctor.Message:Complete!");
    }

    public int Execute(){
        state = storage.State;
        if(state.GetIsKeyDown){
            textCount = text.Length;
            state.SetSpeechLabel(text);
        }
        if(textCount < text.Length){
            textCount++;
            state.SetSpeechLabel(text.Substring(0,textCount));
            System.Threading.Thread.Sleep(150);
        }else{
            storage.WriteLog("DisplayText.Execute.Message:return 1!");
            return 1;
        }
        return 0;
    }
}
