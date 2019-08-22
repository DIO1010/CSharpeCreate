using System;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // Scriptファイル読み込みを変更する。
    public class JampScript : Command
    {
        // Scriptを読み込む対象ファイル名
        private string target_;
        public JampScript(Queue<string> scriptContext)
        {
            // スクリプトで読み込んだ内容を実行できるものに整形。
            // Queueで内容を取得。
            while (scriptContext.Count > 0) {
                // 属性target
                if(scriptContext.Peek().Contains("target"))
                {
                    target_ = GetNeedInfomation(scriptContext.Dequeue());
                }
                // 例外属性
                else
                {
                    Utilities.Logger.ErrorArgs(scriptContext.Peek());
                }
            }
            Utilities.Logger.Message("target:["+target_+"]");
        }

        // 実行内容
        public override bool Execute(GameLayerManager GML, ScriptMachine SM)
        {
            // Scriptの内容をリロードする。
            SM.Reload(Utilities.String.Script+target_);
            return true;
        }
    }
}