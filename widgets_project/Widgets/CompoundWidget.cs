
public class CompoundWidget : Widget
{
    protected IEnumerable<Widget> Widgets;

    public CompoundWidget(Position pos, params Widget[] widgets) : base(pos)
    {
        foreach (var widget in widgets) { widget.Position += pos; }
        Widgets = widgets;
    }
    public CompoundWidget(CompoundWidget compoundWidget) : base(compoundWidget.Position)
    {
        Widgets = compoundWidget.Widgets.Select(x => x);
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        foreach (var widget in Widgets) {
            widget.DrawWith(renderer);
        }
    }

}
