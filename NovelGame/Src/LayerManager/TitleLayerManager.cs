using Xml;
using Const;
using System;
using Layers;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public class TitleLayerManager
{
    private Dictionary<string, Layer> layers_ = new Dictionary<string,Layer>();

    public TitleLayerManager()
    {
        XmlMachine x = new XmlMachine("./Xml/Title.fnmx");
        layers_ = x.GetXml();
    }

    public Bitmap GetDrawLayerImage()
    {
        Bitmap canvas = new Bitmap(Const.Window.WIDTH,Const.Window.HEIGHT);
        Graphics g = Graphics.FromImage(canvas);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

        foreach (KeyValuePair<string, Layer> keyValuePair in layers_)
        {
            keyValuePair.Value.DrawLayer(g);
        }

        return canvas;
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
