using System;

namespace _10.LowerOrUpper
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char A = char.Parse(Console.ReadLine());

            if (char.IsUpper(A))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
