using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Gosho",10,20);
        }

        [Test]
        public void Ctor()
        {
            Assert.AreEqual(arena.Count,0);
        }
        [Test]
        public void Enroll_AddSuccessfully()
        {
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }
        [Test]
        public void Enroll_ThrowException()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
        [Test]
        public void Fight_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Gosho","Pesho"));
        }
    }
}
