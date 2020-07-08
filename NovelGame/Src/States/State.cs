

using System.Drawing;
using System.Windows.Forms;

namespace States
{
  public class State
  {
    public virtual bool Control { get; set; }

    public virtual void Update(StateManage SM, Form GF) { }
    public virtual Bitmap GetDrawImage() { return null; }
    public virtual void ReloadScript(string filename) { }

  }
}
