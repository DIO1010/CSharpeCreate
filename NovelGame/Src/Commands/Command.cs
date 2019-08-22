using System;

namespace Commands
{
    // タグの抽象クラス
    public abstract class Command
    {
        public virtual bool Execute(GameLayerManager GML, ScriptMachine SM){return true;}

        protected string GetNeedInfomation(string rawStr)
        {
            rawStr = rawStr.Replace("\"","");
            return rawStr.Substring(rawStr.IndexOf("=")+1);
        }
    }
}
