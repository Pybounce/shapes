public class Square: Widget {

    private uint _size;

    public Square(uint size, Position pos) : base(pos) {
        _size = size;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}