
using System.Security.Cryptography;

public struct Circle : IWidget
{
    public uint Diameter { get; set; }

    public Position Position { get; set; }

    public Circle(uint d = 1, Position pos = default) {
        WidgetUtils.CheckDimentions(d);
        Diameter = d;
        Position = pos;
    }
    
    public void DrawWith(IWidgetRenderer renderer)
    {
        renderer.Draw(this);
    }
}