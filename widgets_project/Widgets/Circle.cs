
public class Circle : Widget
{
    public uint Diameter { get; protected set; }
    
    public Circle(uint d, Position pos): base(pos) {
        Diameter = d;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}