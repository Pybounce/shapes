public class Canvas {

    private List<Shape> _shapes;

    public Canvas() {
        _shapes = new List<Shape>();
    }

    public void AddShape(Shape shape) {
        _shapes.Add(shape);
    }

    public void Draw() {
        foreach (var shape in _shapes) {
            shape.Draw();
        }
    }
}