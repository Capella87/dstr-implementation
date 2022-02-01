using System;

namespace Singly
{
    public class SinglyList
    {
        internal class Node
        {
            internal int? _data;
            internal Node? _next;

            public Node()
            {
                _data = null;
                _next = null;
            }

            public Node(int data) : this()
            {
                this._data = data;
            }
        }

        private Node _head;
        private Node _tail;
        private int _size;
        private Node _prevTail;

        public int size { get => _size; }

        public SinglyList()
        {
            _head = new Node();
            _tail = new Node();
            _head._next = _tail;
            _prevTail = _head;
            _size = 0;
        }

        public bool InsertFront(int d) // Insert an element behind _head.
        {
            var newNode = new Node(d);

            newNode._next = _head._next;
            _head._next = newNode;
            if (_size == 0) _prevTail = newNode;
            _size++;

            return true;
        }

        public bool Append(int d)
        {
            var newNode = new Node(d);
            
            _prevTail._next = newNode;
            newNode._next = _tail;
            _prevTail = newNode;
            _size++;

            return true;
        }

        public bool Insert(int d, int n) // Insert an element before the target. Find the target first and insert.
        {
            Node? t = SearchNode(n, out Node? targetBefore);
            if (t == null || targetBefore == null) return false;
            var newNode = new Node(d);

            newNode._next = targetBefore._next;
            targetBefore._next = newNode;
            if (newNode._next == _tail) _prevTail = newNode;
            _size++;

            return true;
        }

        public bool FrontTraverse() // Traverse from _head to _tail. Returns false if the list is empty.
        {
            if (_size == 0)
            {
                Console.WriteLine("No entries");
                return false;
            }
            Node? cur = _head._next;
            while (cur != null && cur != _tail)
            {
                Console.Write($"{cur._data} ");
                cur = cur._next;
            }
            Console.WriteLine();

            return true;
        }

        public bool RemoveFront()
        {
            if (_size == 0)
            {
                Console.WriteLine("No Entries");
                return false;
            }

            Node? cur = _head._next;
            if (cur != null)
            {
                _head._next = cur._next;
                if (cur == _prevTail) _prevTail = _head;
                _size--;

                return true;
            }

            return false;
        }
        public bool Remove(int target)
        {
            if (_size == 0)
            {
                Console.WriteLine("No entries");
                return false;
            }

            Node? cur = SearchNode(target, out Node? prevNode);
            if (cur != null && prevNode != null)
            {
                prevNode._next = cur._next;
                if (cur == _prevTail) _prevTail = prevNode;
                _size--;
                return true;
            }

            return false;
        }

        private Node? SearchNode(int query)
        {
            if (_size == 0)
            {
                Console.WriteLine("No entries");
                return null;
            }

            Node? cur = _head._next;
            while (cur != null && cur != _tail)
            {
                if (cur != null && cur._data == query)
                    return cur;
                cur = cur._next;
            }

            return null;
        }

        private Node? SearchNode(int query, out Node? targetBefore)
        {
            if (_size == 0)
            {
                Console.WriteLine("No entries");
                targetBefore = null;
                return null;
            }

            Node? cur = _head._next;
            targetBefore = _head;
            while (cur != null && cur != _tail)
            {
                if (cur != null && cur._data == query)
                    return cur;
                targetBefore = cur;
                cur = cur._next;
            }

            return null;
        }
        
        public bool Find(int query)
        {
            Node? hasQuery = SearchNode(query);
            if (hasQuery != null)
            {
                Console.WriteLine($"{query} is exist in the list.");
                return true;
            }
            else
            {
                Console.WriteLine($"{query} is NOT exist in the list.");
                return false;
            }
        }
    }

    public static class MainApp
    {
        public static void Main()
        {
            SinglyList dl = new SinglyList();

            dl.InsertFront(1);
            dl.InsertFront(2);
            dl.InsertFront(3);
            dl.InsertFront(4);
            dl.Insert(123, 3);
            dl.Append(456);

            Console.Write("Front: ");
            dl.FrontTraverse();


            // Remove some elements from the list and traverse elements.
            dl.RemoveFront();
            dl.RemoveFront();
            dl.FrontTraverse();

            Console.WriteLine($"There are {dl.size} entries in the list.");

            // Search 1 and 4.
            dl.Find(1);
            dl.Find(4);

            // Remove 1 from the list.
            dl.Remove(1);
            dl.FrontTraverse();
        }
    }
}