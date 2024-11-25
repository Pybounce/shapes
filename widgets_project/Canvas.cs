public class Canvas {

    private IWidgetRenderer _widgetRenderer;
    private IEnumerable<IWidget> _widgets;

    public Canvas(IWidgetRenderer widgetRenderer) {
        _widgets = new List<IWidget>();
        _widgetRenderer = widgetRenderer;
    }

    public Canvas(IWidgetRenderer widgetRenderer, params IWidget[] widgets) {
        _widgets = widgets == null ? new List<IWidget>() : widgets.ToList();
        _widgetRenderer = widgetRenderer;
    }

    public void AddWidgets(params IWidget[] widgets) {
        _widgets = _widgets.Concat(widgets).ToList();
    }

    public void Draw() {
        _widgetRenderer.Draw(_widgets);
    }
}