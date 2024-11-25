
using Bogus;
namespace unit_tests;

public class EllipseTests {

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
        var hd = _faker.Random.UInt(1);
        var vd = _faker.Random.UInt(1);

        //act/assert
        Assert.DoesNotThrow(() => { var widget = new Ellipse(hd, vd); });
    }

    [Test]
    public void Constructor___DimentionsZero___WidgetDimentionsError() {
        Assert.Throws<WidgetDimentionOutOfRangeException>(() => { var widget = new Ellipse(0, 0); });
    }

}