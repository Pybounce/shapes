
public class Text : Widget
{
    public string TextContent { get; protected set; }
    
    public Text(string text, Position pos): base(pos) {
        TextContent = text;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}