using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 50);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -20, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -20)]
        public void CtorThrows_When_ProvidedDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CtorSetProvidedDataCorrectly_When_DataIsValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void RefuelThrows_When_ProvidedFuelIsZeroOrLess(double fuel)
        {
            Assert.That(() =>
            {
                car.Refuel(fuel);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void When_ProvidedFuelIsValid_RefuelAmountShouldIncrease()
        {
            double refuelAmount = car.FuelCapacity / 2;
            car.Refuel(refuelAmount);

            Assert.AreEqual(refuelAmount, car.FuelAmount);
        }

        [Test]
        public void When_ProvidedFuelExceedsFuelCapacity_FuelShouldBeSetEqualToCapacity()
        {
            double refuelAmount = car.FuelCapacity * 2;
            car.Refuel(refuelAmount);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveThrows_When_ThereIsNotEnoughFuel()
        {
            Assert.That(() =>
            {
                car.Drive(100);
            },Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void When_FuelIsEqualToNeededFuel_FuelShoudBeSetZero()
        {
            car.Refuel(car.FuelCapacity);
            double distance = car.FuelAmount / car.FuelConsumption * 100;

            car.Drive(distance);

            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void DriveShouldDecreaseFuelAmount_When_ThereIsEnoughFuel()
        {
            car.Refuel(car.FuelCapacity);
            double distance = car.FuelCapacity;

            double fuelAmountBeforeDrive = car.FuelAmount;
            car.Drive(distance);
            double fuelAmountAfterDrive = car.FuelAmount;
            Assert.Less(fuelAmountAfterDrive, fuelAmountBeforeDrive);
        }
    }
}