using System;
using Layers;
using Utilities;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Xml
{
    public class XmlMachine
    {
        private Dictionary<string, Layer> layers_;

        public XmlMachine(string filename)
        {
            layers_ = new Dictionary<string,Layer>();

            string[] lines;

            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch(Exception e)
            {
                lines = new string[1]{"ScriptMachine..ctor:File Not Found Exception!"};
                Logger.Message("File Not Found Exception!");
                Logger.Message(e.ToString());
            }

            Queue<Queue<string>> layersQueue = Format.XmlFormat(lines);

            string tag = "";
            string name = "";
            
            Queue<string> layersLine;

            while(layersQueue.Count > 0)
            {
                layersLine = layersQueue.Dequeue();
               
                // Logger.Message(layersLine.Peek());
                if(layersLine.Peek().Contains("Command"))
                {
                    layersLine.Dequeue();
                    tag = layersLine.Dequeue();
                    name = layersLine.Dequeue().Replace("name=","");
                    // Logger.Message("tag = "+tag+", name = "+name+", left = "+left+", top = "+top);
                    switch (tag)
                    {
                        case "Background":
                        Const.Background.NAME = name;
                        layers_.Add(name,new BackgroundLayer());
                        break;
                        case "Foreground":
                        Const.Character.NAME = name;
                        // layers_.Add(name,new CharacterLayer(Int32.Parse(left),Int32.Parse(top)));
                        layers_.Add(name,new CharacterLayer(layersLine));
                        break;
                        case "Message":
                        Const.MessageFrame.NAME = name+"Frame";
                        // layers_.Add(name+"Frame",new MessageFrameLayer(Int32.Parse(left),Int32.Parse(top)));
                        layers_.Add(name+"Frame",new MessageFrameLayer());
                        Const.Message.NAME = name;
                        // layers_.Add(name,new MessageTextLayer());
                        layers_.Add(name,new MessageTextLayer());
                        break;
                        case "Label":
                        Const.Label.NAME = name;
                        // layers_.Add(name,new LabelLayer(Int32.Parse(left),Int32.Parse(top),value));
                        layers_.Add(name,new LabelLayer(layersLine));
                        break;
                        case "Button":
                        Const.Button.NAME = name;
                        // layers_.Add(name,new ButtonLayer(Int32.Parse(left),Int32.Parse(top),storage,method));
                        layers_.Add(name,new ButtonLayer(layersLine));
                        break;
                        case "CheckBoxList":
                        Const.Button.NAME = name;
                        // layers_.Add(name,new ButtonLayer(Int32.Parse(left),Int32.Parse(top),storage,method));
                        layers_.Add(name,new CheckBoxListLayer(layersLine));
                        break;
                        case "Slider":
                        Const.Button.NAME = name;
                        layers_.Add(name,new SliderLayer(layersLine));
                        break;
                        default:
                        break;
                    }
                    // etc.

                    tag = "";
                    name = "";
                }
            }
        }

        public Dictionary<string, Layer> GetXml()
        {
            foreach (KeyValuePair<string, Layer> keyValPai in layers_)
            {
                Logger.Message("["+keyValPai.Key+"]:"+keyValPai.Value.ToString() +"");
            }
            return layers_;
        }
    }
}