using System;
using Utilities;

namespace Const
{
    public class Character
    {
        private static string name_ = "CharacterLayer";
        private static int width_ = (int)(400*Config.Instance.Width);
        private static int height_ = (int)(600*Config.Instance.Height);
        private static int left_ = 0;
		private static int top_ = 0;


        public static int WIDTH
        {
            get
            {
                return width_;
            }
        }

        public static int HEIGHT
        {
            get
            {
                return height_;
            }
        }

        public static int TOP
		{
			get
			{
				return top_;
			}
		}

		public static int LEFT
		{
			get
			{
				return left_;
			}
		}

        public static int Left(int x)
        {
            float n = x*Config.Instance.Width;
            return (int)n;
        }

        public static int Top(int y)
        {
            float n = y*Config.Instance.Width;
            return (int)n;
        }

        public static void UpdateParam()
        {
            width_ = (int)(400*Config.Instance.Width);

            height_ = (int)(600*Config.Instance.Height);
        }

        public static string NAME
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
            }
        }
    }
}