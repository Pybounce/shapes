public struct Square: IWidget {

    public uint Size { get; set; }
    public Position Position { get; set; }

    public Square(uint size, Position pos) {
        if (size <= 0) { throw new Exception("Widget dimentions cannot be below 1"); }
        Size = size;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}