public class Canvas {

    private IWidgetRenderer _widgetRenderer;
    private IEnumerable<Widget> _widgets;

    public Canvas(IWidgetRenderer widgetRenderer) {
        _widgets = new List<Widget>();
        _widgetRenderer = widgetRenderer;
    }

    public Canvas(IWidgetRenderer widgetRenderer, params Widget[] widgets) {
        _widgets = widgets;
        _widgetRenderer = widgetRenderer;
    }

    public void AddWidgets(params Widget[] widgets) {
        _widgets = _widgets.Concat(widgets);
    }

    public void Draw() {
        foreach (var widget in _widgets) {
            widget.DrawWith(_widgetRenderer);
        }
    }
}