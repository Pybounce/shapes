
using Bogus;
namespace unit_tests;

public class SquareTests {

    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
    }

    [Test]
    [Repeat(50)]
    public void Constructor___DimentionsGreaterThanZero___NoErrors() {
        //arrange
        var size = _faker.Random.UInt(1);

        //act/assert
        Assert.DoesNotThrow(() => { var widget = new Square(size); });
    }

    [Test]
    public void Constructor___DimentionsZero___WidgetDimentionsError() {
        Assert.Throws<WidgetDimentionOutOfRangeException>(() => { var widget = new Square(0); });
    }

}