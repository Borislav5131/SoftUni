using System;
using System.Collections.Generic;

namespace _07.TheV_Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> theVLogger =
                new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Statistics")
                {
                    break;
                }

                string firstVlogger = input[0];
                string command = input[1];

                if (command == "joined")
                {
                    if (!theVLogger.ContainsKey(firstVlogger))
                    {
                        theVLogger.Add(firstVlogger, new Dictionary<string, int>());
                    }
                }
                else if (command == "followed")
                {
                    string secondVlogger = input[2];

                    if (firstVlogger == secondVlogger)
                    {
                        return;
                    }

                    if (theVLogger.ContainsKey(firstVlogger) && theVLogger.ContainsKey(secondVlogger))
                    {
                        if (!theVLogger[firstVlogger].ContainsKey(secondVlogger))
                        {

                        }
                    }
                }
            }
                
        }
    }
}
