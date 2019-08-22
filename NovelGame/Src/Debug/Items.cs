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
    public sealed class Items
    {
        private static Items myself_ = new Items();
        // Debugを起動するか
        private static bool NotDebug_;
        // Debugする項目を格納
        // 内容はクラスのToString()を表示するようにしてある。
        // 内容フォーマットはそれぞれのToString()で
        private static Dictionary<string,object> items_;

        // Singleton
        public static Items Instance
        {
            get
            {
                return myself_;
            }
        }

        // Debug画面を起動させるかどうか
        public bool Debug
        {
            get
            {
                return !NotDebug_;
            }
            set
            {
                NotDebug_ = !value;
            }
        }

        public Dictionary<string,object> Elements
        {
            get
            {
                return items_;
            }
        }

        //  デバッグの表示項目を追加
        public void ParamAdd(string key,object o)
        {
            if(items_.ContainsKey(key))
            {
                items_[key] = o;
                Menu.Instance.ParamAdd(key,key);
                return;
            }
            items_.Add(key,o);
            Menu.Instance.ParamAdd(key,key);
        }

        public void ParamRemove(string key)
        {
            if(items_.ContainsKey(key)){
                items_.Remove(key);
                Menu.Instance.ParamRemove(key);
            }
            else
            {
                Utilities.Logger.ErrorKey(key);
            }
        }

        private Items()
        {
            NotDebug_ = true;
            items_ = new Dictionary<string,object>();
        }
    }
}