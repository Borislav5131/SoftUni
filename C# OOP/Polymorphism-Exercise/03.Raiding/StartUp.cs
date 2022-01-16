using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            List<BaseHero> heroes = new List<BaseHero>();

            while (counter != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    switch (heroType)
                    {
                        case "Druid":
                            Druid druid = new Druid(heroName);
                            heroes.Add(druid);
                            break;
                        case "Paladin":
                            Paladin paladin = new Paladin(heroName);
                            heroes.Add(paladin);
                            break;
                        case "Rogue":
                            Rogue rogue = new Rogue(heroName);
                            heroes.Add(rogue);
                            break;
                        case "Warrior":
                            Warrior warrior = new Warrior(heroName);
                            heroes.Add(warrior);
                            break;
                        default:
                            throw new ArgumentException("Invalid hero!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                counter++;
            }

            long bossPower = long.Parse(Console.ReadLine());
            long sumPower = 0;

            foreach (var hero in heroes)
            {
                sumPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
