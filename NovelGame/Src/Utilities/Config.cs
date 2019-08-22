using Debug;
using System;
using System.IO;

namespace Utilities
{
    public class Config
    {
        private static Config instance_ = new Config();
        private static float width_times_;
        private static float height_times_;
        private static float text_speed_;

        private Config()
        {
            string[] lines = File.ReadAllLines("./Config/config.conf");
            width_times_ = GetTimes(lines,WIDTH_INFO,800f);
            height_times_ = GetTimes(lines,HEIGHT_INFO,600f);
            text_speed_ = GetTimes(lines,TEXT_SPEED_INFO,1f);
            if(text_speed_ < 1f)
            {
                text_speed_ = 1f;
            }
            Utilities.Logger.Message("width_times_:"+width_times_.ToString());
            Utilities.Logger.Message("height_times_:"+height_times_.ToString());
            Utilities.Logger.Message("text_speed_:"+text_speed_.ToString());
            Items.Instance.ParamAdd("Config",this);
            Items.Instance.ParamAdd("FPS",Debug.FrameRate.Instance);
        }

        public static Config Instance
        {
            get
            {
                return instance_;
            }
        }

        public float Width
        {
            get
            {
                return width_times_;
            }
        }

        public float Height
        {
            get
            {
                return height_times_;
            }
        }

        public float TextSpeed
        {
            get
            {
                return text_speed_;
            }
        }

        public static int WIDTH_INFO
        {
            get
            {
                return 0;
            }
        }

        public static int HEIGHT_INFO
        {
            get
            {
                return 1;
            }
        }

        public static int TEXT_SPEED_INFO
        {
            get
            {
                return 2;
            }
        }

        public void Reload()
        {
            string[] lines = File.ReadAllLines("./Config/config.conf");
            width_times_ = GetTimes(lines,WIDTH_INFO,800f);
            height_times_ = GetTimes(lines,HEIGHT_INFO,600f);
            text_speed_ = GetTimes(lines,TEXT_SPEED_INFO,1f);
            if(text_speed_ < 1f)
            {
                text_speed_ = 1f;
            }
        }

        public override string ToString()
        {
            return System.String.Format("Config:[WidthTime:{WIDTH_INFO}],[HeightTime:{1}],[TextSpeed:{2}]",Width,Height,TextSpeed);
        }

        private float GetTimes(string[] lines,int index,float baseNum)
        {
            float times = 1.0f;
            try
            {
                times = float.Parse(lines[index]) / baseNum;
            }catch(Exception e)
            {
                Utilities.Logger.Message(e.ToString());
                Utilities.Logger.Message("読み込みを"+baseNum.ToString()+"と判定。");
            }

            return times;
        }
    }
}