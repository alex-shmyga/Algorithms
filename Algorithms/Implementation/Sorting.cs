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


        #region Worst-case performance: O(n log n)

        #region Merge Sort

        // Merges two subarrays of arr[].
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        private static void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            /* Create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /*Copy data to temp arrays*/
            for (int ii = 0; ii < n1; ++ii)
                L[ii] = arr[l + ii];
            for (int jj = 0; jj < n2; ++jj)
                R[jj] = arr[m + 1 + jj];


            /* Merge the temp arrays */

            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts arr[l..r] using merge()
        private static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle point
                int m = (l + r) / 2;

                // Sort first and second halves
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                // Merge the sorted halves
                Merge(arr, l, m, r);
            }
        }

        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        #endregion

        #endregion
    }
}
