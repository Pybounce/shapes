
public struct Ellipse : IWidget
{
    public uint HorizontalD { get; set; }
    public uint VerticalD { get; set; }
    public Position Position { get; set; }

    public Ellipse(uint hd = 1, uint vd = 1, Position pos = default) {
        WidgetUtils.CheckDimentions(hd, vd);
        HorizontalD = hd;
        VerticalD = vd;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}