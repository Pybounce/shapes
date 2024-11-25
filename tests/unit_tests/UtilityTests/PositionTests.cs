
using Bogus;
namespace unit_tests;

public class PositionTests {
    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
    }

    [Test]
    [Repeat(200)]
    public void AdditionOperator___AddsCorrectly() {
        //arrange
        var x1 = _faker.Random.Int();
        var y1 = _faker.Random.Int();
        var x2 = _faker.Random.Int();
        var y2 = _faker.Random.Int();

        var xResult = x1 + x2;
        var yResult = y1 + y2;

        var pos1 = new Position(x1, y1);
        var pos2 = new Position(x2, y2);

        //act
        var posResult = pos1 + pos2;

        //assert
        Assert.That(posResult.x == xResult);
        Assert.That(posResult.y == yResult);
    }
    
    [Test]
    [Repeat(200)]
    public void SubtractionOperator___SubtractsCorrectly() {
        //arrange
        var x1 = _faker.Random.Int();
        var y1 = _faker.Random.Int();
        var x2 = _faker.Random.Int();
        var y2 = _faker.Random.Int();

        var xResult = x1 - x2;
        var yResult = y1 - y2;

        var pos1 = new Position(x1, y1);
        var pos2 = new Position(x2, y2);

        //act
        var posResult = pos1 - pos2;

        //assert
        Assert.That(posResult.x == xResult);
        Assert.That(posResult.y == yResult);
    }
}