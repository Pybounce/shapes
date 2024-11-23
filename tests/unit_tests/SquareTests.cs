using Bogus;

namespace unit_tests;

public class SquareTests
{
    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
    }

    //[Test]
    //[Repeat(20)]
    //public void Draw___RandomInput___StringContainsSameValues()
    //{
    //    var x = _faker.Random.Int();
    //    var y = _faker.Random.Int();
    //    var expectedOutput = $"({x}, {y})";
//
    //    var position = new Position(x, y);
    //
    //    Assert.That(expectedOutput == position.AsDrawnString());
    //}
//
    //[Test]
    //public void AsDrawnString___NoInput___StringContainsSameValues()
    //{
    //    var expectedOutput = "(0, 0)";
//
    //    var position = new Position();
    //    
    //    Assert.That(expectedOutput == position.AsDrawnString());
    //}
}