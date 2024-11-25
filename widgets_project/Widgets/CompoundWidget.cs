
public struct CompoundWidget : IWidget
{
    private IEnumerable<IWidget> _widgets;
    public Position Position { get; set; }
    public CompoundWidget(Position pos, params IWidget[] widgets)
    {
        foreach (var widget in widgets) { widget.Position += pos; }
        _widgets = widgets.ToList();
        Position = pos;
    }
    public void DrawWith(IWidgetRenderer renderer)
    {
        foreach (var widget in _widgets) {
            widget.DrawWith(renderer);
        }
    }

}
