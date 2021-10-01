using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public List<T> Values { get; set; }
        private int index;

        public CustomStack(List<T> values)
        {
            index = -1;
            Values = new List<T>(values);
        }

        public void Push(T item)
        {
            index++;
            Values.Insert(0, item);
        }

        public void Pop()
        {
            if (Values.Count <= 0)
            {
                throw new InvalidOperationException("No elements");
            }

            this.Values.RemoveAt(0);
            index--;
        }

        public override string ToString()
        {
            return $"{string.Join(Environment.NewLine, Values)}";
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = index - 1; i >= 0; i--)
            {
                yield return Values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
