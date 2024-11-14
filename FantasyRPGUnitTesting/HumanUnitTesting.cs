using FantasyRPG;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class AHuman
{
    // [UNIT] A human reports its race as ‘Human’.
    [Test]
    public void ReportsItsRaceAsHuman()
    {
        Human sut = new();
        Assert.That(sut.Race, Is.EqualTo("Human"));
    }

}
