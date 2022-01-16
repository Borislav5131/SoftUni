using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _03.SoftUniBarIncome
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%([^|$%.])*<(?<product>\w+)>([^|$%.])*\|(?<count>\d+)\|([^|$%.])*(?<price>\d+\.?\d*)\$";

            double totalSum = 0;

            Dictionary<string, Dictionary<string, double>> barInfo = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of shift")
                {
                    break;
                }

                MatchCollection matches = Regex.Matches(line, pattern);

                foreach (Match match in matches)
                {
                    string name = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double sum = count * price;
                    totalSum += sum;

                    barInfo.Add(name, new Dictionary<string, double>());
                    barInfo[name].Add(product, sum);
                }
            }

            foreach (var kvp in barInfo)
            {
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"{kvp.Key}: {item.Key} - {item.Value:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
