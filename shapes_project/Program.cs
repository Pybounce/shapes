// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var canvas = new Canvas();
var someShape = new Rect(10, 10, new Position(1, 2));
var someShape2 = new Rect(222, 1243, new Position(122, 2));
var canvas2 = new Canvas(someShape);

canvas.AddShapes(someShape);
canvas.AddShapes(someShape2);

canvas2.Draw();