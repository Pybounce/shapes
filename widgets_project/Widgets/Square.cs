public struct Square: IWidget {

    public uint Size { get; set; }
    public Position Position { get; set; }

    public Square(uint size = 1, Position pos = default) {
        WidgetUtils.CheckDimentions(size);
        Size = size;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}