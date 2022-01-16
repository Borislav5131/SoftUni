using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        private decimal money;

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> Products { get; set; }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public void MoneyDecrease(decimal value)
        {
            Money -= value;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Products.Count > 0)
            {
                sb.AppendLine($"{Name} - {string.Join(", ", Products)}");
            }
            else
            {
                sb.AppendLine($"{Name} - Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
