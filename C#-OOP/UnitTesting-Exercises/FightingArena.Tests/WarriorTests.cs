using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior enemyWarrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Warrior", 10, 100);
            enemyWarrior = new Warrior("EnemyWarrioir", 20, 100);
        }

        [Test]
        [TestCase("", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -20, 100)]
        [TestCase("Warrior", 50, -20)]
        public void CtorThrows_When_ProvidedDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, hp));
        }
        [Test]
        public void Ctor_SetsDataCorrectly_When_DataIsValid()
        {
            string name = "Warrior";
            int damage = 20;
            int hp = 100;

            warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(30)]
        [TestCase(10)]
        public void AttackThrows_When_HPIsLessThanMinAttackHP(int HP) 
        {
            warrior = new Warrior("Warrior", 20, HP);
            Assert.That(() =>
            {
                warrior.Attack(enemyWarrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        [TestCase(30)]
        [TestCase(10)]
        public void AttackThrows_When_EnemyWarriorHasLessAttackHPThanMinimum(int HP)
        {
            enemyWarrior = new Warrior("EnemyWarrior", 20, HP);

            Assert.That(() =>
            {
                warrior.Attack(enemyWarrior);
            },Throws.InvalidOperationException);
        }

        [Test]
        public void AttackThrows_When_EnemyWarriorDamageIsGreaterThanHP()
        {
            enemyWarrior = new Warrior("EnemyWarrior", warrior.HP*2, 50);

            Assert.That(() =>
            {
                warrior.Attack(enemyWarrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void When_AttackIsValid_HPShouldBeDecreased()
        {
            int expectedHP = warrior.HP - enemyWarrior.Damage;
            warrior.Attack(enemyWarrior);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [Test]
        public void When_ValidAttack_EnemyHPShouldBeDecreased()
        {
            int expectedEnemyHP = enemyWarrior.HP - warrior.Damage;

            warrior.Attack(enemyWarrior);

            Assert.AreEqual(expectedEnemyHP, enemyWarrior.HP);
        }

        [Test]
        public void ValidAttack_ShouldSetEnemyHpToZero_When_DamageIsGreaterThanEnemyHP()
        {
            warrior = new Warrior("Warrior", enemyWarrior.HP * 2, 100);
            warrior.Attack(enemyWarrior);

            Assert.AreEqual(0, enemyWarrior.HP);
        }
    }
}