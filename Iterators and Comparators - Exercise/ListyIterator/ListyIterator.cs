using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private int index;
        public ListyIterator(params T[] elements)
        {
            Values = new List<T>(elements);
            index = 0;
        }
        public List<T> Values { get; set; }

        public bool Move()
        {
            if (index + 1 < Values.Count)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext() => index + 1 < Values.Count;
        public T Print()
        {
            if (Values.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                throw new InvalidOperationException();
            }

            return this.Values[index];
        }

    }
}
