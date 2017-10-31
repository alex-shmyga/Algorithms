using System;

namespace Implementation.SimpleDS
{
    public class Queue
    {
        private int[] _arr;
        int head = 0;
        int tail = -1;
        int lenght = 0;

        public int Count
        {
            get
            {
                return lenght;
            }
        }

        public Queue()
        {
            _arr = new int[2];
        }

        public void Enqueue(int x)
        {
            if (_arr.Length == tail + 1)
            {
                int[] newArray = new int[_arr.Length * 2];
                Array.Copy(_arr, 0, newArray, 0, _arr.Length);
                _arr = newArray;
                newArray = null;
            }

            _arr[++tail] = x;
            lenght++;
        }

        public int Dequeue()
        {
            int x = _arr[head++];
            lenght--;

            return x;
        }
    }
}
