public struct Rect: IWidget {

    public uint Width { get; set; }
    public uint Height { get; set; }
    public Position Position { get; set; }

    public Rect(uint width, uint height, Position pos) {
        if (width <= 0 || height <= 0) { throw new Exception("Widget dimentions cannot be below 1"); }
        Width = width;
        Height = height;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}