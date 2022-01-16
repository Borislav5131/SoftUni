using System;

namespace _05.TrainingLab
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double lengthWInMeters = double.Parse(Console.ReadLine());
            double widthHInMeters = double.Parse(Console.ReadLine());

            double widthHInCentimeters =  widthHInMeters * 100;
            int deskSpace = (int) widthHInCentimeters - 100;
            int  needDeskInWidth = deskSpace / 70;

            double lengtWInCentimeters =  lengthWInMeters * 100;
            int needDeskInLengt = (int) lengtWInCentimeters / 120;

            int needDesks = needDeskInLengt * needDeskInWidth - 3;

            Console.WriteLine($"{needDesks:F}");

        }
    }
}
