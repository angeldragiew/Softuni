using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry raceEntry;
        UnitDriver driver;
        UnitCar car; 
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            driver = new UnitDriver("Angel", car);
            car = new UnitCar("BMW", 200, 3000);
        }

        [Test]
        public void CountReturnZero_When_ThereAreNoElements()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddThrow_When_DriverIsNull()
        {
            Assert.That(() =>
            {
                raceEntry.AddDriver(null);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Driver cannot be null."));
        }

        [Test]
        public void AddThrow_When_DriverExists()
        {
            raceEntry.AddDriver(driver);
            Assert.That(() =>
            {
                raceEntry.AddDriver(driver);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Driver {driver.Name} is already added."));
        }

        [Test]
        public void Add_AddCorrectly()
        {
            string result = raceEntry.AddDriver(driver);

            Assert.AreEqual($"Driver {driver.Name} added in race.", result);
        }

        [Test]
        public void CalculateAverageHorsePowerThrows_When_ThereArenotEnoughParticipants()
        {
            raceEntry.AddDriver(driver);

            Assert.That(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            }, Throws.InvalidOperationException.With.Message.EqualTo($"The race cannot start with less than 2 participants."));
        }

        [Test]
        public void HorsePowerTest()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("Ferrari", 100, 2000)));

            double result = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(150, result);
        }

    }
}