



Showcase_3();



void Showcase_0() {
    var widgetRenderer = new BasicWidgetRenderer();
    var canvas = new Canvas(widgetRenderer);

    var square = new Square(10, new Position(2, 2));
    var circle = new Circle(1, new Position(3, 4));

    canvas.AddWidgets(square, circle);
    canvas.Draw();
}

void Showcase_1() {
    var widgetRenderer = new BasicWidgetRenderer();
    var canvas = new Canvas(widgetRenderer, 
        new Square(10, new Position(2, 2)),
        new Circle(1, new Position(3, 4))
    );

    canvas.Draw();
}



void Showcase_2() {
    var widgetRenderer = new BasicWidgetRenderer();
    var canvas = new Canvas(widgetRenderer);

    var square = new Square(10, new Position(2, 2));
    var circle = new Circle(1, new Position(3, 4));
    var circleSquare = new CompoundWidget(new Position(0, 0), circle, square);

    canvas.AddWidgets(circleSquare, circleSquare);
    canvas.Draw();
}

void Showcase_3() {
    var widgetRenderer = new ScreamingWidgetRenderer();
    var canvas = new Canvas(widgetRenderer, 
        new Square(10, new Position(2, 2)),
        new Circle(1, new Position(3, 4))
    );

    canvas.Draw();
}