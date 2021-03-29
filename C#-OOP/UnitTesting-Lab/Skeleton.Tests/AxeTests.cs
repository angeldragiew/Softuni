using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attackPoints = 2;
    private int durabilityPoints = 10;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attackPoints, durabilityPoints);
        dummy = new Dummy(10, 5);
    }

    [Test]
    public void WhenProvided_AttackPointsAndDurabilityPoints_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(attackPoints, axe.AttackPoints);
        Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
    }

    [Test]
    public void When_AxeAttacks_ShouldLoseDurabilityPoints()
    {
        axe.Attack(dummy);

        Assert.AreEqual(durabilityPoints - 1, axe.DurabilityPoints);
    }

    [Test]
    public void When_AxeAttacksWithZeroOrLessDurability_ShouldThrow()
    {
        axe = new Axe(2, 0);

        Assert.That(() =>
        {
            axe.Attack(dummy);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken.")
        );

    }

    [Test]
    public void When_AxeAttacksNullDummy_ShouldThrowNullRef()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            axe.Attack(null);
        });
    }
}