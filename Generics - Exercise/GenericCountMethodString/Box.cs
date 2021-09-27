using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(List<T> info)
        {
            Info = new List<T>(info);
        }
        public List<T> Info { get; set; }

        public int CountGreaterValues(T value)
        {
            int counter = 0;

            foreach (var item in Info)
            {
                if (item.CompareTo(value) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
