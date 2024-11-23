
public abstract class Shape {
    protected Position _position;
    public Shape(Position pos) {
        _position = pos;
    }

    public abstract void Draw();
}

//public class Circle: Shape {

//}

public class Square: Shape {

    private uint _width;
    private uint _height;

    public Square(uint width, uint height, Position pos) : base(pos) {
        _width = width;
        _height = height;
    }

    public override void Draw() {
        Console.WriteLine($"Square {_position.AsDrawnString()} width={_width} height={_height}");
    }
}

public struct Position {
    public int x;
    public int y;

    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public string AsDrawnString() {
        return $"({x}, {y})";
    }
}