using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthdabel> all = new List<IBirthdabel>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }
                else if (input[0] == "Citizen")
                {
                    Citizen person = new Citizen(input[1],int.Parse(input[2]),input[3],input[4]);
                    all.Add(person);
                }
                else if (input[0] == "Robot")
                {
                    Robot robot = new Robot(input[1],input[2]);
                }
                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    all.Add(pet);
                }
            }

            string specificYear = Console.ReadLine();

            all.Where(x => x.Birthdates.EndsWith(specificYear))
                .ToList()
                .ForEach(x=>Console.WriteLine(x.Birthdates));
        }
    }
}
