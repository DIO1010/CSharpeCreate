using System;

namespace Utilities
{
    public class PointF
    {
        private float x_;
        private float y_;

        public PointF(float x,float y)
        {
            x_ = x;
            y_ = y;
        }

        public float X
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

        public float Y
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
    }
}