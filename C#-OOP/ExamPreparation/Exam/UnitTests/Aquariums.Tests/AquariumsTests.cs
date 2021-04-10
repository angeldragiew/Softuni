namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AquariumsTests
    {
        Aquarium aquarium;
        Fish fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("ValidName", 20);
            fish = new Fish("Bu");
        }

        [Test]
        public void FishConstructorWork()
        {
            Assert.AreEqual("Bu", fish.Name);
            Assert.That(fish.Available, Is.True);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CtorThrows_When_NameIsNullOrEmpty(string name)
        {
            Assert.That(() =>
            {
                 aquarium = new Aquarium(name, 2);
            }, Throws.ArgumentNullException);
        }


        [Test]
        public void CtorThrows_When_CapacityIsInvalid()
        {
            Assert.That(() =>
            {
                aquarium = new Aquarium("ValidName", -20);
            }, Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void CtorSetCorrectly_When_ArgumentsAreValid()
        {
            string name = "aqua";
            int capacity = 10;

            aquarium = new Aquarium(name, capacity);
            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
            Assert.IsNotNull(aquarium);
        }

        [Test]
        public void Name_ReturnsName()
        {
            string name = "ValidName";
            aquarium = new Aquarium(name, 20);

            Assert.AreEqual(name, aquarium.Name);
        }
        [Test]
        public void Capacity_ReturnsCapacity()
        {
            int capacity = 20;
            aquarium = new Aquarium("ValidName", capacity);

            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        public void Count_ReturnsZeroWhenEmpty()
        {
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void Count_Returns_Count()
        {
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AddThrows_When_AquariumIsFull()
        {
            aquarium = new Aquarium("New", 0);

            Assert.That(() =>
            {
                aquarium.Add(new Fish("fish"));
            },Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void Add_AddsCorrectly()
        {
            aquarium.Add(fish);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFishThrows_When_FishIsDoesntExist()
        {
            aquarium.Add(fish);
            string name = "safvzxv";
            Assert.That(() =>
            {
                aquarium.RemoveFish("safvzxv");
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }

        [Test]
        public void RemoveFish_Removes()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("Bu");

            Assert.AreEqual(0, aquarium.Count);
        }


        [Test]
        public void SellFishThrows_When_FishIsNull()
        {
            aquarium.Add(fish);
            string name = "safvzxv";
            Assert.That(() =>
            {
                aquarium.SellFish("safvzxv");
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }


        [Test]
        public void SellFish_ReturnsRequestedFish()
        {
            aquarium.Add(fish);

            Assert.That(aquarium.SellFish(fish.Name), Is.EqualTo(fish));
        }

        [Test]
        public void SellFish_MakesFishUnAvaible()
        {
            aquarium.Add(fish);

            Assert.That(aquarium.SellFish(fish.Name).Available, Is.False);
        }

        [Test]
        public void ReportReturnReport()
        {
            Fish newFish = new Fish("Angel");
            aquarium.Add(fish);
            aquarium.Add(newFish);

            List<string> fishes = new List<string>();
            fishes.Add(fish.Name);
            fishes.Add(newFish.Name);

            string report = aquarium.Report();

            string expected = $"Fish available at {aquarium.Name}: {string.Join(", ",fishes)}";

            Assert.AreEqual(report, expected);
        }
    }
}
