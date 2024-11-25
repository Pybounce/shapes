
public abstract class Widget {
    public Position Position { get; set; }
    
    public Widget(Position pos) {
        Position = pos;
    }

    public abstract void DrawWith(IWidgetRenderer renderer);

}

