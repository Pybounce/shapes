public class Square: Widget {

    public uint Size { get; protected set; }

    public Square(uint size, Position pos) : base(pos) {
        Size = size;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}