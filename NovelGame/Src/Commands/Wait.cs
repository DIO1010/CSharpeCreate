using System;
using Utilities;
using System.Reflection;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // 一定時間待機します。
    public class Wait : Command
    {
        // 待機時間
        private int time_msec_;
        // 待機開始時間
        private int startTime_;

        public Wait(Queue<string> scriptContext)
        {
            do {
                if(scriptContext.Peek().Contains("time"))
                {
                    time_msec_ = int.Parse(GetNeedInfomation(scriptContext.Peek()));
                }
                else
                {
                Logger.ErrorArgs(scriptContext.Peek());
                }
                scriptContext.Dequeue();
            } while (scriptContext.Count > 0);
        }

        // 実行内容
        public override bool Execute(GameLayerManager GML,ScriptMachine SM)
        {
            if(startTime_ == 0)
            {
                startTime_ = System.Environment.TickCount;
            }
            if(IsExecutingTime())
            {
                Utilities.ControlReturn.Instance.Flag = false;
                return false;
            }
            Logger.Message(ElapsedTime()+"ms待ちました。");
            Utilities.ControlReturn.Instance.Flag = true;
            return true;
        }

        // 実行時間中か
        private bool IsExecutingTime()
        {
            return ElapsedTime() <= time_msec_;
        }

        // 経過時間を取得
        private float ElapsedTime()
        {
            return System.Environment.TickCount - startTime_;
        }
    }
}
