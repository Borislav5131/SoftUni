using System;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person person;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
            person = new Person(5, "Pesho");
        }

        [Test]
        public void Add_ThereAreAlreadyUsersWithThisUsername()
        {
            Person person1 = new Person(10, "Pesho");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>((() => database.Add(person)));
        }

        [Test]
        public void Add_ThereAreAlreadyUsersWithThisId()
        {
            Person person1 = new Person(5, "Gosho");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>((() => database.Add(person)));
        }

        [Test]
        public void Remove_RemoveSuccessfullyPerson()
        {
            Person person1 = new Person(5, "Gosho");
            database.Add(person1);
            int beforeCount = database.Count;
            database.Remove();
            int afterCount = database.Count;

            Assert.AreNotEqual(beforeCount, afterCount);
        }

        [Test]
        public void Remove_ThrowException()
        {
            Assert.Throws<InvalidOperationException>((() => database.Remove()));
        }

        [Test]
        public void FindByUsername_TheNameIsNotExist()
        {
            database.Add(person);
            Assert.Throws<InvalidOperationException>((() => database.FindByUsername("Gosho")));
        }

        [Test]
        public void FindByUsername_TheNameIsNull()
        {
            Assert.Throws<ArgumentNullException>((() => database.FindByUsername(null)));
        }

        [Test]
        public void FindByUsername_FindTheCorrectName()
        {
            database.Add(person);
            Assert.AreEqual(database.FindByUsername("Pesho"),person);
        }

        [Test]
        public void FindById_IfNoUserIsPresentByThisId()
        {
            Assert.Throws<InvalidOperationException>((() => database.FindById(5)));
        }

        [Test]
        public void FindById_IfNegativeIdsAreFound()
        {
            person = new Person(-5, "Pesho");
            Assert.Throws<ArgumentOutOfRangeException>((() => database.FindById(-5)));
        }
    }
}