using System;

namespace _02.ExamPreparation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPoorMarks = int.Parse(Console.ReadLine());

            bool isPassed = true;
            double sumOfMarks = 0;
            double averageScore = 0;
            int counter = 0;
            int poorMarkCounter = 0;
            string lastProblem = "";
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Enough")
                {
                    break;
                }

                int mark = int.Parse(Console.ReadLine());

                if (mark <= 4)
                {
                    poorMarkCounter++;
                }
                if (poorMarkCounter >= numberOfPoorMarks)
                {
                    isPassed = false;
                    break;
                }

                counter++;
                sumOfMarks += mark;
                lastProblem = text;
            }

            if (isPassed)
            {
                averageScore = sumOfMarks / counter;
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {poorMarkCounter} poor grades.");
            }
        }
    }
}
