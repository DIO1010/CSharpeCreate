using Const;
using System;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // 選択肢の内容を決める。
    public class Link : Command 
    {
        // 選択肢選択後の遷移先ラベル
        private string target_ = "";
        // 選択肢に表示される内容
        private string value_ = "";

        public Link (Queue<string> scriptContext) 
        {
            // スクリプトで読み込んだ内容を実行できるものに整形。
            // Queueで内容を取得。
            while (scriptContext.Count > 0) {
                // 属性target
                if(scriptContext.Peek().Contains("target"))
                {
                    target_ = GetNeedInfomation(scriptContext.Dequeue());
                }
                // 属性value
                else if(scriptContext.Peek().Contains("value"))
                {
                    value_ = GetNeedInfomation(scriptContext.Dequeue());
                }
                // 例外属性
                else
                {
                    Utilities.Logger.ErrorArgs(scriptContext.Peek());
                }
            }
            Utilities.Logger.Message("target:["+target_+"], value:["+value_+"]");
        }

        public override bool Execute (GameLayerManager GML,ScriptMachine SM) 
        {
            // レイヤーID
            string index = "ChoiceLayer"+(Choice.Count++).ToString();
            // 選択肢レイヤーを準備
            var layer = new Layers.ChoiceLayer(
                Choice.LEFT,
                Choice.TOP*Choice.Count,
                Choice.Count-1,
                target_,
                value_
            );
            // 選択肢レイヤーを追加
            GML.AddLayer(index,layer);
            
            // 選択肢内容をデバッグ画面でできるように追加
            Debug.Items.Instance.ParamAdd(index,layer);

            return true;
        }
    }
}