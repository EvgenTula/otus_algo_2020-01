namespace task3DynamicArray
{
    class Node<T>
    {
        private T item;
        private Node<T> next;

        public Node(T item, Node<T> next)
        {
            this.item = item;
            this.next = next;
        }

        public Node(T item)
        {
            this.item = item;
            this.next = null;
        }

        public T GetItem()
        {
            return item;
        }

        public Node<T> GetNext()
        {
            return next;
        }

        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

    }
}
