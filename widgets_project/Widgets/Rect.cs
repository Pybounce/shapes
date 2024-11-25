public class Rect: Widget {

    public uint Width { get; protected set; }
    public uint Height { get; protected set; }

    public Rect(uint width, uint height, Position pos) : base(pos) {
        Width = width;
        Height = height;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}