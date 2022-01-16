using System;

namespace _01.Ages
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());
            string output = "";

            if (ages <= 2)
            {
                output = "baby";
            }
            else if (ages <= 13)
            {
                output = "child";
            }
            else if (ages <= 19)
            {
                output = "teenager";
            }
            else if (ages <= 65)
            {
                output = "adult";
            }
            else if (ages >= 66)
            {
                output = "elder";
            }

            Console.WriteLine(output);
        }
    }
}
