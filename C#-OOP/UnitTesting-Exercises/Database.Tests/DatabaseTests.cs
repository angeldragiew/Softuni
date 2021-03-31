using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void AddThrows_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.That(() =>
            {
                database.Add(10);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void When_AddToDatabase_ShouldIncreaseCount()
        {
            int previousCount = database.Count;
            database.Add(1);

            Assert.AreEqual(previousCount + 1, database.Count);
        }

        [Test]
        public void AddAddsElementToDatabase()
        {
            int element = 7;
            database.Add(element);
            int[] databaseCopy = database.Fetch();
            Assert.That(databaseCopy, Does.Contain(element));
        }

        [Test]
        public void When_Fetch_ShouldReturnCopyOfDatabase()
        {
            int element = 7;
            database.Add(element);

            int[] copy = database.Fetch();

            Assert.That(copy, Does.Contain(element));
        }

        [Test]
        public void RemoveThrows_When_DatabaseIsEmpty()
        {
            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void When_RemoveFromDatabase_ShouldDecreaseCount()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            Assert.AreEqual(n - 1, database.Count);
        }

        [Test]
        public void RemoveRemovesLastElementFromDatabase()
        {
            int lastElement = 3;
            database.Add(1);
            database.Add(2);
            database.Add(lastElement);

            database.Remove();

            int[] databaseCopy = database.Fetch();
            Assert.That(databaseCopy, !Does.Contain(lastElement));
        }

        [Test]
        public void Fetch_ReturnsCopyNotRef()
        {
            database.Add(1);
            database.Add(2);

            int[] firstCopy = database.Fetch();

            database.Add(3);
            database.Add(4);

            int[] secondCopy = database.Fetch();

            Assert.IsFalse(firstCopy == secondCopy);
        }

        [Test]
        public void When_DatabaseIsEmpty_CountShouldReturnZero()
        {
            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void CtorThrows_When_DatabaseCapacityIsExceeded()
        {
            Assert.That(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    database.Add(i);
                }
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_ParamsAreProvidedByCtor_ShoudBeSetCorrectly()
        {
            int[] elements = new int[] { 1, 2, 3 };
            database = new Database.Database(elements);

            Assert.AreEqual(elements.Length, database.Count);

            Assert.That(database.Fetch(), Is.EquivalentTo(elements));
        }
    }
}