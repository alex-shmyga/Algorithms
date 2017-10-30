using System;

namespace Implementation.SimpleDS
{
    public class Stack
    {
        private int[] _arr;
        int top = -1;

        public Stack()
        {
            _arr = new int[2];
        }

        public int Count
        {
            get
            {
                return top + 1;
            }
        }

        public void Push(int x)
        {
            if (_arr.Length == top + 1)
            {
                int[] newArray = new int[_arr.Length * 2];
                Array.Copy(_arr, 0, newArray, 0, _arr.Length);
                _arr = newArray;
                newArray = null;
            }
            top++;
            _arr[top] = x;
        }

        private bool StackEmpty()
        {
            return (top == -1);
        }

        public int Pop()
        {
            if (StackEmpty())
            {
                throw new Exception("underflow");
            }

            return _arr[top--];
        }
    }
}
