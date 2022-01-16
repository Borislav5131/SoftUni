using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] parts = Console.ReadLine().Split();
                string hero = parts[0];
                int HP = int.Parse(parts[1]);
                int MP = int.Parse(parts[2]);

                heroes.Add(hero, new Hero());
                heroes[hero].HP = HP;
                heroes[hero].MP = MP;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" - ");
                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }
                else if (command == "CastSpell")
                {
                    string heroName = tokens[1];
                    int MPNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    if (heroes[heroName].MP >= MPNeeded)
                    {
                        heroes[heroName].MP -= MPNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    string heroName = tokens[1];
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    heroes[heroName].HP -= damage;

                    if (heroes[heroName].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (command == "Recharge")
                {
                    string heroName = tokens[1];
                    int amount = int.Parse(tokens[2]);

                    int lastMP = heroes[heroName].MP;
                    heroes[heroName].MP += amount;

                    if (heroes[heroName].MP > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - lastMP} MP!");
                        heroes[heroName].MP = 200;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else if (command == "Heal")
                {
                    string heroName = tokens[1];
                    int amount = int.Parse(tokens[2]);

                    int lastHP = heroes[heroName].HP;
                    heroes[heroName].HP += amount;

                    if (heroes[heroName].HP > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - lastHP} HP!");
                        heroes[heroName].HP = 100;
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
            }

            heroes = heroes
                .OrderByDescending(x => x.Value.HP)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            foreach (var kvp in heroes)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($"  HP: {kvp.Value.HP}");
                Console.WriteLine($"  MP: {kvp.Value.MP}");
            }
        }
    }
}
