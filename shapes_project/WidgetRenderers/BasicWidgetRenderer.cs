

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

    public virtual void Draw(Textbox circle)
    {
        throw new NotImplementedException();
    }
}




