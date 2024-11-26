


public class AsciiRenderer : IWidgetRenderer
{
    private int _sizeX, _sizeY;
    private bool _collisionMade;
    private int _curX;
    private int _curY;

    public AsciiRenderer(int sizeX, int sizeY) {
        _sizeX = sizeX;
        _sizeY = sizeY;
    }

    public void Draw(Square square)
    {
        _collisionMade = false;
    }

    public void Draw(Circle circle)
    {
        var xDif = circle.Position.x - _curX;
        var yDif = circle.Position.y - _curY;
        var sqrDist = (double)(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));
        if (sqrDist <= Math.Pow(circle.Diameter / 2.0, 2)) {
            _collisionMade = true;
        }

    }

    public void Draw(Rect rect)
    {
        _collisionMade = false;
    }

    public void Draw(Ellipse ellipse)
    {
        _collisionMade = false;
    }

    public void Draw(Textbox textbox)
    {
        _collisionMade = false;
    }

    public void Draw(CompoundWidget compoundWidget)
    {
        _collisionMade = false;
    }

    public void Draw(Text text)
    {
        _collisionMade = false;
    }

    public void Draw(IEnumerable<IWidget> widgets)
    {
        for (int y = 0; y < _sizeY; y++) {
            for (int x = 0; x < _sizeX; x++) {
                if (y == 0 || y == _sizeY - 1 || x == 0 || x == _sizeX - 1) {
                    Console.Write("# ");
                    continue;
                }
                _collisionMade = false;
                _curX = x;
                _curY = _sizeY - y;
                foreach (var widget in widgets) {
                    widget.DrawWith(this);
                    if (_collisionMade) { break; }
                }
                if (_collisionMade) { Console.Write("# "); }
                else { Console.Write("  "); }
            }
            Console.Write("\n");
        }
    }
}