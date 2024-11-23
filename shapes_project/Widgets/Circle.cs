
public class Circle : Widget
{
    public Circle(uint d, Position pos): base(pos) {
        throw new NotImplementedException();
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}