using System;
using NUnit.Framework;


namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);
        }

        [Test]
        public void StoringArrayCapacityMustBeExactly16Integers()
        {
            Assert.Throws<InvalidOperationException>((() => database.Add(5) ));
        }

        [Test]
        public void AddSuccesfullyElement()
        {
            database = new Database(1, 2, 3, 4);
            int oldCount = database.Count;
            database.Add(5);
            int newCount = database.Count;

            Assert.AreNotEqual(oldCount,newCount);
        }

        [Test]
        public void RemoveSuccesfullyElement()
        {
            database = new Database(1);
            database.Remove();
            int count = database.Count;
            Assert.AreEqual(database.Count,0);
        }

        [Test]
        public void RemoveElementFromEmptyDatabase()
        {
            database = new Database(1);
            database.Remove();
            Assert.Throws<InvalidOperationException>((() => database.Remove()));
        }

        [Test]
        public void FetchMethodShouldReturnTheElementsAsArray()
        {
            database = new Database(1, 2, 3, 4, 5);
            int[] copy = database.Fetch();

            Assert.AreEqual(database.Count,copy.Length);
        }
    }
}