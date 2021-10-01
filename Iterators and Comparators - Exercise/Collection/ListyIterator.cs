using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            foreach (var item in Values)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}