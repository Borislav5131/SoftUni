
namespace Lab_Test
{
    using NUnit.Framework;
    using System;

    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(5, 2);
            dummy = new Dummy(15, 10);
        }

        [Test]
        public void Atack_AttackingWithABrokenWeapon()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>((() => axe.Attack(dummy)));
        }

        [Test]
        public void Atack_IfWeaponLosesDurabilityAfterEachAttack()
        {
            int durabilityBeforeAtack = axe.DurabilityPoints;
            axe.Attack(dummy);
            int durabilityAfterAtack = axe.DurabilityPoints;

            Assert.AreNotEqual(durabilityAfterAtack, durabilityBeforeAtack);
        }
    }
}