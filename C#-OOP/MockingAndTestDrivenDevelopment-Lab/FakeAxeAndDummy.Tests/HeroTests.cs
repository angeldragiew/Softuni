using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainXP_When_TargetDies()
    {
        Mock<ITarget> target = new Mock<ITarget>();
        Mock<IWeapon> weapon = new Mock<IWeapon>();

        target.Setup(p => p.IsDead()).Returns(true);
        target.Setup(p => p.GiveExperience()).Returns(20);

        Hero hero = new Hero("Angel", weapon.Object);

        hero.Attack(target.Object);

        Assert.That(hero.Experience, Is.EqualTo(20));
    }
}