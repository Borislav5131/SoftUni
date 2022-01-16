using System;

namespace _09.FruitOrVegetable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string output = "";

            switch (product)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    output = "fruit";
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    output = "vegetable";
                    break;
                default:
                    output = "unknown";
                    break;
            }
            Console.WriteLine(output);
        }
    }
}
