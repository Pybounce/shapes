public class Canvas {

    private IEnumerable<Widget> _widgets;

    public Canvas() {
        _widgets = new List<Widget>();
    }

    public Canvas(params Widget[] widgets) {
        _widgets = widgets;
    }

    public void AddWidgets(params Widget[] widgets) {
        _widgets = _widgets.Concat(widgets);
    }

    public void Draw() {
        foreach (var widget in _widgets) {
            widget.Draw();
        }
    }
}