using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var str in collection)
            {
                this.Push(str);
            }
        }
    }
}
