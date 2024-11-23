
public class Textbox : Widget
{
    public Textbox(uint width, uint height, string text, Position pos): base(pos) {
        throw new NotImplementedException();
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}