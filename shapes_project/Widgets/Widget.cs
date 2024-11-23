
public abstract class Widget {
    protected Position _position;
    public Widget(Position pos) {
        _position = pos;
    }

    public abstract void DrawWith(IWidgetRenderer renderer);

}


