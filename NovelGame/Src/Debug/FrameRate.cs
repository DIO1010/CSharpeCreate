using Debug;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

/*
//  Debug画面表示させる。
//  Debugを起動できるようにするには実行前に-dを入力する必要あり
//  Scriptの起動は引数ではなく、Script直下のscriptを最初のやつを読みこむ
//  StartUp時は[start.fnms]を起動させる。これは仕様とする。
*/
namespace Debug
{
    public sealed class FrameRate
    {
        private static FrameRate myself_ = new FrameRate();
        private static int oldTime_;
        private static int fps_;

        // Singleton
        public static FrameRate Instance
        {
            get
            {
                return myself_;
            }
        }
        public int FPS
        {
            get
            {
                return fps_;
            }
        }
        public void CalculationFPS()
        {
            int time = System.Environment.TickCount - oldTime_;
            if(time == 0)
            {
                time = 1;
            }
            fps_ = (int)1000 / time;
            oldTime_ = System.Environment.TickCount;
        }

        public override string ToString()
        {
            // int fps = (int)1000 / (System.Environment.TickCount - oldTime_);
            // oldTime_ = System.Environment.TickCount;
            return ("FPS["+fps_+"]");
        }

        private FrameRate()
        {
            oldTime_ = System.Environment.TickCount;
        }
    }
}