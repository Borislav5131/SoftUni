using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Gosho", 10,50);
        }

        [Test]
        public void Ctor()
        {
            Assert.AreEqual(warrior.Name, "Gosho");
            Assert.AreEqual(warrior.Damage, 10);
            Assert.AreEqual(warrior.HP, 50);
        }
        [Test]
        public void ThrowExceptionForValidation()
        {
            Assert.Throws<ArgumentException>(()=>new Warrior(null,10,50) );
            Assert.Throws<ArgumentException>(()=>new Warrior("Gosho",-50,50) );
            Assert.Throws<ArgumentException>(()=>new Warrior("Gosho",10,-60) );
        }
        [Test]
        public void Attack_ThrowException()
        {
            warrior = new Warrior("Gosho", 10, 20);
            Warrior warrior2 = new Warrior("Pesho", 10, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));

            warrior = new Warrior("Gosho", 10, 40);
            warrior2 = new Warrior("Pesho", 10, 20);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));

            warrior = new Warrior("Gosho", 10, 40);
            warrior2 = new Warrior("Pesho", 50, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));
        }
    }
}