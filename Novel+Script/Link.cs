using System;
using System.Drawing;
using System.Windows.Forms;

public class Link : Command{
    private DataStorage storage;
    private string target;
    private string value;

    public Link(string Message){
        storage = DataStorage.GetInstance;

        string text = Message.Replace(" ","");
        int startIndex = 0;
        int endIndex = 0;

        if(text.IndexOf("target") != -1){
            text = text.Insert(text.IndexOf("target"),";");
        }

        if(text.IndexOf("value") != -1){
            text = text.Insert(text.IndexOf("value"),";");
        }

        if(text.IndexOf("target") != -1){
            startIndex = text.IndexOf("target=");
            startIndex += 7;

            endIndex =
            (text.IndexOf(";",startIndex+1)  != -1) ?
            (text.IndexOf(";",startIndex+1)) :
            (text.IndexOf("]"));

            target = text.Substring(startIndex,endIndex-startIndex);
        }

        if(text.IndexOf("value") != -1){
            startIndex = text.IndexOf("value=");
            startIndex += 6;

            endIndex =
            (text.IndexOf(";",startIndex+1)  != -1) ?
            (text.IndexOf(";",startIndex+1)) :
            (text.IndexOf("]"));

            value = text.Substring(startIndex,endIndex - startIndex);
        }
        storage.WriteLog("Link..ctor.Message:Complete!");
    }

    public int Execute(){
        storage.WriteLog("Link.Execute:Target="+target+",Value="+value);

        Label Label = new Label();
		int index = storage.State.ChoiceLabel.Count - 1;
		Label.Location = new Point(50,100 * index + 150);
		Label.Size = new Size(700,50);
		Label.Parent = storage.State.TextFrame;
		Label.BackColor = Color.FromArgb(200,0,200,255);
		Label.Font = storage.GetFont("ラノベPOP.ttf");
		Label.TextAlign = ContentAlignment.MiddleCenter;
		Label.Text = value;
        storage.State.ChoiceIndexToString = target;

        storage.State.SetChoiceLabel(Label);
        return 1;
    }
}
