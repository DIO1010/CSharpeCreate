using System;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // 選択肢選択まで待機する。
    public class LinkStop : Command 
    {
        // 実行内容
        public override bool Execute (GameLayerManager GML,ScriptMachine SM) 
        {
            // 選択肢選択されるまで、待機。
            if(Const.Choice.IsSelect)
            {
                // 選択肢がレイヤーにあるか。
                if(GML.ContainsLayer("ChoiceLayer0"))
                {
                    // 選択されたIDをLog出力
                    Utilities.Logger.Message("Select Index is "+Const.Choice.INDEX +".");
                    // 選択された選択肢の遷移先のラベルに変更。
                    SM.CurrentLabel = GML.GetLayer("ChoiceLayer"+Const.Choice.INDEX.ToString()).Target;
                    
                    // レイヤー削除
                    GML.RemoveLayer("ChoiceLayer0");
                    GML.RemoveLayer("ChoiceLayer1");
                    GML.RemoveLayer("ChoiceLayer2");

                    GML.IsNextMessage = false;

                    // デバッグ画面からも削除
                    Debug.Items.Instance.ParamRemove("ChoiceLayer0");
                    Debug.Items.Instance.ParamRemove("ChoiceLayer1");
                    Debug.Items.Instance.ParamRemove("ChoiceLayer2");

                    // 選択肢の定数をリセット
                    Const.Choice.Count = 0;
                    Const.Choice.INDEX = 0;
                    Const.Choice.IsSelect = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}