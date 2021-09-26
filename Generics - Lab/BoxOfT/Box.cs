using System.Collections;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly Stack<T> genericStack;

        public int Count => this.genericStack.Count;

        public Box()
        {
            this.genericStack = new Stack<T>();
        }

        public void Add(T element)
        {
            genericStack.Push(element);
        }
        public T Remove()
        {
            return genericStack.Pop();
        }

    }
}
