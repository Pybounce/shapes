public struct Rect: IWidget {

    public uint Width { get; set; }
    public uint Height { get; set; }
    public Position Position { get; set; }

    public Rect(uint width, uint height, Position pos) {
        Width = width;
        Height = height;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}