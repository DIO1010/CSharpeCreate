using System;
using System.IO;
using Utilities;
using System.Drawing;
using System.Reflection;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Commands
{
    // Scriptのタグを実装しているCommandを継承している。
    // トランジョンを実装する。
    public class Transion : Command
    {
        // メソッドタイプ
        private int methodType_;
        // 方向
        // Scrollにしか使わない。
        private int fromType_;
        // 遷移時間
        private int time_msec_;
        // 遷移先の画像
        private Bitmap nextImage_;
        // 遷移元の画像
        private Bitmap preImage_;
        // 遷移開始時間
        private int startTime_;
        // 描写内容のバッファー関連
        private Bitmap canvas_;
        private Graphics g_;

        // メソッド名構造体
        private enum MethodTyepe_
        {
            Crossfade,
            Scroll
        }

        // 方向構造体
        private enum FromType_
        {
            Top,
            Bottom,
            Right,
            Left
        }

        public Transion(Queue<string> scriptContext)
        {
            // スクリプトで読み込んだ内容を実行できるものに整形。
            // Queueで内容を取得。
            do {
                // 属性storage
                if(scriptContext.Peek().Contains("storage"))
                {
                    string filename = GetNeedInfomation(scriptContext.Peek());
                    nextImage_ = Const.Image.GetImage(filename);
                }
                // 属性method
                else if(scriptContext.Peek().Contains("method"))
                {
                    switch(GetNeedInfomation(scriptContext.Peek()))
                    {
                        case "crossfade":
                        methodType_ = (int)MethodTyepe_.Crossfade;
                        break;
                        case "scroll":
                        methodType_ = (int)MethodTyepe_.Scroll;
                        break;
                        default:
                        Logger.ErrorArgs(scriptContext.Peek());
                        break;
                    }
                }
                // 属性from
                else if(scriptContext.Peek().Contains("from"))
                {
                    switch(GetNeedInfomation(scriptContext.Peek()))
                    {
                        case "top":
                        fromType_ = (int)FromType_.Top;
                        break;
                        case "bottom":
                        fromType_ = (int)FromType_.Bottom;
                        break;
                        case "right":
                        fromType_ = (int)FromType_.Right;
                        break;
                        case "left":
                        fromType_ = (int)FromType_.Left;
                        break;
                        default:
                        Logger.ErrorArgs(scriptContext.Peek());
                        break;
                    }
                }
                // 属性time
                else if(scriptContext.Peek().Contains("time"))
                {
                    time_msec_ = (int)int.Parse(
                        GetNeedInfomation(scriptContext.Peek())
                    );
                }
                // 例外属性
                else
                {
                    Logger.ErrorArgs(scriptContext.Peek());
                }
                scriptContext.Dequeue();
            } while (scriptContext.Count > 0);

            // 描画バッファ関連の初期化
            canvas_ = new Bitmap(nextImage_.Width,nextImage_.Height);
            g_ = Graphics.FromImage(canvas_);
        }

        // 実行内容
        public override bool Execute(GameLayerManager GML,ScriptMachine SM)
        {
            // 遷移前の画像が未定義なら
            // つまり、初回の実行なら
            if(preImage_ == null)
            {
                // 遷移前の画像を取得
                preImage_ = GML.GetImage(Const.Background.NAME);

                // 遷移開始時間を取得
                startTime_ = System.Environment.TickCount;
                Logger.Message("トランジョンを開始しました。");
            }

            // 遷移実行時間中か
            if(IsExecutingTime())
            {
                Utilities.ControlReturn.Instance.Flag = false;
                // メソッドによって処理内容を変更。
                switch(methodType_)
                {
                    // メソッドcrossfade
                    case (int)MethodTyepe_.Crossfade:
                    g_.DrawImage(
                        nextImage_      ,
                        0               ,
                        0               ,
                        nextImage_.Width,
                        nextImage_.Height
                    );
                    int alpha = (int)(255*(1 - ElapsedTime() / time_msec_)); 
                    g_.DrawImage(
                        Utilities.TransMethod.CrossfadeImg(preImage_,alpha),
                        0                            ,
                        0                            ,
                        preImage_.Width              ,
                        preImage_.Height
                    );
                    GML.ChangeLayerImage(Const.Background.NAME,canvas_);
                    return false;
                    // メソッドscroll
                    case (int)MethodTyepe_.Scroll:
                    int border;
                    switch(fromType_)
                    {
                        // 方向上
                        case (int)FromType_.Top:
                        border = 
                            (int)(
                                preImage_.Height * ElapsedTime() / time_msec_
                            );
                        g_.DrawImage(
                            Utilities.TransMethod.Scroll(nextImage_,preImage_,border,fromType_),
                            0                                  ,
                            0                                  ,
                            preImage_.Width                    ,
                            preImage_.Height
                        );
                        GML.ChangeLayerImage(Const.Background.NAME,canvas_);
                        return false;
                        // 方向下
                        case (int)FromType_.Bottom:
                        border = 
                            (int)(
                                preImage_.Height*(1 - ElapsedTime() / time_msec_
                            )
                        );
                        g_.DrawImage(
                            Utilities.TransMethod.Scroll(preImage_,nextImage_,border,fromType_),
                            0                                  ,
                            0                                  ,
                            preImage_.Width                    ,
                            preImage_.Height
                        );
                        GML.ChangeLayerImage(Const.Background.NAME,canvas_);
                        return false;
                        // 方向右
                        case (int)FromType_.Right:
                        border = 
                            (int)(
                                preImage_.Width*(1 - ElapsedTime() / time_msec_
                            )
                        );
                        g_.DrawImage(
                            Utilities.TransMethod.Scroll(preImage_,nextImage_,border,fromType_),
                            0                                  ,
                            0                                  ,
                            preImage_.Width                    ,
                            preImage_.Height
                        );
                        GML.ChangeLayerImage(Const.Background.NAME,canvas_);
                        return false;
                        // 方向左
                        case (int)FromType_.Left:
                        border = 
                            (int)(
                                preImage_.Width * ElapsedTime() / time_msec_
                            );
                        g_.DrawImage(
                            Utilities.TransMethod.Scroll(nextImage_,preImage_,border,fromType_),
                            0                                  ,
                            0                                  ,
                            preImage_.Width                    ,
                            preImage_.Height
                        );
                        GML.ChangeLayerImage(Const.Background.NAME,canvas_);
                        return false;
                    }
                    break;
                }
            }
            else
            {
                GML.ChangeLayerImage(Const.Background.NAME,nextImage_);
                Logger.Message(
                    "トランジョンを"+(int)ElapsedTime()+"msで終了しました。"
                );
                Utilities.ControlReturn.Instance.Flag = true;
                return true;
            }
            return true;
        }

        // 経過時間を取得
        private float ElapsedTime()
        {
            return System.Environment.TickCount - startTime_;
        }

        // 実行時間中か
        private bool IsExecutingTime()
        {
            return ElapsedTime() <= time_msec_;
        }
    }
}