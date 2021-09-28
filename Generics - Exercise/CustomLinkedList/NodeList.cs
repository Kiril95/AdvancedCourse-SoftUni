namespace CustomDoublyLinkedList
{
    public class NodeList<T>
    {
        public NodeList(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public NodeList<T> Previous { get; set; }
        public NodeList<T> Next { get; set; }

    }
}
