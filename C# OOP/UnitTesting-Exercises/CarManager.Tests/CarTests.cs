using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("BMW", "E90", 6.0, 50);
        }

        [Test]
        public void Ctor()
        {
           Assert.AreEqual(car.Make, "BMW"); 
           Assert.AreEqual(car.Model, "E90"); 
           Assert.AreEqual(car.FuelConsumption, 6.0); 
           Assert.AreEqual(car.FuelCapacity, 50);
           Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        public void ExceptionsForValidation()
        {
            Assert.Throws<ArgumentException>((() => car = new Car(null, "E90", 6.0, 50)));
            Assert.Throws<ArgumentException>((() => car = new Car("BMW", null, 6.0, 50)));
            Assert.Throws<ArgumentException>((() => car = new Car("BMW", "E90", -5, 50)));
            Assert.Throws<ArgumentException>((() => car = new Car("BMW", "E90", 6.0, -60)));
        }

        [Test]
        public void Refuel_NegativeFuel()
        {
            Assert.Throws<ArgumentException>((() => car.Refuel(-20)));
        }

        [Test]
        public void Refuel_Successfully()
        {
            car.Refuel(20);
            Assert.AreEqual(car.FuelAmount,20);
        }
        [Test]
        public void Refuel_SuccessfullyWithMoreFromCapacity()
        {
            car.Refuel(80);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        [Test]
        public void Drive_FuelDoNotReaches()
        {
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>((() => car.Drive(260)));
        }

        [Test]
        public void Drive_DriveTheDistance()
        {
            car.Refuel(5);
            car.Drive(15);
            Assert.AreEqual(car.FuelAmount,4.1);
        }
    }
}