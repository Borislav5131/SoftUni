using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                string[] inputPeople = Console.ReadLine().Split(";");

                foreach (var per in inputPeople)
                {
                    string[] tokens = per.Split("=");
                    Person person = new Person(tokens[0],decimal.Parse(tokens[1]));
                    people.Add(person);
                }

                string[] inputProducts = Console.ReadLine().Split(";");

                foreach (var pro in inputProducts)
                {
                    string[] tokens = pro.Split("=");
                    Product product = new Product(tokens[0], decimal.Parse(tokens[1]));
                    products.Add(product);
                }

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    var currPerson = people.Where(x => x.Name == tokens[0]).First();
                    var currProduct = products.Where(x => x.Name == tokens[1]).First();

                    if (currPerson.Money >= currProduct.Cost)
                    {
                        currPerson.Products.Add(currProduct);
                        currPerson.MoneyDecrease(currProduct.Cost);
                        Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{currPerson.Name} can't afford {currProduct.Name}");
                    }

                    input = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
