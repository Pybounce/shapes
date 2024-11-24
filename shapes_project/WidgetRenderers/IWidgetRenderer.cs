public interface IWidgetRenderer {
    public void Draw(Square square);
    public void Draw(Circle circle);
    public void Draw(Rect rect);
    public void Draw(Ellipse ellipse);
    public void Draw(Textbox textbox);
    public void Draw(CompoundWidget compoundWidget);
    public void Draw(Text text);
}
