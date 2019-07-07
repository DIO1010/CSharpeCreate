using System;
using System.Drawing;
using System.Windows.Forms;

public class ImageCommand : Command{
    private DataStorage storage;
    private Image image;
    private NovelState state;
    private int top;
    private int left;
    private int type;

    public ImageCommand(string Message){
        this.type = 0;
        this.top = 0;
        this.left = 0;

        int startIndex = 0;
        int endIndex = 0;

        string line = Message.Replace(" ","");
        if(line.IndexOf("top") != -1){
            line = line.Insert(line.IndexOf("top"),";");
        }
        if(line.IndexOf("left") != -1){
            line = line.Insert(line.IndexOf("left"),";");
        }
        startIndex = line.IndexOf("storage=\"");
        startIndex += 8;
        endIndex = line.IndexOf("\"",startIndex+1);
        string filename = line.Substring(startIndex+1,endIndex-startIndex-1);
        startIndex = line.IndexOf("layer");
        if(startIndex != -1){
            if(line.IndexOf("layer=base") != -1){ // 背景レイヤー
                type = 0;
            }else if(line.IndexOf("layer=0") != -1){ // 前景レイヤー0
                // Console.Writeline("Script.Image:1");
                type = 1;
            }else if(line.IndexOf("layer=1") != -1){ // 前景レイヤーⅠ
                // Console.Writeline("Script.Image:2");
                type = 2;
            }else if(line.IndexOf("layer=2") != -1){ // 前景レイヤー2
                // Console.Writeline("Script.Image:3");
                type = 3;
            }else if(line.IndexOf("3") != -1){ // メッセージ背景レイヤー
                type = 4;
            }
        }
        startIndex = line.IndexOf("top=");
        if(startIndex != -1){
            startIndex += 4;
            endIndex = line.IndexOf(";",startIndex+1);
            if(endIndex == -1){
                endIndex = line.IndexOf("]");
            }
            top = Int32.Parse(line.Substring(startIndex,endIndex-startIndex));
        }
        startIndex = line.IndexOf("left=");
        if(startIndex != -1){
            startIndex += 5;
            endIndex = line.IndexOf(";",startIndex+1);
            if(endIndex == -1){
                endIndex = line.IndexOf("]");
            }
            left = Int32.Parse(line.Substring(startIndex,endIndex-startIndex));
        }

        storage = DataStorage.GetInstance;
        image = storage.GetImage(filename);

        storage.WriteLog("ImageCommand..ctor.Message:Complete!");
    }

    public int Execute(){
        state = storage.State;
        Bitmap canvas;
        Graphics g;

        switch(type){
            case 0:
            PictureBox background = state.Background;
            canvas = new Bitmap(storage.Form.Width,storage.Form.Height);
			g = Graphics.FromImage(canvas);
			g.DrawImage(image,0,0,image.Width,image.Height);
            background.Image = canvas;
            state.Background = background;
            break;
            case 1:
            state.SetCharacter(image,top,left,0);
            break;
            case 2:
            state.SetCharacter(image,top,left,1);
            break;
            case 3:
            state.SetCharacter(image,top,left,2);
            break;
            case 4:
            PictureBox textFrame = state.TextFrame;
            canvas = new Bitmap(storage.Form.Width,storage.Form.Height);
			g = Graphics.FromImage(canvas);
			g.DrawImage(image,10,280,image.Width,image.Height);
            textFrame.Image = canvas;
            state.TextFrame = textFrame;
            break;
        }

        storage.WriteLog("ImageCommand.Execute.Message:return 1!");
        return 1;
    }
}
