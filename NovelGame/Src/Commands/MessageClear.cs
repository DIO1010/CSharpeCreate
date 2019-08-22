using System;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // セリフレイヤーの内容をクリアする。
    public class MessageClear : Command 
    {
        // 実行内容
        public override bool Execute (GameLayerManager GML,ScriptMachine SM) 
        {
            GML.ChangeLayerMessageText ("");
            return true;
        }
    }
}