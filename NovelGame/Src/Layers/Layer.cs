using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Layers
{
  public class Layer
  {
    public virtual Bitmap Image { get; set; }
    public virtual Point Point { get; set; }
    public virtual string Target { get; set; }
    public virtual string MessageText { get; set; }
    public virtual Size Size { get; set; }



    public virtual void DrawLayer(Graphics g) { }
    public virtual void SetTextIndexMax() { }
    public virtual bool IsTextCountMax() { return false; }

    public string GetNeedInformation(string text)
    {
      Match match = Regex.Match(text, @"^(\w*?)=(?<param>\w*?)$");
      return match.Groups["param"].ToString();
    }
  }
}
