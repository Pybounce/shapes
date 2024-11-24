
public abstract class Widget {
    public Position Position { get; protected set; }
    
    public Widget(Position pos) {
        Position = pos;
    }

    public abstract void DrawWith(IWidgetRenderer renderer);

}


public class CompoundWidget : Widget
{
    protected IEnumerable<Widget> Widgets;

    protected CompoundWidget(Position pos, params Widget[] widgets) : base(pos)
    {
        Widgets = widgets;
    }

    public override void DrawWith(IWidgetRenderer renderer)
    {
        foreach (var widget in Widgets) {
            widget.DrawWith(renderer);
        }
    }

}
