using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void AddThrows_When_CapacityIsExceeded()
        {
            Assert.That(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(new ExtendedDatabase.Person(i, $"{i}"));
                }
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddThrows_When_ThereIsAlreadyUserWithThatUsername()
        {
            string username = "Angel";
            database.Add(new Person(1, username));

            Assert.That(() =>
            {
                database.Add(new Person(2, username));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddThrows_When_ThereIsAlreadyUserWithThatId()
        {
            int id = 1;
            database.Add(new Person(id, "Ivan"));

            Assert.That(() =>
            {
                database.Add(new Person(id, "Dimitri"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void When_AddIsValid_CountShouldBeIncreased()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }
            Assert.AreEqual(n, database.Count);
        }

        [Test]
        public void RemoveThrows_When_DatabaseIsEmpty()
        {
            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void When_RemoveIsValid_RemovesElementFromDatabase()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }

            database.Remove();

            int expectedCount = n - 1;
            Assert.AreEqual(expectedCount, database.Count);
            Assert.Throws<InvalidOperationException>(() => database.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameThrows_When_GivenNameIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameThrows_When_UsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Angel"));
        }

        [Test]
        public void FindByUsername_ReturnsUser_WhenUserExist()
        {
            string username = "Angel";
            Person person = new Person(1, username);
            database.Add(person);

            Assert.That(person, Is.EqualTo(database.FindByUsername(username)));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindByIdThrows_When_IdIsNegative(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void FindByIdThrows_When_ThereIsNoUserWithThatId()
        {
            Assert.That(() =>
            {
                database.FindById(10);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindById_ReturnUser_WhenUserWithThatIdExist()
        {
            int id = 11;
            Person person = new Person(id, "Angel");
            database.Add(person);

            Assert.That(person, Is.EqualTo(database.FindById(id)));
        }

        [Test]
        public void CtorThrows_When_CapacityIsExceeded()
        {
            Person[] people = new Person[20];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"username{i}");
            }

            Assert.That(() =>
            {
                database = new ExtendedDatabase.ExtendedDatabase(people);
            }, Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void When_ProvidedDataIsValid_CtorShouldSetItCorrectly()
        {
            Person firstPerson = new Person(1, "Angel");
            Person secondPerson = new Person(2, "Ivan");
            Person[] people = new Person[]
            {
                firstPerson,
                secondPerson
            };

            database = new ExtendedDatabase.ExtendedDatabase(people);

            Person dbFirstPerson = database.FindById(firstPerson.Id);
            Person dbSecondPerson = database.FindById(secondPerson.Id);

            Assert.AreEqual(firstPerson, dbFirstPerson);
            Assert.AreEqual(secondPerson, dbSecondPerson);
        }
    }
}