
public class Textbox : CompoundWidget
{
    public string TextContent { get; protected set; }
    public uint Width { get; protected set; }
    public uint Height { get; protected set; }
    
    public Textbox(uint width, uint height, string text, Position pos) :
        base(pos, 
        new Rect(width, height, pos), 
        new Text(text, pos)
        ) {        
        TextContent = text;
        Width = width;
        Height = height;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }

}