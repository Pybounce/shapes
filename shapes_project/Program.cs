// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var widgetRenderer = new BasicWidgetRenderer();
var canvas = new Canvas(widgetRenderer);

var someShape = new Rect(10, 10, new Position(1, 2));
var someShape2 = new Rect(222, 1243, new Position(122, 2));

canvas.AddWidgets(someShape);
canvas.AddWidgets(someShape2);


