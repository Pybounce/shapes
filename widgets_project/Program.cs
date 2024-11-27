public class MyProgram {

    public static async Task Main()
    {
        await RenderingButFancy();
    }

    private static void Showcase_Main() {
        var renderer = new BasicWidgetRenderer();
        var canvas = new Canvas(renderer, new IWidget[5] {
            new Rect(30, 40, new Position(10, 10)),
            new Square(35, new Position(15, 30)),
            new Ellipse(300, 200, new Position(100, 150)),
            new Circle(300, new Position(1, 1)),
            new Textbox(200, 100, "sample text", new Position(5, 5))
        });

        canvas.Draw();
    }

    private static async Task RenderingButFancy() {
        var pong = new Pong(3);
        await pong.Play();

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
