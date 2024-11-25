
public struct Textbox : IWidget
{
    public string TextContent { get; set; }
    public uint Width { get; set; }
    public uint Height { get; set; }
    public Position Position { get; set; }
    
    public Textbox(uint width, uint height, string text, Position pos) {
        WidgetUtils.CheckDimentions(width, height);
        TextContent = text;
        Width = width;
        Height = height;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }

}