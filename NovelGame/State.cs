using System;
using System.Drawing;
using System.Windows.Forms;

public abstract class State
{
    public virtual Bitmap GetDrawImage()
    {
        return new Bitmap(Utility.GetImagePath()+"Transparent.png");
    }
}

public class NovelState : State
{
    private NovelStateLayerManagement novelStateLayerManagement;

    public NovelState(Form form,int width,int height)
    {
        novelStateLayerManagement = new NovelStateLayerManagement(width,height);
        form.KeyDown += new KeyEventHandler(this.OnKeyDown);
        // ちゃんと動作するかをテスト
        novelStateLayerManagement.ChangeLayerImage("BackgroundLayer",new Bitmap(Utility.GetImagePath()+"sample3.png"));
        novelStateLayerManagement.ChangeLayerImage("CharacterLayer0",new Bitmap(Utility.GetImagePath()+"sample1.png"));
        novelStateLayerManagement.ChangeLayerPoint("CharacterLayer0",new Point(50,150)); // マジックナンバー
        novelStateLayerManagement.ChangeLayerImage("CharacterLayer1",new Bitmap(Utility.GetImagePath()+"sample4.png"));
        novelStateLayerManagement.ChangeLayerPoint("CharacterLayer1",new Point(200,100)); // マジックナンバー
        novelStateLayerManagement.ChangeLayerImage("CharacterLayer2",new Bitmap(Utility.GetImagePath()+"sample1.png"));
        novelStateLayerManagement.ChangeLayerPoint("CharacterLayer2",new Point(450,150)); // マジックナンバー
        novelStateLayerManagement.ChangeLayerImage("MessageFrameLayer",new Bitmap(Utility.GetImagePath()+"textframe.png"));
        novelStateLayerManagement.ChangeLayerPoint("MessageFrameLayer",new Point(10,300)); // マジックナンバー
        novelStateLayerManagement.ChangeLayerMessageText("テスト。テスト。テスト。テスト。テスト。テスト。テスト。テスト。\n改行テスト。");
        // テスト終了
    }

    public override Bitmap GetDrawImage()
    {
        return novelStateLayerManagement.GetDrawLayerImage();
    }

    public void OnKeyDown(object sender,KeyEventArgs e)
    {
        novelStateLayerManagement.MessageTextIndexMax();
    }
}
