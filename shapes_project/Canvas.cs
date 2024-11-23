public class Canvas {

    private IEnumerable<Shape> _shapes;

    public Canvas() {
        _shapes = new List<Shape>();
    }

    public Canvas(params Shape[] shapes) {
        _shapes = shapes;
    }

    public void AddShapes(params Shape[] shapes) {
        _shapes = _shapes.Concat(shapes);
    }

    public void Draw() {
        foreach (var shape in _shapes) {
            shape.Draw();
        }
    }
}