using Const;
using System;
using Utilities;
using System.Drawing;
using System.Collections.Generic;

namespace Layers
{
    public class DebugItemsLayer : Layer
    {
        // private bool isReDraw_ = true;

        // public override bool IsReDraw
        // {
        //     get
        //     {
        //         return isReDraw_;
        //     }
        //     set
        //     {
        //         isReDraw_ = value;
        //     }
        // }
        public override void DrawLayer(Graphics g)
        {
            if(!Debug.Items.Instance.Debug){return;}

            int i = 0;

            foreach(KeyValuePair<string, object> keyValPai in Debug.Items.Instance.Elements)
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                if(Debug.Menu.Instance.IsDraw(keyValPai.Key)){
                    g.FillRectangle(
                        DebugItems.BRUSH_BACK, 
                        DebugItems.LEFT, 
                        i*DebugItems.TOP, 
                        DebugItems.WIDTH, 
                        DebugItems.HEIGHT
                    );
                    g.DrawString(
                        keyValPai.Value.ToString(),
                        new Font(
                            DebugItems.FONT_STYLE, 
                            DebugItems.FONT_SIZE
                        ),
                        DebugItems.BRUSH_FONT,
                        DebugItems.LEFT,
                        i*DebugItems.TOP
                    );
                    i++;
                }
            }
        }
    }
}