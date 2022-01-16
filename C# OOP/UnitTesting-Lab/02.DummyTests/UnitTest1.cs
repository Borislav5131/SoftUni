using System;

namespace _02.DummyTests
{
    using NUnit.Framework;

    public class Tests
    {
        private Dummy dummy;
        private Axe axe;

        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(5, 10);
        }

        [Test]
        [TestCase(2)]
        public void TakeAtack_DummyLosesHealthIfAttacked(int attackPoints)
        {
            int healthBeforeAttack = dummy.Health;
            dummy.TakeAttack(attackPoints);
            int healthAfterAttack = dummy.Health;

            Assert.AreNotEqual(healthBeforeAttack, healthAfterAttack);
        }

        [Test]
        [TestCase(3)]
        public void TakeAttack_DeadDummyThrowsExceptionIfAttacked(int attackPoints)
        {
            dummy.TakeAttack(attackPoints);
            dummy.TakeAttack(attackPoints);

            Assert.Throws<InvalidOperationException>((() => dummy.TakeAttack(attackPoints)));
        }

        [Test]
        public void GiveExperience_AliveDummyCanNotGiveXP()
        {
            Assert.Throws<InvalidOperationException>((() => dummy.GiveExperience()));
        }

        [Test]
        [TestCase(6)]
        public void GiveExperience_DeadDummyCanGiveXP(int attackPoints)
        {
            dummy.TakeAttack(attackPoints);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
        }
    }
}