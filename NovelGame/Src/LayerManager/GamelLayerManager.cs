using Xml;
using Const;
using System;
using Layers;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public class GameLayerManager
{
    private Dictionary<string, Layer> layers_ = new Dictionary<string,Layer>();
    private bool isNextMessage_;

    public GameLayerManager()
    {
        XmlMachine x = new XmlMachine("./Xml/Game.fnmx");
        layers_ = x.GetXml();

        foreach(KeyValuePair<string, Layer> keyValPai in layers_)
        {
            Debug.Items.Instance.ParamAdd(keyValPai.Key,keyValPai.Value);
        }

        Debug.Items.Instance.ParamAdd("MousePoint",MousePoint.Instance);
        Debug.Items.Instance.ParamAdd("ReloadConfig","");
        Debug.Items.Instance.ParamAdd("ReloadScript","");

        layers_.Add("DebugMenuLayer",new DebugMenuLayer());
        layers_.Add("DebugItemsLayer",new DebugItemsLayer());

        isNextMessage_ = false;
    }

    public Bitmap GetDrawLayerImage()
    {
        Bitmap canvas = new Bitmap(Const.Window.WIDTH,Const.Window.HEIGHT);
        Graphics g = Graphics.FromImage(canvas);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

        foreach (KeyValuePair<string, Layer> keyValuePair in layers_)
        {
            keyValuePair.Value.DrawLayer(g);
            // if(keyValuePair.Value.IsReDraw)
            // {
            //     keyValuePair.Value.DrawLayer(g);
            //     keyValuePair.Value.IsReDraw = false;
            // }
        }

        return canvas;
        // return new Bitmap(Const.Window.WIDTH,Const.Window.HEIGHT);
    }

    public void SetMessageTextIndexMax()
    {
        layers_[Const.Message.NAME].SetTextIndexMax();
    }

    public void ChangeLayerImage(string name,Bitmap image)
    {
        if(layers_.ContainsKey(name)){
            layers_[name].Image = image;
        }else{
            Logger.ErrorKey(name);
        }
    }

    public Bitmap GetImage(string name)
    {
        if(layers_.ContainsKey(name)){
            return layers_[name].Image;
        }else{
            Logger.ErrorKey(name);
            return new Bitmap(Const.Image.GetImage("Transiton"));
        }
    }

    public void ChangeLayerPoint(string name,Point point)
    {
        if(layers_.ContainsKey(name)){
            layers_[name].Point = point;
        }else{
            Logger.ErrorKey(name);
        }
    }

    public void ChangeLayerSize(string name,Size size)
    {
        if(layers_.ContainsKey(name)){
            layers_[name].Size = size;
        }else{
            Logger.ErrorKey(name);
        }
    }

    public void ChangeLayerMessageText(string text)
    {
        layers_[Const.Message.NAME].MessageText = text;
    }

    public bool IsTextCountMax()
    {
        return layers_[Const.Message.NAME].IsTextCountMax();
    }

    public bool IsNextMessage
    {
        get
        {
            return this.isNextMessage_;
        }
        set
        {
            this.isNextMessage_ = value;
        }
    }
    public void AddLayer(string key,Layer value)
    {
        if(!layers_.ContainsKey(key))
        {
            layers_.Add(key,value);
        }
        else
        {
            Utilities.Logger.Warning(key+"は既にあります。");
        }
    }

    public void RemoveLayer(string key)
    {
        if(layers_.ContainsKey(key))
        {
            layers_.Remove(key);
        }
        else
        {
            Utilities.Logger.ErrorKey(key);
        }
    }

    public void Dispose()
    {
        List<string> l = new List<string>();
        // foreach(KeyValuePair<string, Layer> keyValPai in Debug.Items.Elements)
        // {
        //    l.Add(keyValPai.Key);
        // }
        foreach(KeyValuePair<string, object> keyValPai in Debug.Items.Instance.Elements)
        {
            Debug.Items.Instance.ParamRemove(keyValPai.Key);
        }
    }

    public Layer GetLayer(string key)
    {
        if(layers_.ContainsKey(key))
        {
            return layers_[key];
        }
        else
        {
            Utilities.Logger.ErrorKey(key);
            return null;
        }
    }

    public bool ContainsLayer(string key)
    {
        return layers_.ContainsKey(key);
    }

    public Layer SelectedButton()
    {
        foreach (KeyValuePair<string, Layer> keyValuePair in layers_)
        {
            // keyValuePair.Value.DrawLayer(g);
            // Console.WriteLine(keyValuePair.Value.GetType().Name);
            if(keyValuePair.Value.GetType().Name.Contains("ButtonLayer"))
            {
                ButtonLayer b = (ButtonLayer)keyValuePair.Value;
                if(b.isSelect)
                {
                    return keyValuePair.Value;
                }
            }
        }
        return null;
    }
}
