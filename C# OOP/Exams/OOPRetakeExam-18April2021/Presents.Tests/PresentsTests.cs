using System;

namespace Presents.Tests
{
    using NUnit.Framework;
    using Presents;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
        }

        [Test]
        public void Create_ThrowExceptionForNullPresent()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>((() => bag.Create(present)));
        }

        [Test]
        public void Create_ThrowExceptionForExistedPresent()
        {
            Present present = new Present("Samolet", 10);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>((() => bag.Create(present)));
        }

        [Test]
        public void Create_SuccesfullyAddPresent()
        {
            Present present = new Present("Samolet", 10);
            bag.Create(present);

            Assert.AreEqual(1,bag.GetPresents().Count);
        }

        [Test]
        public void Remove_RemoveSuccessfully()
        {
            Present present = new Present("Samolet", 10);
            bag.Create(present);
            int beforeCount = bag.GetPresents().Count;
            bag.Remove(present);
            int afterCount = bag.GetPresents().Count;

            Assert.AreNotEqual(beforeCount, afterCount);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            Present present = new Present("Samolet", 10);
            bag.Create(present);

            Present pre = new Present("BMW", 15);
            bag.Create(pre);

            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresent()
        {
            Present present = new Present("Samolet", 10);
            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent("Samolet"));
        }

        [Test]
        public void GetPresents()
        {
            Present present = new Present("Samolet", 10);
            bag.Create(present);
            Present pre = new Present("BMW", 15);
            bag.Create(pre);

            Assert.AreEqual(2,bag.GetPresents().Count);
        }
    }
}
