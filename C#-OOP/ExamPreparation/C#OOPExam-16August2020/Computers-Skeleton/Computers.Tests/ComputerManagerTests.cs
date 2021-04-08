using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        ComputerManager computerManager;
        Computer computer;
        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("acer", "Aspire", 200);
        }

        [Test]
        public void CountIncreaseWhenAdd()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Count);
        }

        [Test]
        public void AddComputerThrows_When_ObjectIsNull()
        {
            Assert.That(() =>
            {
                computerManager.AddComputer(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void AddComputerThrows_When_exists()
        {
            computerManager.AddComputer(computer);
            Assert.That(() =>
            {
                computerManager.AddComputer(computer);
            }, Throws.ArgumentException);
        }


        [Test]
        public void Add_add()
        {
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Computers.Contains(computer), Is.True);
        }

        [Test]
        [TestCase("a",null)]
        [TestCase(null,"A")]
        public void GetCompTrhow_WhenNull(string a, string b)
        {
            Assert.That(() =>
            {
                computerManager.GetComputer(a, b);
            }, Throws.ArgumentNullException);
        }
        [Test]
        public void GetCompTrhow_When_compDoesntExist()
        {
            computerManager.AddComputer(computer);
            Assert.That(() =>
            {
                computerManager.GetComputer("A","b");
            }, Throws.ArgumentException.With.Message.EqualTo("There is no computer with this manufacturer and model."));
        }

        [Test]
        public void GetComp_Return()
        {
            computerManager.AddComputer(computer);

            Computer returnedComp = computerManager.GetComputer(computer.Manufacturer, computer.Model);

            Assert.That(computer, Is.EqualTo(returnedComp));
        }

        [Test]
        public void GetComputersByManufacturer_throws()
        {
            Assert.That(() =>
            {
                computerManager.GetComputersByManufacturer(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void GetComputersByManufacturer_Return()
        {
            List<Computer> computers = new List<Computer>();
            computers.Add(computer);
            computerManager.AddComputer(computer);

            Assert.That(computers, Is.EquivalentTo(computerManager.GetComputersByManufacturer(computer.Manufacturer)));

        }

        [Test]
        public void RemoveComputer_removes()
        {
            computerManager.AddComputer(computer);

            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.That(computerManager.Computers.Any(c => c.Manufacturer == computer.Manufacturer), Is.False);
        }
    }
}