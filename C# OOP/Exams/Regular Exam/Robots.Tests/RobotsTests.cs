using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(2);
            robot = new Robot("Gosho", 5);
        }

        [Test]
        public void Ctor()
        {
            Assert.AreEqual(2, robotManager.Capacity);
            Assert.AreEqual(robotManager.Count, 0);

        }

        [Test]
        public void Ctor_ThrowException()
        {
            RobotManager rob;
            Assert.Throws<ArgumentException>((() =>  rob = new RobotManager(-50)));

        }
        //[Test]
        //public void Robot_Ctor()
        //{
        //    Assert.AreEqual(robot.Name, "Gosho");
        //    Assert.AreEqual(robot.Battery, 5);
        //    Assert.AreEqual(robot.MaximumBattery, 5);
        //}

        [Test]
        public void Add_ThrowExceptions()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>((() => robotManager.Add(robot)));
            robotManager.Add(new Robot("PEsho", 10));
            Assert.Throws<InvalidOperationException>((() => robotManager.Add(new Robot("Tedo", 70))));
        }

        [Test]
        public void Add_Successfully()
        {
            robotManager.Add(robot);
            robotManager.Add(new Robot("Pesho",4));
            Assert.AreEqual(robotManager.Count, 2);
        }

        [Test]
        public void Remove_ThrowException()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>((() => robotManager.Remove("Pesho")));
        }

        [Test]
        public void Remove_Success()
        {
            robotManager.Add(robot);
            int before = robotManager.Count;
            robotManager.Remove("Gosho");
            int after = robotManager.Count;

            Assert.AreNotEqual(before, after);
        }

        [Test]
        public void Work_ThrowExceptions()
        {
            Assert.Throws<InvalidOperationException>((() => robotManager.Work("Gosho", "hh", 5)));
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>((() => robotManager.Work("Gosho", "hh", 10)));
        }

        [Test]
        public void Work_Success()
        {
            robotManager.Add(robot);
            robotManager.Work("Gosho", "Kopai", 3);
            Assert.AreEqual(robot.Battery, 2);
        }

        [Test]
        public void Charge_ThrowExceptionForNull()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>((() => robotManager.Charge("Pesho")));
        }
        [Test]
        public void Charge_Success()
        {
            robotManager.Add(robot);
            robotManager.Work("Gosho","hh",3);
            robotManager.Charge("Gosho");
            Assert.AreEqual(robot.Battery,5);
            Assert.AreEqual(robot.Battery,robot.MaximumBattery);
            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }
    }
}
