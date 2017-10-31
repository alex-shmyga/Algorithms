using System;

namespace Implementation.SimpleDS
{
    public class LinkedList
    {
        Node head;

        public LinkedList()
        {
            head = null;
        }

        public int Count
        {
            get
            {
                return getLength();
            }
        }


        private int getLength()
        {
            var node = head;

            int c = 0;
            while (node != null)
            {
                c++;
                node = node.next;
            }

            return c;
        }

        public void Insert(int key)
        {
            var newNode = new Node(key);
            newNode.next = head;

            if (head != null)
            {
                head.prev = newNode;
            }

            head = newNode;
            newNode.prev = null;
        }

        public Node Search(int k)
        {
            var node = head;

            while (node != null && node.key != k)
            {
                node = node.next;
            }

            return node;
        }

        public void Remove(int k)
        {
            var node = Search(k);

            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            else
            {
                head = node.next;
            }

            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
        }
    }

    public class Node
    {
        public int key;
        public Node prev;
        public Node next;

        public Node(int x)
        {
            key = x;
        }
    }
}
