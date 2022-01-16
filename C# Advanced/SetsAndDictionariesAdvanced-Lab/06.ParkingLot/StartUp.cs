using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(", ");

                if (tokens[0] == "END")
                {
                    break;
                }
                if (tokens[0] == "IN")
                {
                    set.Add(tokens[1]);
                }
                else
                {
                    set.Remove(tokens[1]);
                }
            }

            if (set.Count > 0)
            {
                foreach (var numberPlate in set)
                {
                    Console.WriteLine(numberPlate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
