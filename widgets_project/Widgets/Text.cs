
public struct Text : IWidget
{
    public string TextContent { get; set; }
    public Position Position { get; set; }
    
    public Text(string text = "", Position pos = default) {
        TextContent = text;
        Position = pos;
    }

    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}