using System;
using Utilities;
using System.Drawing;
using System.Collections.Generic;

namespace Layers
{
  public class LabelLayer : Layer
  {
    private Point point_;
    private string value_;
    // private bool isReDraw_ = true;

    public LabelLayer()
    {
      value_ = "";
      point_ = new Point(Const.Character.LEFT, Const.Character.TOP);
    }

    public LabelLayer(int left, int top)
    {
      value_ = "";
      point_ = new Point(left, top);
    }

    public LabelLayer(int left, int top, string value)
    {
      value_ = value;
      point_ = new Point(left, top);
    }

    public LabelLayer(Queue<string> line)
    {
      int left = 0;
      int top = 0;
      string value = "";

      while (line.Count > 0)
      {
        if (line.Peek().Contains("left"))
        {
          left = Int32.Parse(GetNeedInformation(line.Dequeue()));
        }
        else if (line.Peek().Contains("top"))
        {
          top = Int32.Parse(GetNeedInformation(line.Dequeue()));
        }
        else if (line.Peek().Contains("value"))
        {
          value = GetNeedInformation(line.Dequeue());
        }
      }

      value_ = value;
      point_ = new Point(left, top);
    }


    public override Point Point
    {
      get
      {
        return this.point_;
      }
      set
      {
        this.point_ = value;
        // int x = Const.Character.Left(point_.X);
        // int y = Const.Character.Top(point_.Y);
      }
    }

    public override string ToString()
    {
      return ("LabelLayer:[value:" + value_ + "]");
    }

    public override void DrawLayer(Graphics g)
    {
      g.DrawString(
          value_,
          new Font(
              Const.Label.FONT_STYLE,
              Const.Label.FONT_SIZE
          ),
          Brushes.Black,
          new RectangleF(
              point_.X * Config.Instance.Width,
              // Const.Message.TOP  ,
              point_.Y * Config.Instance.Height,
              Const.Label.WIDTH,
              Const.Label.HEIGHT
          )
      );
    }
  }
}