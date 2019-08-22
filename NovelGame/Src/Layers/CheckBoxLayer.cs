using System;
using System.IO;
using Utilities;
using System.Drawing;
using System.Collections.Generic;

namespace Layers
{
	public class CheckBoxListLayer : Layer
	{
		private Point point_;
		private Dictionary<string,Bitmap> images_;
		private List<string> values_;
		private List<string[]> valuesSplit_;
		private List<bool> isSelects_;
		private string method_;

		public CheckBoxListLayer(Queue<string> line)
		{
			images_ = new Dictionary<string,Bitmap>();
			values_ = new List<string>();
			valuesSplit_ = new List<string[]>();
			isSelects_ = new List<bool>();

			int left = 0;
			int top = 0;
			string filename = "Transparent";

			while(line.Count > 0)
			{
				if(line.Peek().Contains("left"))
				{
					left = Int32.Parse(GetNeedInfomation(line.Dequeue()));
				}
				else if(line.Peek().Contains("top"))
				{
					top = Int32.Parse(GetNeedInfomation(line.Dequeue()));
				}
				else if(line.Peek().Contains("storage"))
				{
					filename = GetNeedInfomation(line.Dequeue());
				}				
				else if(line.Peek().Contains("method"))
				{
					method_ = GetNeedInfomation(line.Dequeue());
				}				
				else if(line.Peek().Contains("value"))
				{
					string needStr = GetNeedInfomation(line.Dequeue());
					values_.Add(needStr);
					valuesSplit_.Add(SpritValue(needStr));
					isSelects_.Add(false);
				}				
			}

			images_.Add("on",Const.Image.GetImage(filename+"_on"));
			images_.Add("off",Const.Image.GetImage(filename+"_off"));
			point_ = new Point(left,top);

			string[] lines = File.ReadAllLines("./Config/config.conf");
			int i = 0;
			foreach(string str in values_)
			{
				if(str.Contains(lines[0]+"x"+lines[1]))
				{
					isSelects_[i] = true;
				}
				i++;
			}
		}

		public override Point Point
		{
			get
			{
				return point_;
			}
			set
			{
				point_ = value;
			}
		}

		public bool TransSelect()
		{
			int index = MouseHover();
			if(index >= 0)
			{
				for(int i = 0;i < isSelects_.Count;i++)
				{
					isSelects_[i] = false;
				}
				isSelects_[index] = true;
				Const.CheckBoxList.UpdateInformation(valuesSplit_[index]);
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return System.String.Format(
				"CheckBoxListLayer:[method:{0}]",method_);
		}

		public int MouseHover()
		{
			int i = 0;
			int x = Utilities.MousePoint.Instance.X;
			int y = Utilities.MousePoint.Instance.Y;
			foreach(string str in values_)
			{
				int y_i = point_.Y+(images_["on"].Height+Const.CheckBoxList.Padding)*i;
				if(x < (int)point_.X*Config.Instance.Width){
					i++;
					continue;
				} 
				if((point_.X+images_["on"].Width)*Config.Instance.Width < x)
				{
					i++;
					continue;
				}
				if(y < (int)(y_i*Config.Instance.Height))
				{
					i++;
					continue;
				}
				if((int)(y_i+images_["on"].Height)*Config.Instance.Height < y)
				{
					i++;
					continue;
				}
				return i;
			}
            return -1;
		}

		public override void DrawLayer(Graphics g)
		{
			for(int i = 0;i < values_.Count;i++)
			{
				if(isSelects_[i])
				{
					DrawImage(g,"on",i);
				}
				else
				{
					DrawImage(g,"off",i);
				}
			}
		}

		private void DrawImage(Graphics g,string key)
        {
            if(images_.ContainsKey(key))
            {
                g.DrawImage(
                    images_[key],
                    point_.X*Config.Instance.Width,
                    point_.Y*Config.Instance.Height,
                    images_[key].Width*Config.Instance.Width,
                    images_[key].Height*Config.Instance.Height
                );
            }
            else
            {
                Utilities.Logger.ErrorKey(key);
            }
        }

		private void DrawImage(Graphics g,string key,int index)
        {
            if(images_.ContainsKey(key))
            {
                g.DrawImage(
                    images_[key],
                    point_.X*Config.Instance.Width,
                    Top(index,key)*Config.Instance.Height,
                    images_[key].Width*Config.Instance.Width,
                    images_[key].Height*Config.Instance.Height
                );
                g.DrawString(
                    values_[index],
					new Font(
						Const.CheckBoxList.FONT_STYLE,
						Const.CheckBoxList.FONT_SIZE
					),
					Const.CheckBoxList.BRUSH,
                    StringLeft(index,key)*Config.Instance.Width,
                    (Top(index,key)+Const.CheckBoxList.Padding/2)*Config.Instance.Height
                );
            }
            else
            {
                Utilities.Logger.ErrorKey(key);
            }
        }

		private int Top(int index,string key)
		{
			int y = point_.Y+(images_[key].Height+Const.CheckBoxList.Padding)*index;
			return y;
		}

		private int StringLeft(int index,string key)
		{
			return (point_.X+images_[key].Width+Const.CheckBoxList.Padding);
		}

		private string[] SpritValue(string value)
		{
			string[] str = value.Split('x');
			return str;
		}
	}
}