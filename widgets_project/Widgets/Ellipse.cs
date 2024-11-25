
public struct Ellipse : IWidget
{
    public uint HorizontalD { get; set; }
    public uint VerticalD { get; set; }
    public Position Position { get; set; }

    public Ellipse(uint hd, uint vd, Position pos) {
        if (hd <= 0 || vd <= 0) { throw new Exception("Widget dimentions cannot be below 1"); }
        HorizontalD = hd;
        VerticalD = vd;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}