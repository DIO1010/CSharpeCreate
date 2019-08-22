using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Const
{
    public sealed class Image
    {
        private static Image myself_ = new Image(); 
        // private static Dictionary<string,Bitmap> images_ = new Dictionary<string,Bitmap>();
        private static Dictionary<string,Bitmap> images_;
        // private Dictionary<string,Bitmap> images_;

        public static Image Instance
        {
            get
            {
                return myself_;
            }
        }

        public static Bitmap GetImage(string key)
        {
            if(images_.ContainsKey(key))
            {
                return images_[key];
            }
            else
            {
                Utilities.Logger.ErrorKey(key);
                return images_["Transparent"];
            }
        }

        private string FileName(string file)
        {
            Regex r = new Regex("[A-z].+/");
            string fn = r.Replace(file,"");
            fn = fn.Replace(".png","");
            return fn;
            // string fn = file.Replace("Image/","");
            // fn = fn.Replace("Backgounrd/","");
            // fn = fn.Replace("Character/","");
            // fn = fn.Replace("Button/","");
            // fn = fn.Replace(".png","");
        }

        private Image()
        {
            images_ = new Dictionary<string,Bitmap>();
            string[] files = System.IO.Directory.GetFiles(Utilities.String.Image,"*",System.IO.SearchOption.AllDirectories);
            foreach(string file in files)
            {
                try
                {
                    string fn = file.Replace("\\","/");
                    System.IO.FileStream fileStream = System.IO.File.OpenRead(fn);
                    System.Drawing.Image image = 
                        System.Drawing.Image.FromStream(
                            fileStream,
                            false,
                            false
                        );
                    images_.Add(FileName(fn),new Bitmap(image));
                    Utilities.Logger.Message("画像ファイルキーに追加:"+FileName(fn));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void UpdateParam()
        {
            return;
        }
    }
}