using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> data;

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public Box()
        {
            data = new List<T>();
        }

        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            var element = data.Last();
            data.Remove(element);
            return element;
        }
    }
}
