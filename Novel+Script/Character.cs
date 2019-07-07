using System;
using System.Drawing;

public class Character{
    private Image image;
    private int x;
    private int y;

    public Character(Image image,int x,int y){
        this.image = image;
        this.x = x;
        this.y = y;
    }

    public Image Image{
        set{
            this.image = value;
        }
        get{
            return this.image;
        }
    }

    public int X{
        set{
            this.x = value;
        }
        get{
            return this.x;
        }
    }

    public int Y{
        set{
            this.y = value;
        }
        get{
            return this.y;
        }
    }
}
