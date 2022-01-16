using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();

                Box box = new Box();
                Item item = new Item();

                box.SerialNumber = int.Parse(tokens[0]);
                item.Name = tokens[1];
                box.Item = tokens[1];
                box.ItemQuantity = int.Parse(tokens[2]);
                item.Price = double.Parse(tokens[3]);
                box.ItemPrice = double.Parse(tokens[3]);

                box.PriceForBox = box.ItemQuantity * item.Price;

                boxes.Add(box);
            }

            List<Box> sortedList = boxes.OrderByDescending(x => x.PriceForBox).ToList();

            foreach (Box box in sortedList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item} - ${box.ItemPrice:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public double ItemPrice { get; set; }
        public int SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
    }
}
