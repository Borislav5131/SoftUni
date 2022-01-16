using System;
using System.Collections.Generic;
using System.Data;
using _04.WildFarm.AnimalClasses.Birds;
using _04.WildFarm.AnimalClasses.Mammals;
using _04.WildFarm.AnimalClasses.Mammals.FelineMammals;
using _04.WildFarm.FoodClasses;
using _04.WildFarm.Interfaces;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IAnimal> animals = new List<IAnimal>();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string type = tokens[0];
                IAnimal animal = null;

                switch (type)
                {
                    case "Hen":
                        animal = new Hen(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3]));
                        break;
                    case "Owl":
                        animal = new Owl(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3]));
                        break;
                    case "Mouse":
                        animal = new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                        break;
                    case "Dog":
                        animal = new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                        break;
                    case "Cat":
                        animal = new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                }

                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                string[] foodInput = Console.ReadLine().Split();
                string foodType = foodInput[0];
                IFood food = null;

                switch (foodType)
                {
                    case "Fruit":
                        food = new Fruit(int.Parse(foodInput[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(foodInput[1]));
                        break;
                    case "Seeds":
                        food = new Seeds(int.Parse(foodInput[1]));
                        break;
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodInput[1]));
                        break;
                }

                animal.EatFood(food);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
