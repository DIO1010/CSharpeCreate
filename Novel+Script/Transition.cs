using System;
using System.Drawing;
using System.Windows.Forms;

public class Transiton : Command{
    private float alpha;
    private int type;
    private int time;
    private int from;
    private int x,y;
    private Image preImage;
    private Image nextImage;
    private NovelState state;
    private DataStorage storage;

    public Transiton(string Message){
        storage = DataStorage.GetInstance;

        string line = Message.Replace(" ","");
        int startIndex = 0;
        int endIndex = 0;

        line = line.Insert(line.IndexOf("method"),";");
        line = line.Insert(line.IndexOf("time"),";");
        if(line.IndexOf("from") != -1){
            line = line.Insert(line.IndexOf("from"),";");
        }
        startIndex = line.IndexOf("storage=\"");
        startIndex += 8;
        endIndex = line.IndexOf("\"",startIndex+1);
        string filename = line.Substring(startIndex+1,endIndex-startIndex-1);
        startIndex = line.IndexOf("method=");
        startIndex += 7;
        endIndex = line.IndexOf(";",startIndex+1);
        if(endIndex == -1){
            endIndex = line.IndexOf("]");
        }
        string typeString = line.Substring(startIndex,endIndex-startIndex);

        switch(typeString){
            case "crossfade":
            type = 1;
            break;
            case "scroll":
            type = 2;
            if(line.IndexOf("from") != -1){
                startIndex = line.IndexOf("from=");
                startIndex += 5;
                endIndex =
                (line.IndexOf(";",startIndex+1)  != -1) ?
                (line.IndexOf(";",startIndex+1)) :
                (line.IndexOf("]"));
                switch(line.Substring(startIndex,endIndex-startIndex)){
                    case "top":
                    from = 0;
                    break;
                    case "bottom":
                    from = 1;
                    break;
                    case "right":
                    from = 2;
                    break;
                    case "left":
                    from = 3;
                    break;
                }
            }
            break;
        }
        startIndex = line.IndexOf("time=");
        startIndex += 5;
        endIndex = line.IndexOf(";",startIndex+1);
        if(endIndex == -1){
            endIndex = line.IndexOf("]");
        }
        time = Int32.Parse(line.Substring(startIndex,endIndex-startIndex));

        alpha = 0f;
        this.time = (int)time / 33;
        nextImage = storage.GetImage(filename);

        storage.WriteLog("Transiton..ctor.Message:Complete!");
    }

    public int Execute(){
        if(state == null){
            storage.WriteLog("Transiton.Execute.Message:State and from are null!");
            state = storage.State;
            switch(from){
                case 0: // Top
                this.x = 0;
                this.y = 0;
                break;
                case 1: // bottom
                this.x = 0;
                this.y = storage.Form.Height;
                break;
                case 2: // right
                this.x = storage.Form.Width;
                this.y = 0;
                break;
                case 3: // left
                this.x = 0;
                this.y = 0;
                break;
            }
            preImage = storage.State.Background.Image;
        }

        Bitmap canvas = new Bitmap(storage.Form.Width,storage.Form.Height);
        Graphics g = Graphics.FromImage(canvas);
        float plusVal;
        System.Drawing.Imaging.ColorMatrix cm;
        System.Drawing.Imaging.ImageAttributes ia;
        Rectangle rec;

        switch(type){
            case 1:
            if(alpha > -255f){
                g.DrawImage(nextImage,0,0,nextImage.Width,nextImage.Height);
                plusVal = alpha / 255f;
                cm = new System.Drawing.Imaging.ColorMatrix(
                    new float[][]{
                        new float[]{1,0,0,0,0}, // Red
                        new float[]{0,1,0,0,0}, // Green
                        new float[]{0,0,1,0,0}, // Blue
                        new float[]{0,0,0,1,0}, // Alpha
                        new float[]{0,0,0,plusVal,1} // w
                    }
                );
                ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(cm);
                rec = new Rectangle(0,0,preImage.Width,preImage.Height);
                g.DrawImage(preImage,rec,0,0,preImage.Width,preImage.Height,GraphicsUnit.Pixel,ia);
                state.SetTransition(canvas);
                alpha -= 255f / time;
                return 0;
            }else{
                state.SetTransition(nextImage);
                storage.WriteLog("Transiton.Execute.Message:return 1.");
                return 1;
            }
            break;
            case 2:
            Rectangle srcRct;
            Rectangle dstRct;
            switch(from){
                case 0: // Top
                if(this.y < storage.Form.Height){
                    g.DrawImage(preImage,0,0,preImage.Width,preImage.Height);
                    srcRct = new Rectangle(0,nextImage.Height - y,nextImage.Width,nextImage.Height); // 手直し
                    dstRct = new Rectangle(0,0,nextImage.Width,y); // 手直し
                    g.DrawImage(nextImage,dstRct,srcRct,GraphicsUnit.Pixel);
                    state.SetTransition(canvas);
                    this.y += nextImage.Height / this.time;
                    return 0;
                }else{
                    state.SetTransition(nextImage);
                    storage.WriteLog("Transiton.Execute.Message:return 1.");
                    return 1;
                }
                break;
                case 1: // bottom
                if(this.y > 0){
                    g.DrawImage(preImage,0,0,preImage.Width,preImage.Height);
                    srcRct = new Rectangle(0,0,nextImage.Width,nextImage.Height - y);
                    dstRct = new Rectangle(0,y,nextImage.Width,nextImage.Height - y);
                    g.DrawImage(nextImage,dstRct,srcRct,GraphicsUnit.Pixel);
                    state.SetTransition(canvas);
                    this.y -= nextImage.Height / this.time;
                    return 0;
                }else{
                    state.SetTransition(nextImage);
                    storage.WriteLog("Transiton.Execute.Message:return 1.");
                    return 1;
                }
                break;
                case 2: // right
                if(this.x > 0){
                    g.DrawImage(preImage,0,0,preImage.Width,preImage.Height);
                    srcRct = new Rectangle(0,0,nextImage.Width - x,nextImage.Height);
                    dstRct = new Rectangle(x,0,nextImage.Width - x,nextImage.Height);
                    g.DrawImage(nextImage,dstRct,srcRct,GraphicsUnit.Pixel);
                    state.SetTransition(canvas);
                    this.x -= nextImage.Width / this.time;
                    return 0;
                }else{
                    state.SetTransition(nextImage);
                    storage.WriteLog("Transiton.Execute.Message:return 1.");
                    return 1;
                }
                break;
                case 3: // left
                if(this.x < storage.Form.Width){
                    g.DrawImage(preImage,0,0,preImage.Width,preImage.Height);
                    srcRct = new Rectangle(nextImage.Width - x,0,nextImage.Width,nextImage.Height); // 手直し
                    dstRct = new Rectangle(0,0,x,nextImage.Height); // 手直し
                    g.DrawImage(nextImage,dstRct,srcRct,GraphicsUnit.Pixel);
                    state.SetTransition(canvas);
                    this.x += nextImage.Width / this.time;
                    return 0;
                }else{
                    state.SetTransition(nextImage);
                    storage.WriteLog("Transiton.Execute.Message:return 1.");
                    return 1;
                }
                break;
            }
            break;
        }
        storage.WriteLog("Transiton.Execute.Message:return 1.");
        return 1;
    }
}
