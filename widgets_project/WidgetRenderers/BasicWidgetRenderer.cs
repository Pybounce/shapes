

public class BasicWidgetRenderer : IWidgetRenderer
{
    public virtual void Draw(Square square)
    {
        Console.WriteLine($"Square ({square.Position.x},{square.Position.y}) size={square.Size}");
    }

    public virtual void Draw(Circle circle)
    {
        Console.WriteLine($"Circle ({circle.Position.x},{circle.Position.y}) size={circle.Diameter}");
    }

    public virtual void Draw(Rect rect)
    {
        Console.WriteLine($"Rectangle ({rect.Position.x},{rect.Position.y}) width={rect.Width} height={rect.Height}");
    }

    public virtual void Draw(Ellipse ellipse)
    {
        Console.WriteLine($"Ellipse ({ellipse.Position.x},{ellipse.Position.y}) diameterH = {ellipse.HorizontalD} diameterV = {ellipse.VerticalD}");
    }

    public virtual void Draw(Textbox textbox)
    {
        Console.WriteLine($"Textbox ({textbox.Position.x},{textbox.Position.y}) width={textbox.Width} height={textbox.Height} Text=\"{textbox.TextContent}\"");
    }

    public virtual void Draw(Text text)
    {
        Console.WriteLine($"Text ({text.Position.x},{text.Position.y}) Content=\"{text.TextContent}\"");
    }

    public virtual void Draw(CompoundWidget compoundWidget)
    {
        compoundWidget.DrawWith(this);
    }

    public virtual void Draw(IEnumerable<IWidget> widgets) {
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("Requested Drawing");
        Console.WriteLine("----------------------------------------------------------------");
        foreach (var widget in widgets) {
            widget.DrawWith(this);
        }
        Console.WriteLine("----------------------------------------------------------------");
    }
}




