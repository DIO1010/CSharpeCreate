using Debug;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Debug
{
    public sealed class Menu
    {
        private static Menu myself_ = new Menu();
        private static bool NotDebugMode_;
        private static bool NotDebug_;
        private static Dictionary<string,string> items_;
        private static Dictionary<string,bool> is_draw_;
        private static int index_;

        public static Menu Instance
        {
            get
            {
                return myself_;
            }
        }

        public bool DebugMode
        {
            get
            {
                return !NotDebugMode_;
            }
            set
            {
                NotDebugMode_ = !value;
            }
        }

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

        public Dictionary<string,string> Elements
        {
            get
            {
                return items_;
            }
        }

        public Dictionary<string,bool> IsElements
        {
            get
            {
                return is_draw_;
            }
        }

        public int Index
        {
            get
            {
                return index_;
            }
        }

        public bool IsDraw(string key)
        {
            if(is_draw_.ContainsKey(key)){
                return is_draw_[key];
            }
            return false;
        }

        public void Up()
        {
            index_ = (items_.Count + --index_) % items_.Count;
        }

        public void Down()
        {
            index_ = ++index_ % items_.Count;
        }

        public void Enter()
        {
            // foreachでのコレクションの値変更はできない
            // 連想配列ならそのキーを格納したListでforeachすることで、値を変更できる
            int i = 0;
            List<string> keyList = new List<string>(is_draw_.Keys);

            foreach(string key in keyList)
            {
                if(i == index_){
                    is_draw_[key] = !is_draw_[key];
                }
                i++;
            }
        }

        public void ParamAdd(string key,string value)
        {
            if(items_.ContainsKey(key)){
                items_[key] = value;
                is_draw_[key] = false;
                return;
            }
            items_.Add(key,value);
            is_draw_.Add(key,false);
        }

        public void ParamRemove(string key)
        {
            items_.Remove(key);
            is_draw_.Remove(key);
            if(index_ > items_.Count)
            {
                index_ = 0;
                // int i = Const.DebugMenu.ITEM_TOP;
            }
        }


        private Menu()
        {
            NotDebugMode_ = true;
            NotDebug_ = true;
            index_ = 0;
            items_ = new Dictionary<string,string>();
            is_draw_ = new Dictionary<string,bool>();
        }
    }
}