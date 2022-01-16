using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");

            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            char[] arr = line.ToCharArray();

                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (char.IsPunctuation(arr[i]))
                                {
                                    arr[i] = '@';
                                }  
                            }

                            line = string.Join("", arr); 
                            var newLine =line.Split().Reverse().ToList();
                            writer.WriteLine(string.Join(" ", new));
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
