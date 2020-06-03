namespace Task9Hashtable
{
    class HashtableChain<V>
    {
        private int maxCount;
        private int currentCount;
        public int count;
        
        private Node<V>[] _table;
        public Node<V>[] table
        { 
            get { return _table; }
            set
            {
                _table = value;
                maxCount = _table.Length - (int)(_table.Length * 0.2);
            }
        }

        public HashtableChain(int size)
        {
            table = new Node<V>[size];
        }

        public void insert(Node<V> newNode)
        {
            if (currentCount >= maxCount)
            {
                table = TableResize(table.Length * 2);
            }
            int hashVal = GetHashCode(newNode.key);
            if (table[hashVal] != null)
            {
                Node<V> node = table[hashVal];
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = newNode;
            }
            else
            {
                table[hashVal] = newNode;
                currentCount++;
                
            }
            count++;
        }

        public Node<V> find(int key)
        {
            int hashVal = GetHashCode(key);
            var item = table[hashVal];
            while (item.key != key)
            {
                if (item.next == null)
                    return null;
                else
                    item = item.next;
            }
            return item;
        }

        public void remove(int key)
        {
            int hashVal = GetHashCode(key);
            var item = table[hashVal];
           
            if (key == item.key)
            {
                table[hashVal] = item.next;
                if (table[hashVal] == null)
                {
                    currentCount--;
                    count--;
                }
            }
            else
            {
                var prevItem = item;
                while (item.key != key)
                {
                    if (item.next != null)
                    {
                        prevItem = item;
                        item = item.next;
                    }
                    else
                    {
                        return;
                    }
                }
                prevItem.next = item.next;
                count--;
            }
        }

        private Node<V>[] TableResize(int newSize)
        {
            Node<V>[] newTable = new Node<V>[newSize];
            for(int i = 0; i < table.Length; i++)
            {
                var node = table[i];
                while(node != null)
                {
                    int hashVal = GetHashCode(node.key, newTable.Length);
                    if (newTable[hashVal] == null)
                    {
                        newTable[hashVal] = node.Copy();
                    }
                    else
                    {
                        var newNode = newTable[hashVal];
                        while(newNode.next != null)
                        {
                            newNode = newNode.next;
                        }
                        newNode.next = node.Copy();
                    }
                    node = node.next;
                }
            }
            return newTable;
        }

        private int GetHashCode(int key)
        {
            return GetHashCode(key, table.Length);
        }

        private int GetHashCode(int key, int size)
        {
            return key % size;
        }
    }

    public class Node<V>
    {        
        public int key;
        public V val;
        public Node<V> next;
        public Node(int key, V val)
        {
            this.key = key;
            this.val = val;           
        }

        public Node<V> Copy()
        {
            Node<V> result = new Node<V>(this.key, this.val);
            return result;
        }
    }
}
