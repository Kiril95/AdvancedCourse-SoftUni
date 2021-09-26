using System;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] array = new T[length];
            Array.Fill(array, item, 0, length);
            return array;
        }
    }
}
