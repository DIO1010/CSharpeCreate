using System;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // 画像関連レイヤーを変更する。
    public class ChangeImage : Command
    {
        // 画像ファイル名
        private string filename_;
        // レイヤーID
        private string currentLayreId_;
        // 上端座標
        private int top_;
        // 左端座標
        private int left_;

        public ChangeImage(Queue<string> scriptContext)
        {
            // スクリプトで読み込んだ内容を実行できるものに整形。
            // Queueで内容を取得。
            do 
            {
                // 属性storage
                if(scriptContext.Peek().Contains("storage"))
                {
                    filename_ = GetNeedInfomation(scriptContext.Peek());
                }
                // 属性layer
                else if(scriptContext.Peek().Contains("layer"))
                {
                    // レイヤーIDを判断。
                    string id = GetNeedInfomation(scriptContext.Peek());
                    string characterId = Const.Character.NAME.Replace("2","");
                    switch(id)
                    {
                        case "base":
                        currentLayreId_ = Const.Background.NAME;
                        break;
                        case "0":
                        currentLayreId_ = characterId+"0";
                        break;
                        case "1":
                        currentLayreId_ = characterId+"1";
                        break;
                        case "2":
                        currentLayreId_ = characterId+"2";
                        break;
                        case "3":
                        currentLayreId_ = Const.MessageFrame.NAME;
                        break;
                        default:
                        Logger.ErrorArgs(scriptContext.Peek());
                        break;
                    }
                }
                // 属性top
                else if(scriptContext.Peek().Contains("top"))
                {
                    top_ = int.Parse(GetNeedInfomation(scriptContext.Peek()));
                }
                // 属性left
                else if(scriptContext.Peek().Contains("left"))
                {
                    left_ = int.Parse(GetNeedInfomation(scriptContext.Peek()));
                }
                // 例外属性
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
            // 画像を配置する座標を計算。
            // 基準となる大きさの何倍かで判断。
            float l = left_*Utilities.Config.Instance.Width;
            float t = top_*Utilities.Config.Instance.Height;
            // どちらか片方がゼロでないなら、座標も変更する。
            if(l != 0f || t != 0f)
            {
                GML.ChangeLayerPoint(currentLayreId_,new Point((int)l,(int)t));
                Logger.Change(currentLayreId_+":("+l+","+t+")");
            }
            // レイヤーIDの画像を差し替える。
            GML.ChangeLayerImage(currentLayreId_,Const.Image.GetImage(filename_));
            Logger.Change(currentLayreId_+":["+filename_+"]");
            return true;
        }
    }
}
