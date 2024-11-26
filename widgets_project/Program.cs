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
        var circle = new Circle(19, new Position(40, 40));
        var renderer = new AsciiRenderer(80, 80);
        var directionMul = -1;
        for (int i = 0; i < 500; i++) {
            var canvas = new Canvas(renderer, circle);
            canvas.Draw();
            await Task.Delay(16);
            circle.Position += new Position(0, directionMul);
            if (circle.Position.y <= (circle.Diameter / 2)) {
                directionMul = 1;
            }
            else if (circle.Position.y >= 80 - (circle.Diameter / 2)) {
                directionMul = -1;
            }
        }

        // Have a Game object that itself makes a canvas and renderer
        // Then all user input and whatever goes through game
        // That way we can just separate all this stuff into the game object and it won't overlap with my take home assignment...


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
