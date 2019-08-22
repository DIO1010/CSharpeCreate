using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Utilities
{
    public static class TransMethod
    {
        // 方向構造体
        private enum FromType_
        {
            Top,
            Bottom,
            Right,
            Left
        }

        // BitmapからBitmapDataを取得
        public static BitmapData GetBitmapData(Bitmap src)
        {
            return src.LockBits(
                new Rectangle(0,0,src.Width,src.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );
        }

        // Crossfadeの描画処理
        public static Bitmap CrossfadeImg(Bitmap src,int plus)
        {
            // 出力を行うbitmapData
            Bitmap dest = new Bitmap(src.Width,src.Height);

            // Bitmapをロックし、BitmapDataを取得
            BitmapData srcBitmapData = GetBitmapData(src);
            BitmapData destBitmapData = GetBitmapData(dest);

            // BitmapDataメモリに直接アクセスする。
            unsafe
            {
                byte* srcPtr = (byte*)srcBitmapData.Scan0;
                byte* destPtr = (byte*)destBitmapData.Scan0;

                for(int y = 0;y < srcBitmapData.Height;y++)
                {
                    for(int x = 0;x < srcBitmapData.Width;x++)
                    {
                        int pos = y * srcBitmapData.Stride + x * 4;
                        destPtr[pos+3] = (byte)plus;    // Alpha
                        destPtr[pos+2] = srcPtr[pos+2]; // Red
                        destPtr[pos+1] = srcPtr[pos+1]; // Green
                        destPtr[pos  ] = srcPtr[pos  ]; // Blue
                    }
                }
            }
            
            // リソース開放
            src.UnlockBits(srcBitmapData);
            dest.UnlockBits(destBitmapData);

            return dest;
        }

        unsafe public static void ChangeDestMemory(
            byte* uIPtr,
            byte* lIPtr,
            byte* destPtr,
            int pos,
            int border,
            int delta)
        {
             if(delta <= border)
            {
                destPtr[pos+3] = uIPtr[pos+3]; // Alpha
                destPtr[pos+2] = uIPtr[pos+2]; // Red
                destPtr[pos+1] = uIPtr[pos+1]; // Green
                destPtr[pos  ] = uIPtr[pos  ]; // Blue
            }
            else
            {
                destPtr[pos+3] = lIPtr[pos+3]; // Alpha
                destPtr[pos+2] = lIPtr[pos+2]; // Red
                destPtr[pos+1] = lIPtr[pos+1]; // Green
                destPtr[pos  ] = lIPtr[pos  ]; // Blue
            }
        }

        unsafe public static void TranseImageMemory(
            BitmapData upImageData,
            BitmapData lowImageData,
            BitmapData destImageData,
            int border,
            int fromType)
        {
            byte* uIPtr   = (byte*)  upImageData.Scan0;
            byte* lIPtr   = (byte*) lowImageData.Scan0;
            byte* destPtr = (byte*)destImageData.Scan0;

            for(int y = 0;y < upImageData.Height;y++)
            {
                for(int x = 0;x < upImageData.Width;x++)
                {
                    int pos = y * upImageData.Stride + x * 4;

                    switch(fromType)
                    {
                        case (int)FromType_.Top:
                        goto case (int)FromType_.Bottom;
                        case (int)FromType_.Bottom:
                        ChangeDestMemory(uIPtr,lIPtr,destPtr,pos,border,y);
                        break;
                        case (int)FromType_.Left:
                        goto case (int)FromType_.Right;
                        case (int)FromType_.Right:
                        ChangeDestMemory(uIPtr,lIPtr,destPtr,pos,border,x);
                        break;
                        default:
                        Utilities.Logger.Error("FromType");
                        break;
                    }
                }
            }
        }

        // Scrollの描画処理
        public static Bitmap Scroll(Bitmap upImage,Bitmap lowImage,int border,int fromType)
        {
            // 出力を行うbitmapData
            Bitmap dest = new Bitmap(upImage.Width,upImage.Height);

            // Bitmapをロックし、BitmapDataを取得
            BitmapData upImageData  = GetBitmapData(upImage);
            BitmapData lowImageData = GetBitmapData(lowImage);
            BitmapData destBitmapData = GetBitmapData(dest);

            // BitmapDataメモリに直接アクセスする。
            try{
                TranseImageMemory(upImageData,lowImageData,destBitmapData,border,fromType);
            }
            finally
            {
                upImage.UnlockBits(upImageData);
                lowImage.UnlockBits(lowImageData);
                dest.UnlockBits(destBitmapData);
            }
            return dest;
        }
    }
}