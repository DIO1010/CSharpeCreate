using System;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // セリフ関連を実装。
    public class Message : Command 
    {
        // セリフ表示内容
        private string drawMessage_;
        // 初期ロードか
        private bool isFirstLoad_;

        public Message (string drawMessage) 
        {
            // 表示内容を取得
            this.drawMessage_ = drawMessage;

            // キャラクター名が含まれるかどうか
            if(drawMessage_.IndexOf("[") < 0)
            {
                drawMessage_ = drawMessage_.Insert(0,"\n");
            }

            isFirstLoad_ = true;
        }

        // 実行内容
        public override bool Execute (GameLayerManager GML,ScriptMachine SM) 
        {
            // セリフが表示しきり、次の実行に遷移していいかを判断。
            if (GML.IsTextCountMax () && GML.IsNextMessage) 
            {
                GML.IsNextMessage = false;
                return true;
            }
            else
            {
                // 初回ロードのみ、セリフの内容を転写する。
                if (isFirstLoad_) 
                {
                    GML.ChangeLayerMessageText (drawMessage_);
                    isFirstLoad_ = false;
                    return false;
                }
                return false;
            }
        }
    }
}