using FantasyRPG;
using NSubstitute;
using static System.Net.Mime.MediaTypeNames;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ACreature
{
    [Test]
    public void ReportsItsRaceAsUnknown()
    {
        Creature sut = new();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Unknown"));
    }

    [Test]
    public void CanInflictBaseDamage()
    {
        IRandom random = Substitute.For<IRandom>();
        random.Get(1, 30).Returns(25);
        Creature sut = new(random)
        {
            Strength = 30
        };
        int actual = sut.InflictDamage();
        Assert.That(actual, Is.EqualTo(25));
    }

    [Test]
    public void Has99PercentChanceOfTakingDamage()
    {
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1, 100).Returns(89);
        Creature sut = new(randomMock)
        {
            Strength = 1,
            HitPoints = 100
        };
        int damage = 10;
        _ = sut.TakeDamage(damage);
        Assert.That(sut.HitPoints, Is.EqualTo(90));
    }

    [Test]
    public void Has1PercentChanceOfNotTakingDamage()
    {
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1, 100).Returns(1);
        Creature sut = new(randomMock)
        {
            Strength = 1,
            HitPoints = 100
        };
        int damage = 10;
        _ = sut.TakeDamage(damage);
        Assert.That(sut.HitPoints, Is.EqualTo(100));
    }

    [Test]
    public void CanAttackAnotherCreature()
    {
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1, Arg.Any<int>()).Returns(1);
        Creature sut = new(randomMock)
        {
            Strength = 1,
            HitPoints = 100
        };
        Creature mockCreature = Substitute.For<Creature>();
        _ = sut.Attack(mockCreature);
        mockCreature.Received().TakeDamage(Arg.Any<int>());
    }


}