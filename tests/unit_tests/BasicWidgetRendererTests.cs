using Bogus;

namespace unit_tests;

public class BasicWidgetRendererTests
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

        var diameter = _faker.Random.UInt(1);
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

        var width = _faker.Random.UInt(1);
        var height = _faker.Random.UInt(1);
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

        var size = _faker.Random.UInt(1);
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

        var diameterH = _faker.Random.UInt(1);
        var diameterV = _faker.Random.UInt(1);
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

        var width = _faker.Random.UInt(1);
        var height = _faker.Random.UInt(1);
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
    public void DrawTextbox___NullString___ConsidersTextEmpty()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var width = _faker.Random.UInt(1);
        var height = _faker.Random.UInt(1);
        String text = null;
        var widget = new Textbox(width, height, text, pos);
        
        var expectedOutput = $"Textbox ({x},{y}) width={width} height={height} Text=\"\"";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    [Repeat(20)]
    public void DrawText___RandomTextContent___CorrectConsoleOutput()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        var textContent = _faker.Random.String(0, 100);
        var widget = new Text(textContent, pos);
        
        var expectedOutput = $"Text ({x},{y}) Content=\"{textContent}\"";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    public void DrawText___NullTextContent___ConsidersTextEmpty()
    {
        //arrange
        var x = _faker.Random.Int();
        var y = _faker.Random.Int();
        var pos = new Position(x, y);

        String textContent = null;
        var widget = new Text(textContent, pos);
        
        var expectedOutput = $"Text ({x},{y}) Content=\"\"";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }

    [Test]
    public void DrawCompound___CircleSquare___OutputsCircleThenSquare()
    {
        //arrange
        var pos = new Position(0, 0);

        var diameter = _faker.Random.UInt(1);
        var circleWidget = new Circle(diameter, pos);

        var size = _faker.Random.UInt(1);
        var squareWidget = new Square(size, pos);

        var widget = new CompoundWidget(pos, circleWidget, squareWidget);
        var expectedOutput = $"Circle ({pos.x},{pos.y}) size={diameter}\n" + $"Square ({pos.x},{pos.y}) size={size}";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }
    
    [Test]
    public void DrawCompound___RandomPositions___ChildPositionsAlteredByCompoundParent()
    {
        //arrange
        var compoundPos = new Position(_faker.Random.Int(), _faker.Random.Int());
        var circlePos = new Position(_faker.Random.Int(), _faker.Random.Int());
        var squarePos = new Position(_faker.Random.Int(), _faker.Random.Int());

        var diameter = _faker.Random.UInt(1);
        var circleWidget = new Circle(diameter, circlePos);

        var size = _faker.Random.UInt(1);
        var squareWidget = new Square(size, squarePos);

        var widget = new CompoundWidget(compoundPos, circleWidget, squareWidget);
        var expectedOutput = $"Circle ({circlePos.x + compoundPos.x},{circlePos.y + compoundPos.y}) size={diameter}\n" + $"Square ({squarePos.x + compoundPos.x},{squarePos.y + compoundPos.y}) size={size}";
        
        //act
        _widgetRenderer.Draw(widget);

        //assert
        _consoleOut.Flush();
        Assert.That(_consoleOut.ToString().Trim() == expectedOutput);
    }
}
