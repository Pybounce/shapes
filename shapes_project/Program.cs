public class MyProgram {

    public static void Main()
    {
        Showcase_3();
    }

    private static void Showcase_0() {
        var widgetRenderer = new BasicWidgetRenderer();
        var canvas = new Canvas(widgetRenderer);

        var square = new Square(10, new Position(2, 2));
        var circle = new Circle(1, new Position(3, 4));

        canvas.AddWidgets(square, circle);
        canvas.Draw();
    }

    private static void Showcase_1() {
        var widgetRenderer = new BasicWidgetRenderer();
        var canvas = new Canvas(widgetRenderer, 
            new Square(10, new Position(2, 2)),
            new Circle(1, new Position(3, 4))
        );

        canvas.Draw();
    }



    private static void Showcase_2() {
        var widgetRenderer = new BasicWidgetRenderer();
        var canvas = new Canvas(widgetRenderer);

        var square = new Square(10, new Position(2, 2));
        var circle = new Circle(1, new Position(3, 4));
        var circleSquare = new CompoundWidget(new Position(0, 0), circle, square);

        canvas.AddWidgets(circleSquare, circleSquare);
        canvas.Draw();
    }

    private static void Showcase_3() {
        var widgetRenderer = new ScreamingWidgetRenderer();
        var canvas = new Canvas(widgetRenderer, 
            new Square(10, new Position(2, 2)),
            new Circle(1, new Position(3, 4))
        );

        canvas.Draw();
    }
}
