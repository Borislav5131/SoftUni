using System;
using System.Linq;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            car = new UnitCar("BMW", 177, 2.0);
            driver = new UnitDriver("Gosho", car);
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(race.Counter,0);
        }

        [Test]
        public void AddDriver_ThrowExceptions()
        {
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>((() => race.AddDriver(driver)));
            driver = null;
            Assert.Throws<InvalidOperationException>((() => race.AddDriver(driver)));
        }

        [Test]
        public void AddDriver_Successfully()
        {
            Assert.AreEqual($"Driver {driver.Name} added in race.", race.AddDriver(driver));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowException()
        {
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>((() => race.CalculateAverageHorsePower()));
        }

        [Test]
        public void CalculateAverageHorsePower_Successfully()
        {
            race.AddDriver(driver);
            race.AddDriver(new UnitDriver("Pesho", new UnitCar("Golf", 105, 1.90)));
            race.AddDriver(new UnitDriver("Todor", new UnitCar("BMW", 245, 3.00)));

            int[] hp = new[] {105, 177, 245};
            double avg = hp.Average();
            Assert.AreEqual(race.CalculateAverageHorsePower(), avg);
        }
    }
}