
using Bogus;
namespace unit_tests;

public class WidgetUtilsTests {

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
        var dimention = _faker.Random.UInt(1);
        var dimentionThySecond = _faker.Random.UInt(1);
        
        //act/assert
        Assert.DoesNotThrow(() => { WidgetUtils.CheckDimentions(dimention); });
        Assert.DoesNotThrow(() => { WidgetUtils.CheckDimentions(dimention, dimentionThySecond); });
    }

    [Test]
    public void Constructor___DimentionsZero___WidgetDimentionsError() {
        Assert.Throws<WidgetDimentionOutOfRangeException>(() => { WidgetUtils.CheckDimentions(0); });
        Assert.Throws<WidgetDimentionOutOfRangeException>(() => { WidgetUtils.CheckDimentions(0, 0); });
    }

}