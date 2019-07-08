using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class NovelStateLayerManagement
{
    private Dictionary<string, Layer> layers = new Dictionary<string,Layer>();

    public NovelStateLayerManagement(int width,int height)
    {
        layers.Add("BackgroundLayer",new BackgroundLayer(width,height));
        layers.Add("CharacterLayer0",new CharacterLayer());
        layers.Add("CharacterLayer1",new CharacterLayer());
        layers.Add("CharacterLayer2",new CharacterLayer());
        layers.Add("MessageFrameLayer",new MessageFrameLayer());
        layers.Add("MessageTextLayer",new MessageTextLayer(width,height));
    }

    public Bitmap GetDrawLayerImage()
    {
        Bitmap canvas = new Bitmap(800,600); // マジックナンバー
        Graphics g = Graphics.FromImage(canvas);

        foreach (KeyValuePair<string, Layer> keyValuePair in layers)
        {
            keyValuePair.Value.DrawLayer(g);
        }

        return canvas;
    }

    public void MessageTextIndexMax()
    {
        layers["MessageTextLayer"].SetTextIndexMax();
    }

    public void ChangeLayerImage(string name,Bitmap image)
    {
        if(layers.ContainsKey(name)){
            layers[name].Image = image;
        }else{
            Utility.WriteLog("NovelStateLayerManagement.ChangeLayerImage:キーが不正です。入力したキー:" + name);
        }
    }

    public void ChangeLayerPoint(string name,Point point)
    {
        if(layers.ContainsKey(name)){
            layers[name].Point = point;
        }else{
            Utility.WriteLog("NovelStateLayerManagement.ChangeLayerImage:キーが不正です。入力したキー:" + name);
        }
    }

    public void ChangeLayerSize(string name,Size size)
    {
        if(layers.ContainsKey(name)){
            layers[name].Size = size;
        }else{
            Utility.WriteLog("NovelStateLayerManagement.ChangeLayerImage:キーが不正です。入力したキー:" + name);
        }
    }

    public void ChangeLayerMessageText(string text)
    {
        layers["MessageTextLayer"].MessageText = text;
    }
}

public abstract class Layer
{
    private Bitmap image = new Bitmap(Utility.GetImagePath() + "Transparent.png");
    private Point point = new Point(0,0);
    private Size size = new Size(0,0);
    private string str = "";

    public virtual Bitmap Image
    {
        get
        {
            return this.image;
        }
        set
        {
            this.image = value;
        }
    }


    public virtual Point Point
    {
        get{
            return this.point;
        }
        set
        {
            this.Point = value;
        }
    }

    public virtual Size Size
    {
        get
        {
            return this.size;
        }
        set
        {
            this.size = value;
        }
    }

    public virtual string MessageText
    {
        get
        {
            return this.str;
        }
        set
        {
            this.str = value;
        }
    }

    public virtual void SetTextIndexMax(){}

    public virtual void DrawLayer(Graphics g){}
}

public class BackgroundLayer : Layer
{
    private Bitmap image;
    private Point point;
    private Size size;

    public BackgroundLayer(int width,int height)
    {
        image = new Bitmap(Utility.GetImagePath() + "Transparent.png");
        point = new Point(0,0); // マジックナンバー
        size = new Size(width,height);
    }

    public override Bitmap Image
    {
        get
        {
            return this.image;
        }
        set
        {
            this.image = value;
        }
    }

    public override Point Point
    {
        get
        {
            return this.point;
        }
        set
        {
            this.point = value;
        }
    }

    public override Size Size
    {
        get
        {
            return this.size;
        }
        set
        {
            this.size = value;
        }
    }

    public override void DrawLayer(Graphics g)
    {
        g.DrawImage(this.image,this.point.X,this.point.Y,this.size.Width,this.size.Height);
    }
}

public class CharacterLayer : Layer
{
    private Bitmap image;
    private Point point;

    public CharacterLayer()
    {
        image = new Bitmap(Utility.GetImagePath() + "Transparent.png");
        point = new Point(0,0); // マジックナンバー
    }

    public override Bitmap Image
    {
        get
        {
            return this.image;
        }
        set
        {
            this.image = value;
        }
    }

    public override Point Point
    {
        get
        {
            return this.point;
        }
        set
        {
            this.point = value;
        }
    }

    public override void DrawLayer(Graphics g)
    {
        g.DrawImage(this.image,this.point.X,this.point.Y,this.image.Width,this.image.Height);
    }
}

public class MessageFrameLayer : Layer
{
    private Bitmap image;
    private Point point;

    public MessageFrameLayer()
    {
        image = new Bitmap(Utility.GetImagePath() + "Transparent.png");
        point = new Point(0,0); // マジックナンバー
    }

    public override Bitmap Image
    {
        get
        {
            return this.image;
        }
        set
        {
            this.image = value;
        }
    }

    public override Point Point
    {
        get
        {
            return this.point;
        }
        set
        {
            this.point = value;
        }
    }

    public override void DrawLayer(Graphics g)
    {
        g.DrawImage(this.image,this.point.X,this.point.Y,this.image.Width,this.image.Height);
    }
}

public class MessageTextLayer : Layer
{
    private string text;
    private Font font;
    private RectangleF drawRect;
    private int textCount;

    public MessageTextLayer(int width,int height)
    {
        text = "MessageTextLayer";
        font = new Font("ＭＳ ゴシック", 24);        //  マジックナンバー
        drawRect = new RectangleF(160,435,620,250); // マジックナンバー
        textCount = 0;
    }

    public override string MessageText
    {
        get
        {
            return this.text;
        }
        set
        {
            this.textCount = 0;
            this.text = value;
        }
    }

    public override void DrawLayer(Graphics g)
    {
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(0,0,0,0));
        g.FillRectangle(solidBrush,drawRect);

        if(this.textCount < this.text.Length)
        {
            ++textCount;
            g.DrawString(this.text.Substring(0,textCount),font,Brushes.Black,drawRect);
        }else{
            g.DrawString(this.text,font,Brushes.Black,drawRect);
        }
    }

    public override void SetTextIndexMax()
    {
        this.textCount = this.text.Length;
    }
}
