using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public List<Car> Cars { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return Cars.Count;
            }
        }

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public void Add(Car car)
        {
            if (Cars.Count < Capacity)
            {
                Cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return Cars.Remove(Cars.Where(x=>x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault());
        }

        public Car GetLatestCar()
        { 
            return Cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return Cars.FirstOrDefault(x =>(x.Manufacturer == manufacturer && x.Model == model));
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in Cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
