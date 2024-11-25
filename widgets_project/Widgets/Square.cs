public struct Square: IWidget {

    public uint Size { get; set; }
    public Position Position { get; set; }

    public Square(uint size, Position pos) {
        WidgetUtils.CheckDimentions(size);
        Size = size;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}