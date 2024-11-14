using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class ARandomGenerator
{
    [Test]
    public void CanGenerateARandomIntegerWithinARange()
    {
        RandomGenerator sut = new();
        int value = sut.Get(1, 30);
        Assert.That(value, Is.InRange(1, 30));
    }
}