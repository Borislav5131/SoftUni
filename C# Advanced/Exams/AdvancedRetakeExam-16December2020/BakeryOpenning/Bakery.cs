using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> Employees { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count 
        {
            get
            {
                return Employees.Count;
            }

        } 

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Employees = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (Employees.Count < Capacity)
            {
                Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            var employee = Employees.Where(x => x.Name == name).FirstOrDefault();

            if (Employees.Contains(employee))
            {
                Employees.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return Employees.OrderByDescending(x => x.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return Employees.Where(x => x.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}");
            foreach (var employee in Employees)
            {
                sb.AppendLine($"{employee}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
