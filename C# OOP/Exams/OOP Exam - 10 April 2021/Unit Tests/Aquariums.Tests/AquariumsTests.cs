using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Neptun", 2);
            fish = new Fish("Pesho");
        }

        [Test]
        public void Ctor_ValidInformation()
        {
            Assert.AreEqual(aquarium.Name, "Neptun");
            Assert.AreEqual(aquarium.Capacity, 2);
        }

        [Test]
        public void Ctor_InvalidAquariumName()
        {
            Assert.Throws<ArgumentNullException>((() => aquarium = new Aquarium(null, 3)));
            string name = String.Empty;
            Assert.Throws<ArgumentNullException>((() => aquarium = new Aquarium(name, 10)));
        }

        [Test]
        public void Ctor_InvalidAquariumCapacity()
        {
            Assert.Throws<ArgumentException>((() => aquarium = new Aquarium("Neptun", -5)));
        }

        [Test]
        public void Count()
        {
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void Add_NoCapacityInTheAquarium()
        {
            aquarium.Add(fish);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>((() => aquarium.Add(fish)));
        }

        [Test]
        public void Add_AddFish()
        {
            aquarium.Add(fish);

            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void RemoveFish_TheFishDoNotExist()
        {
            Assert.Throws<InvalidOperationException>((() => aquarium.RemoveFish("Pesho")));
        }

        [Test]
        public void RemoveFish_RemoveSuccessfully()
        {
            aquarium.Add(fish);
            int beforeCount = aquarium.Count;
            aquarium.RemoveFish("Pesho");
            int afterCount = aquarium.Count;

            Assert.AreNotEqual(beforeCount,afterCount);
        }

        [Test]
        public void SellFish_TheFishDoNotExist()
        {
            Assert.Throws<InvalidOperationException>((() => aquarium.SellFish("Pesho")));
        }

        [Test]
        public void SellFish_SellSuccessfully()
        {
            aquarium.Add(fish);
            Fish sellFish = aquarium.SellFish("Pesho");

            Assert.AreEqual(sellFish, fish);
        }

        [Test]
        public void Report_ReturnString()
        {
            aquarium.Add(fish);
            string result = aquarium.Report();

            Assert.AreEqual(result, "Fish available at Neptun: Pesho");
        }
    }
}
