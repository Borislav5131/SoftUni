using System;

namespace _08.FishTank
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()) * 0.01;

            int theVolumeOfTheAquarium = length * width * height;
            double totalLiters = theVolumeOfTheAquarium * 0.001;
            double needLiters = totalLiters * (1 - percentage);

            Console.WriteLine(needLiters);

        }
    }
}
