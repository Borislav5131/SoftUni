using System;

namespace _04.Walking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double goal = 10000;
            double totalSteps = 0;

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Going home")
                {
                    double goingHomeSteps = double.Parse(Console.ReadLine());
                    totalSteps += goingHomeSteps;
                    break;
                }
                double steps = double.Parse(text);
                totalSteps += steps;

                if (totalSteps >= goal)
                {
                    break;
                }
            }
            if (totalSteps >=goal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - goal} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goal - totalSteps } more steps to reach goal.");
            }
        }
    }
}
