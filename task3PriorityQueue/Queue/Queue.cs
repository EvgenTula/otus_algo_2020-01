namespace task3DynamicArray.Queue
{
    class Queue<T>
    {
        private Node<T> head, tail;

        public Queue()
        {
            head = tail = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public Node<T> GetHead()
        {
            return head;
        }
        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (IsEmpty())
            {
                head = tail = newNode;
            }
            else
            {
                tail.SetNext(newNode);
                tail = newNode;
            }       
        }

        public T Dequeue()
        {
            if (IsEmpty())
                return default(T);
            Node<T> tmp = head;
            head = head.GetNext();
            return tmp.GetItem();
        }

        public T Peek()
        {
            return head.GetItem();
        }
    }
}
