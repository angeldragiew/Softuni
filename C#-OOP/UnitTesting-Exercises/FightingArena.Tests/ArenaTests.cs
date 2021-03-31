using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            attacker = new Warrior("Attacker", 50, 100);
            defender = new Warrior("Defender", 50, 100);
        }

        [Test]
        public void Ctor_ShouldInitializeWarriors()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void When_ArenaIsEmpty_CountShouldBeZero()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollIncreasesCount()
        {
            arena.Enroll(attacker);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollThrows_When_WarriorWithThatNameIsAlreadyEnrolled()
        {
            string name = "Fighter";

            arena.Enroll(new Warrior(name, 50, 100));

            Assert.That(() =>
            {
                arena.Enroll(new Warrior(name, 40, 80));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void When_EnrolIsValid_WarriorShouldBeEnrolled()
        {
            Warrior warrior = new Warrior("Warrior", 50, 100);
            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Does.Contain(warrior));
        }

        [Test]
        [TestCase("Warrior")]
        [TestCase("Attacker")]
        [TestCase("Defender")]
        public void FightThrows_When_NamesAreMissing(string warriorName)
        {
            Warrior warrior = new Warrior(warriorName, 50, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void Fight_BothWarriorsLoseHP()
        {
            int initialHP = 100;
            attacker = new Warrior("Attacker", 50, initialHP);
            defender = new Warrior("Defender", 50, initialHP);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(initialHP - defender.Damage, attacker.HP);
            Assert.AreEqual(initialHP - attacker.Damage, defender.HP);
        }
    }
}
