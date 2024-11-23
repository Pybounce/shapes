using Bogus;

namespace unit_tests;

public class SquareTests
{
    private Faker _faker;
    private IWidgetRenderer _widgetRenderer;

    private StringWriter _consoleOut;
    private TextWriter _originalConsoleOut;

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
        _widgetRenderer = new BasicWidgetRenderer();
        _consoleOut = new StringWriter();
        _originalConsoleOut = Console.Out;
        Console.SetOut(_consoleOut);
    }
    [TearDown]
    public void TearDown()
    {
        Console.SetOut(_originalConsoleOut);
        _consoleOut.Dispose();
    }

    [Test]
    [Repeat(20)]
    public void DrawCircle___RandomCircle___CorrectConsoleOutput()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var diameter = _faker.Random.UInt();
        var widget = new Circle(diameter, pos);
        
        var expectedOutput = $"Circle ({x},{y}) size={diameter}";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }
    [Test]
    [Repeat(20)]
    public void DrawRect___RandomRect___CorrectConsoleOutput()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var width = _faker.Random.UInt();
        var height = _faker.Random.UInt();
        var widget = new Rect(width, height, pos);
        
        var expectedOutput = $"Rectangle ({x},{y}) width={width} height={height}";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    [Repeat(20)]
    public void DrawSquare___RandomSquare___CorrectConsoleOutput()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var size = _faker.Random.UInt();
        var widget = new Square(size, pos);

        var expectedOutput = $"Square ({x},{y}) size={size}";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    [Repeat(20)]
    public void DrawEllipse___RandomEllipse___CorrectConsoleOutput()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var diameterH = _faker.Random.UInt();
        var diameterV = _faker.Random.UInt();
        var widget = new Ellipse(diameterH, diameterV, pos);
        
        var expectedOutput = $"Ellipse ({x},{y}) diameterH = {diameterH} diameterV = {diameterV}";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    [Repeat(20)]
    public void DrawTextbox___RandomTextbox___CorrectConsoleOutput()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var width = _faker.Random.UInt();
        var height = _faker.Random.UInt();
        var text = _faker.Random.String(0, 100);
        var widget = new Textbox(width, height, text, pos);
        
        var expectedOutput = $"Textbox ({x},{y}) width={width} height={height} Text=\"{text}\"";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    public void DrawTextbox___NullString___ConsidersItEmpty()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var width = _faker.Random.UInt();
        var height = _faker.Random.UInt();
        String text = null;
        var widget = new Textbox(width, height, text, pos);
        
        var expectedOutput = $"Textbox ({x},{y}) width={width} height={height} Text=\"\"";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }
}
