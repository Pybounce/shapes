// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var canvas = new Canvas();
var someShape = new Square(10, 10, new Position(1, 2));
var someShape2 = new Square(222, 1243, new Position(122, 2));

canvas.AddShape(someShape);
canvas.AddShape(someShape2);

canvas.Draw();