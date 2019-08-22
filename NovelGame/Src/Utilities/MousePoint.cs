using Debug;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Utilities
{
    public class MousePoint
    {
        private static MousePoint instance_ = new MousePoint();
        private int x_ = 0;
        private int y_ = 0;

        public static MousePoint Instance
        {
            get
            {
                return instance_;
            }
        }

        public int X
        {
            get
            {
                return x_;
            }
            set
            {
                x_ = value;
            }
        }

        public int Y
        {
            get
            {
                return y_;
            }
            set
            {
                y_ = value;
            }
        }

        public void Set(int x,int y)
        {
            x_ = x;
            y_ = y;
        }

        public void CursorSet(int x,int y)
        {
            GameForm f = (GameForm)Application.OpenForms[0];
            Cursor.Position = f.PointToScreen(new Point(x,y));
        }

        public override string ToString()
        {
            return ("MousePoint:[(X,Y):("+X+","+Y+")]");
        }
    }
}