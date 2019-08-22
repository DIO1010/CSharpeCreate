using System;
using System.Collections.Generic;

namespace Commands
{
    // 使う予定なし。
    public class EndQueue : Command 
    {
        public EndQueue()
        {
            Utilities.Logger.Message("OK");
        }
        public override bool Execute (GameLayerManager GML, ScriptMachine SM) 
        {
            return false;
        }
    }
}