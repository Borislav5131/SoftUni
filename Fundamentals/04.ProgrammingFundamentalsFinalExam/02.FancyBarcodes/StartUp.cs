using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Regex regexInput = new Regex(@"@#+(?<barcode>[A-Z][A-Za-z\d]+[A-Z])@#+");

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                Match match = regexInput.Match(input);

                if (match.Success)
                {
                    string productGroup = "";
                    bool isFound = false;

                    foreach (var @char in match.ToString())
                    {
                        if (char.IsDigit(@char))
                        {
                            productGroup += @char;
                            isFound = true;
                        }
                    }

                    if (isFound)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00 ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
