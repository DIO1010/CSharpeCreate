using Xml;
using Const;
using System;
using Layers;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public class SettingLayerManager
{
    private Dictionary<string, Layer> layers_ = new Dictionary<string,Layer>();

    public SettingLayerManager()
    {
        XmlMachine x = new XmlMachine("./Xml/Setting.fnmx");
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
            // if(keyValuePair.Value.GetType().Name.Contains("ButtonLayer"))
            // {
            //     ButtonLayer b = (ButtonLayer)keyValuePair.Value;
            //     if(b.isSelect)
            //     {
            //         return keyValuePair.Value;
            //     }
            // }
            if(keyValuePair.Value is ButtonLayer)
            {
                if((keyValuePair.Value as ButtonLayer).isSelect)
                {
                    return keyValuePair.Value;
                }
            }
        }
        return null;
    }

    public bool SelectedCheckBoxList()
    {
        foreach (KeyValuePair<string, Layer> keyValuePair in layers_)
        {
            if(keyValuePair.Value is CheckBoxListLayer)
            {
                return (keyValuePair.Value as CheckBoxListLayer).TransSelect();
            }
        }
        return false;
    }

    public bool SelectedSlider()
    {
        foreach (KeyValuePair<string, Layer> keyValuePair in layers_)
        {
            if(keyValuePair.Value is SliderLayer)
            {
                return (keyValuePair.Value as SliderLayer).ChanePoint();
            }
        }
        return false;
    }
}
