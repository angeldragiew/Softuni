using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 10;
    private int experience = 2;
    private Dummy dummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
        deadDummy = new Dummy(-5, experience);
    }

    [Test]
    public void When_HealthIsProvided_ShouldBeSetCorrectly()
    {
        Assert.That(health, Is.EqualTo(dummy.Health));
    }

    [Test]
    public void When_ExperienceIsProvided_ShouldBeSetCorrectly()
    {
        dummy = new Dummy(0, experience);
        Assert.That(experience, Is.EqualTo(dummy.GiveExperience()), "Experince is not set correctly!!!");
    }

    [Test]
    public void When_Attacked_ShouldDecreaseHealth()
    {
        int attackPoints = 5;
        dummy.TakeAttack(attackPoints);

        Assert.AreEqual(health - attackPoints, dummy.Health);
    }

    [Test]
    public void When_AttackDeadDummy_ShouldThrow()
    {
        Assert.That(() =>
        {
            deadDummy.TakeAttack(5);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_HealthIsZeroOrLess_ShouldBeDead()
    {
        Assert.AreEqual(true, deadDummy.IsDead());
    }

    [Test]
    public void When_HealthIsPositive_ShouldBeAlive()
    {
        Assert.AreEqual(false, dummy.IsDead());
    }

    [Test]
    public void When_Dead_ShouldGiveExperience()
    {
        Assert.AreEqual(experience, deadDummy.GiveExperience());
    }

    [Test]
    public void When_AliveGiveExperience_ShouldThrow()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}