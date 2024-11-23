public class Square: Shape {

    private uint _size;

    public Square(uint size, Position pos) : base(pos) {
        _size = size;
    }

    public override void Draw() {
        Console.WriteLine($"Square {_position.AsDrawnString()} size={_size}");
    }
}