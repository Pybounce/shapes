
public abstract class Shape {
    protected Position _position;
    public Shape(Position pos) {
        _position = pos;
    }

    public abstract void Draw();
}


