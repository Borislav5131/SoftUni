using System;
using System.Xml;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double initialHealth = 100;
        private const double initialArmor = 50;
        private const double initialAbilityPoints = 40;
        private static Bag bag = new Satchel();

        public Warrior(string name)
            : base(name, initialHealth, initialArmor, initialAbilityPoints, bag)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
