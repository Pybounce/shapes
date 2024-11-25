
using Bogus;
namespace unit_tests;

public class RectTests {

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
        var width = _faker.Random.UInt(1);
        var height = _faker.Random.UInt(1);

        //act/assert
        Assert.DoesNotThrow(() => { var widget = new Rect(width, height); });
    }

    [Test]
    public void Constructor___DimentionsZero___WidgetDimentionsError() {
        Assert.Throws<WidgetDimentionOutOfRangeException>(() => { var widget = new Rect(0, 0); });
    }

}