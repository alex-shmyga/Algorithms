using System;

namespace Implementation.CormenExercices
{

    /// <summary>
    /// Very basic implementaion MaxPriorityQueue using array, not thread safe
    /// </summary>
    public class MaxPriorityQueue
    {
        int[] array = new int[0];

        public void Insert(int key)
        {
            var newArr = new int[array.Length + 1];
            Array.Copy(array, 0, newArr, 0, array.Length);
            newArr[newArr.Length - 1] = Int32.MinValue;
            array = newArr;
            IncreaseKey(array.Length - 1, key);
        }

        public int ExtractMax()
        {
            if (array.Length < 1)
                throw new Exception("Queue is empty");

            int max = array[0];
            var newArr = new int[array.Length - 1];
            Array.Copy(array, 1, newArr, 0, array.Length - 1);
            array = newArr;
            MaxHeapify(array.Length, 0);

            return max;
        }

        public int GetMax()
        {
            return array[0];
        }

        private void IncreaseKey(int i, int key)
        {
            if (key < array[i])
                throw new Exception("New key is less then current");

            array[i] = key;
            while (i > 0 && array[Parent(i)] < array[i])
            {
                Swap(ref array[i], ref array[Parent(i)]);
                i = Parent(i);
            }
        }

        private int Parent(int i)
        {
            if (i % 2 == 0)
                return (i - 2) / 2;

            return (i - 1) / 2;
        }

        private void MaxHeapify(int length, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < length && array[l] > array[i])
                largest = l;

            if (r < length && array[r] > array[largest])
                largest = r;

            if (largest != i)
            {
                Swap(ref array[i], ref array[largest]);
                MaxHeapify(length, largest);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
