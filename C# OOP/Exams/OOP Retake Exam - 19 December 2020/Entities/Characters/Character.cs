using System;
using System.Security;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;
        private double health;
        private double armor;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }

        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value <= 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }

            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value <= 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; }
        public IBag Bag { get; }
        public bool IsAlive { get; set; } = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor - hitPoints >= 0)
            {
                Armor -= hitPoints;
            }
            else
            {
                double leftPoints = hitPoints - Armor;
                Armor = 0;
                Health -= leftPoints;

                if (Health <= 0)
                {
                    Health = 0;
                }
            }

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }


    }
}