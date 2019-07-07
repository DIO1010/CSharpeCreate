using System;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;

public class DataStorage{
    private static DataStorage instance = new DataStorage();
    private Dictionary<string,Image> images;
    private NovelState state;
    private NovelForm form;
    private Script script;
    private static Dictionary<String,Font> fonts;
    private static PrivateFontCollection pfc;

    private DataStorage(){
        WriteInit();
        try{
            images = new Dictionary<string,Image>();
            string[] Files = System.IO.Directory.GetFiles(
                                @"./Image",
                                "*",
                                System.IO.SearchOption.AllDirectories);
            WriteLog("DataStorage..ctor.Message:Image Files OK!");
            int NotNeedPathLength = "./Image/".Length;
            foreach(string File in Files){
                if(File.IndexOf("ico") < 0){
                    images.Add(File.Substring(NotNeedPathLength),Image.FromFile(File));
                }
            }
        }catch(Exception){
            WriteLog("DataStorage..ctor.Message:Images Load ERROR!");
        }

        try{
            fonts = new Dictionary<string,Font>();
            pfc = new PrivateFontCollection();
            string[] Files = System.IO.Directory.GetFiles(
                                @"./Font",
                                "*",
                                System.IO.SearchOption.AllDirectories);
            WriteLog("DataStorage..ctor.Message:Font Files OK!");
            int NotNeedPathLength = "./Font/".Length;
            for(int i = 0;i < Files.Length;i++){
                pfc.AddFontFile(Files[i]);
                fonts.Add(Files[i].Substring(NotNeedPathLength),new Font(pfc.Families[0],25));
            }
        }catch(Exception){
            WriteLog("DataStorage..ctor.Message:Fonts Load ERROR!");
        }

        WriteLog("DataStorage..ctor.Message:Complete!");
    }

    public static DataStorage GetInstance{
        get{
            return instance;
        }
    }

    public NovelForm Form{
        set{
            this.form = value;
        }
        get{
            return this.form;
        }
    }

    public Script Script{
        set{
            this.script = value;
        }
        get{
            return this.script;
        }
    }

    public NovelState State{
        set{
            this.state = value;
        }
        get{
            return this.state;
        }
    }

    public Font GetFont(string key){
        return fonts[key];
    }

    public Image GetImage(string key){
        return images[key];
    }

    public void PrintImageData(){
        foreach(KeyValuePair<string,Image> kvp in images){
            WriteLog("DataStorage.PrintImageData:Kay=" + kvp.Key + ",Value = " + kvp.Value);
        }
    }

    public void PrintFontData(){
        foreach(KeyValuePair<string,Font> kvp in fonts){
            WriteLog("DataStorage.PrintFontData:Kay=" + kvp.Key + ",Value = " + kvp.Value);
        }
    }

    public void WriteLog(string Message){
        System.Text.Encoding Encode = System.Text.Encoding.GetEncoding("UTF-8");
        StreamWriter SW = new StreamWriter(@"./log.txt",true,Encode);
        string write = "[" + System.DateTime.Now.ToString() + "]";
        write += Message+"\n";
        SW.Write(write);
        SW.Close();
    }

    public void WriteInit(){
        System.Text.Encoding Encode = System.Text.Encoding.GetEncoding("UTF-8");
        StreamWriter SW = new StreamWriter(@"./log.txt",false,Encode);
        SW.Write("");
        SW.Close();
    }
}
