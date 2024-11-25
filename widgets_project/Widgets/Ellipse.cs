
public struct Ellipse : IWidget
{
    public uint HorizontalD { get; set; }
    public uint VerticalD { get; set; }
    public Position Position { get; set; }

    public Ellipse(uint hd, uint vd, Position pos) {
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