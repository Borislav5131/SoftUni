using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
    {
        private List<Character> characters;
        private Stack<Item> pool;
		public WarController()
        {
            characters = new List<Character>();
            pool = new Stack<Item>();
        }

		public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character;

            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
			else if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException($"Invalid character type {characterType }!");
            }

			characters.Add(character);
            return $"{name} joined the party!";
        }

		public string AddItemToPool(string[] args)
        {
            string name = args[0];
            Item item;

            if (name == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (name == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item { name }!");
            }

            pool.Push(item);
            return $"{name} added to pool.";
        }

		public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = characters.FirstOrDefault(x => x.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (pool.Count <= 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = pool.Pop();
            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

		public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = characters.FirstOrDefault(x => x.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

		public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            characters = characters
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health)
                .ToList();

            foreach (var character in characters)
            {
                string result = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {result}");
            }

            return sb.ToString().TrimEnd();
        }

		public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = characters.FirstOrDefault(x=> x.Name == attackerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker is null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiver is null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Warrior warrior = attacker as Warrior;

            if (warrior is null)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            warrior.Attack(receiver);

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

		public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = characters.FirstOrDefault(x=>x.Name == healerName);
            Character healingCharacter = characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer is null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (healingCharacter is null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            Priest priest = healer as Priest;

            if (priest is null)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            priest.Heal(healingCharacter);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{healerName} heals {healingReceiverName} for {healer.AbilityPoints}! {healingCharacter.Name} has {healingCharacter.Health} health now!");

            return sb.ToString().TrimEnd();
        }
	}
}
