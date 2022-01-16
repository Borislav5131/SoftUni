using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string user = tokens[1];
               

                if (command == "register")
                {
                    string licensePlate = tokens[2];

                    if (parking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[user]}");
                    }
                    else
                    {
                        parking.Add(user, licensePlate);
                        Console.WriteLine($"{user} registered {licensePlate} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (!parking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        parking.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in parking)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
