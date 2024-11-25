
public class Ellipse : Widget
{
    public uint HorizontalD { get; protected set; }
    public uint VerticalD { get; protected set; }

    public Ellipse(uint hd, uint vd, Position pos): base(pos) {
        HorizontalD = hd;
        VerticalD = vd;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}