using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private NodeList<T> head;
        private NodeList<T> tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new NodeList<T>(element);
            }
            else
            {
                NodeList<T> newHead = new NodeList<T>(element);
                NodeList<T> oldHead = this.head;

                this.head = newHead;
                this.head.Next = oldHead;
                oldHead.Previous = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new NodeList<T>(element);
            }
            else
            {
                NodeList<T> newTail = new NodeList<T>(element);
                NodeList<T> oldTail = this.tail;

                this.tail = newTail;
                newTail.Previous = oldTail;
                oldTail.Next = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T removedElement = this.head.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                NodeList<T> newHead = this.head.Next;

                this.head = newHead;
                newHead.Previous = null;
            }

            this.Count--;

            return removedElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T removedElement = this.tail.Value;

            if (this.Count == 0)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                NodeList<T> newTail = this.tail.Previous;

                this.tail = newTail;
                newTail.Next = null;

            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            NodeList<T> currentElement = this.head;

            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int counter = 0;

            NodeList<T> currentElement = this.head;

            while (currentElement != null)
            {
                array[counter] = currentElement.Value;
                currentElement = currentElement.Next;
                counter++;
            }

            return array;
        }
    }
}
