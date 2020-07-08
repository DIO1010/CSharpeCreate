using System;
using System.Drawing;
using System.Collections.Generic;

namespace Layers{
	public class SliderLayer : Layer
	{
		private PointF point_;
		// private PointF pointFore_;
        private Dictionary<string,Bitmap> images_;
		private int max_;
		private int paramIndex_;

		public SliderLayer(Queue<string> line)
		{
			images_ = new Dictionary<string, Bitmap>();

            int left = 0;
            int top = 0;
            string filename = "Transparent";
			int size = -1;

            while(line.Count > 0)
            {
                if(line.Peek().Contains("left"))
                {
                    left = Int32.Parse(GetNeedInformation(line.Dequeue()));
                }
                else if(line.Peek().Contains("top"))
                {
                    top = Int32.Parse(GetNeedInformation(line.Dequeue()));
                }
                else if(line.Peek().Contains("storage"))
                {
                    filename = GetNeedInformation(line.Dequeue());
                }
                else if(line.Peek().Contains("size"))
                {
                    size = Int32.Parse(GetNeedInformation(line.Dequeue()));
                }
            }

            images_.Add("fore",Const.Image.GetImage(filename+"_fore"));
            images_.Add("back",Const.Image.GetImage(filename+"_back"));
            point_ = new Point(left,top);
			// pointFore_ = new Point((int)(left*Utilities.Config.Instance.Width),top);
			if(size > 0)
			{
				max_ = size;
			}
			else
			{
				max_ = (int)(images_["back"].Width*Utilities.Config.Instance.Width);
			}
			paramIndex_ = (int)Utilities.Config.Instance.TextSpeed-1;
		}

		public override void DrawLayer(Graphics g)
		{
			int padding = 5;
			g.DrawString(
				"テキスト速度",
				new Font(
					Const.Slider.FONT_STYLE,
					Const.Slider.FONT_SIZE
				),
				Const.Slider.BRUSH,
				StringLeft(),
				StringTop()
			);
			g.DrawImage(
				images_["back"],
				point_.X*Utilities.Config.Instance.Width,
				(point_.Y+padding)*Utilities.Config.Instance.Height,
				images_["back"].Width*Utilities.Config.Instance.Width,
				images_["back"].Height*Utilities.Config.Instance.Height
			);
			g.DrawImage(
				images_["fore"],
				CalForeLeft(),
				point_.Y*Utilities.Config.Instance.Height,
				images_["fore"].Width*Utilities.Config.Instance.Width,
				images_["fore"].Height*Utilities.Config.Instance.Height
			);
		}

		// public void ChanePoint()
		// {
		// 	if(MouseHover())
		// 	{
		// 		int x = Utilities.MousePoint.Instance.X;
		// 		paramIndex_ = CalIndex(x);
		// 	}
		// }

		public bool ChanePoint()
		{
			if(MouseHover())
			{
				int x = Utilities.MousePoint.Instance.X;
				paramIndex_ = CalIndex(x);
				// Console.WriteLine("SliderLayer.ChangePoimnt"+paramIndex_);
				Const.Slider.UpdateInformation((paramIndex_+1).ToString());
				return true;
			}
			return false;
		}

		public bool MouseHover()
		{
			int x = Utilities.MousePoint.Instance.X;
            int y = Utilities.MousePoint.Instance.Y;
            if(x < (int)point_.X*Utilities.Config.Instance.Width) return false;
            if((point_.X+images_["back"].Width)*Utilities.Config.Instance.Width < x) return false;
            if(y < point_.Y*Utilities.Config.Instance.Height) return false;
            if((point_.Y+images_["back"].Height)*Utilities.Config.Instance.Height < y) return false;
            return true;
		}

		public override string ToString()
		{
			return String.Format("Slider:[index:{0,3}],[max:{1,3}]",paramIndex_,max_);
		}

		private int CalIndex(int x)
		{
			float f = x-point_.X*Utilities.Config.Instance.Width;
			f *= max_;
			f /= images_["back"].Width*Utilities.Config.Instance.Width;
			return (int)f;
		}

		private int CalForeLeft()
		{
			float f = point_.X*Utilities.Config.Instance.Width;
			f += (paramIndex_)*images_["back"].Width*Utilities.Config.Instance.Width/(max_-1);
			f -= (images_["fore"].Width*Utilities.Config.Instance.Width)/2;
			return (int)f;
		}

		private float StringLeft()
		{
			// int paddibng = 10;
			return point_.X*Utilities.Config.Instance.Width;
		}

		private float StringTop()
		{
			int padding = 10;
			float f = (point_.Y-padding)*Utilities.Config.Instance.Height;
			f -= Const.Slider.FONT_SIZE;
			return f;
		}
	}
}
