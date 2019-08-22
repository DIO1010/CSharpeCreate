using Const;
using System;
using Utilities;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Layers
{
    public class DebugMenuLayer : Layer
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
            
            if(!Debug.Menu.Instance.DebugMode){return;}
            if(!Debug.Menu.Instance.Debug){return;}

            // 背景
            g.FillRectangle(
                DebugMenu.BRUSH_BACK, 
                DebugMenu.LEFT, 
                DebugMenu.TOP, 
                DebugMenu.WIDTH, 
                DebugMenu.HEIGHT);
            // 選択中のアイテムの背景
            g.FillRectangle(
                DebugMenu.BRUSH_SELECT, 
                DebugMenu.ITEM_LEFT, 
                DebugMenu.ITEM_TOP,
                DebugMenu.ITEM_WIDTH, 
                DebugMenu.ITEM_HEIGHT);
            
            int i = 0;
            Font font = new Font(DebugMenu.FONT_STYLE,DebugMenu.FONT_SIZE);
            foreach(KeyValuePair<string, string> keyValPai in Debug.Menu.Instance.Elements)
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawString(
                    keyValPai.Value.ToString(),
                    font,
                    Brushes.White,
                    DebugMenu.LEFT+DebugMenu.FONT_SIZE,
                    i*(DebugMenu.FONT_SIZE+DebugMenu.ITEM_PADDING)
                );
                i++;
            }

            i = 0;
            foreach(KeyValuePair<string, bool> keyValPai in Debug.Menu.Instance.IsElements)
            {
                if(keyValPai.Value){
                    g.FillRectangle(
                        DebugMenu.BRUSH_TRUE, 
                        DebugMenu.LEFT+DebugMenu.PADDING, 
                        (DebugMenu.FONT_SIZE+DebugMenu.ITEM_PADDING)*i+DebugMenu.PADDING, 
                        DebugMenu.CHECK_SIZE,
                        DebugMenu.CHECK_SIZE
                    );
                }
                else
                {
                    g.FillRectangle(
                        DebugMenu.BRUSH_FALSE, 
                        DebugMenu.LEFT+DebugMenu.PADDING, 
                        (DebugMenu.FONT_SIZE+DebugMenu.ITEM_PADDING)*i+DebugMenu.PADDING, 
                        DebugMenu.CHECK_SIZE,
                        DebugMenu.CHECK_SIZE
                    );
                }
                i++;
            }
            if(Debug.Menu.Instance.IsElements["ReloadConfig"])
            {
                // Console.WriteLine(Form.ActiveForm.Name);
                // Logger.Message(Application.OpenForms[0].ToString());
                // GameForm f = Application.OpenForms[0];
                Config.Instance.Reload();
                GameForm f = (GameForm)Application.OpenForms[0];
                f.ReloadConfig();
                // f.Refresh();
                Debug.Menu.Instance.IsElements["ReloadConfig"] = false;
            }
            if(Debug.Menu.Instance.IsElements["ReloadScript"])
            {
                Config.Instance.Reload();
                GameForm f = (GameForm)Application.OpenForms[0];
                f.ReloadScript();
                Debug.Menu.Instance.IsElements["ReloadScript"] = false;
            }
        }
    }
}