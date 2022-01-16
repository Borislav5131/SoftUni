using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    Engine engine = new Engine();
                    engine.Model = input[0];
                    engine.Power = input[1];
                    engine.Displacement = input[2];
                    engine.Efficiency = input[3];
                    engines.Add(engine);
                }
                else
                {
                    if(char.IsLetter(input[2], 0))
                    {
                        Engine engine = new Engine();
                        engine.Model = input[0];
                        engine.Power = input[1];
                        engine.Efficiency = input[2];
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine();
                        engine.Model = input[0];
                        engine.Power = input[1];
                        engine.Displacement = input[2];
                        engines.Add(engine);
                    }
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = null;

                foreach (var eng in engines)
                {
                    if (eng.Model == input[1])
                    {
                        engine = eng;
                    }
                }

                if (input.Length == 2)
                {
                    Car car = new Car();
                    car.Model = input[0];
                    car.Engine = engine;
                    cars.Add(car);
                }
                else if (input.Length == 3)
                {
                    if (char.IsDigit(input[2],0))
                    {
                        Car car = new Car();
                        car.Model = input[0];
                        car.Engine = engine;
                        car.Weight = input[2];
                        cars.Add(car);
                    }
                    else
                    {
                        Car car = new Car();
                        car.Model = input[0];
                        car.Engine = engine;
                        car.Color = input[2];
                        cars.Add(car);
                    }
                }
                else
                {
                    Car car = new Car();
                    car.Model = input[0];
                    car.Engine = engine;
                    car.Weight = input[2];
                    car.Color = input[3];
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
