using FantasyRPG;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ADamage
{
    [Test]
    public void HasABaseValue()
    {
        Damage sut = new()
        {
            Base = 10
        };
        Assert.That(sut.Base, Is.EqualTo(10));
    }

    [Test]
    public void CanHaveAdditionalValue()
    {
        Damage sut = new()
        {
            Base = 10,
            Additional = 20
        };
        Assert.That(sut.Additional, Is.EqualTo(20));
    }

    [Test]
    public void HasTotalValue()
    {
        Damage sut = new()
        {
            Base = 10,
            Additional = 20
        };
        Assert.That(sut.Total, Is.EqualTo(30));
    }
}
