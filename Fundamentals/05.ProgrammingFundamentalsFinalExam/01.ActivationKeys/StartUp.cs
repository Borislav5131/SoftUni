using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Generate")
                {
                    break;
                }

                string[] tokens = input.Split(">>>");

                switch (tokens[0])
                {
                    case "Contains":

                        string substring = tokens[1];

                        if (key.Contains(substring))
                        {
                            Console.WriteLine($"{key} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }

                        break;

                    case "Flip":

                        string type = tokens[1];
                        int startIndex = int.Parse(tokens[2]);
                        int endIndex = int.Parse(tokens[3]);

                        string result = "";

                        if (type == "Upper")
                        {
                            result = key.Substring(0, startIndex - 0)
                                +key.Substring(startIndex, endIndex - startIndex).ToUpper()
                                +key.Substring(endIndex , key.Length - endIndex);

                            key = result;
                        }
                        else if (type == "Lower")
                        {
                            result = key.Substring(0, startIndex - 0)
                                + key.Substring(startIndex, endIndex - startIndex).ToLower()
                                + key.Substring(endIndex, key.Length - endIndex);

                            key = result;
                        }

                        Console.WriteLine(key);

                        break;

                    case "Slice":

                        int startInd = int.Parse(tokens[1]);
                        int endInd = int.Parse(tokens[2]);

                        key = key.Remove(startInd, endInd - startInd);

                        Console.WriteLine(key);

                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {key}");

        }
    }
}
