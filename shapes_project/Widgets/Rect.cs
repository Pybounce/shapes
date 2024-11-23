public class Rect: Widget {

    private uint _width;
    private uint _height;

    public Rect(uint width, uint height, Position pos) : base(pos) {
        _width = width;
        _height = height;
    }

    public override void Draw() {
        Console.WriteLine($"Rect {_position.AsDrawnString()} width={_width} height={_height}");
    }
}