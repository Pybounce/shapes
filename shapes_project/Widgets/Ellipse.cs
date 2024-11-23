
public class Ellipse : Widget
{
    public Ellipse(uint hd, uint vd, Position pos): base(pos) {
        throw new NotImplementedException();
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}