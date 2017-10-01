using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Sorting
    {
        #region Worst-case performance: О(n2)

        public static void InsertionSort(int[] ar)
        {
            for (int j = 1; j <= ar.Length - 1; j++)
            {
                int key = ar[j];

                int i = j - 1;
                while (i >= 0 && ar[i] > key)
                {
                    ar[i + 1] = ar[i];
                    i = i - 1;
                }

                ar[i + 1] = key;
            }
        }

        public static void InsertionSortDesc(int[] ar)
        {
            for (int j = 1; j <= ar.Length - 1; j++)
            {
                int key = ar[j];

                int i = j - 1;
                while (i >= 0 && ar[i] < key)
                {
                    ar[i + 1] = ar[i];
                    i = i - 1;
                }

                ar[i + 1] = key;
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        #endregion
    }
}
