using System;

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

        #region HeapSort

        public static void HeapSort(int[] arr)
        {
            BuildMaxHeap(arr);

            int size = arr.Length;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                size = size - 1;
                MaxHeapify(arr, size, 0);
            }
        }

        private static void BuildMaxHeap(int[] arr)
        {
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, arr.Length, i);
            }
        }

        private static void MaxHeapify(int[] arr, int length, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < length && arr[l] > arr[i])
                largest = l;

            if (r < length && arr[r] > arr[largest])
                largest = r;

            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);
                MaxHeapify(arr, length, largest);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void HeapSortDesc(int[] arr)
        {
            BuildMinHeap(arr);

            int size = arr.Length;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                size = size - 1;
                MinHeapify(arr, size, 0);
            }
        }

        private static void BuildMinHeap(int[] arr)
        {
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                MinHeapify(arr, arr.Length, i);
            }
        }

        private static void MinHeapify(int[] arr, int length, int i)
        {
            int smalest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < length && arr[l] < arr[i])
                smalest = l;

            if (r < length && arr[r] < arr[smalest])
                smalest = r;

            if (smalest != i)
            {
                Swap(ref arr[i], ref arr[smalest]);
                MinHeapify(arr, length, smalest);
            }
        }

        #endregion

        #region QuickSort

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(arr, p, r);
                QuickSort(arr, p, q - 1);
                QuickSort(arr, q + 1, r);
            }
        }

        private static int Partition(int[] arr, int p, int r)
        {
            int x = arr[r];
            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                if (arr[j] <= x)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }

            Swap(ref arr[i + 1], ref arr[r]);
            return i + 1;
        }

        #endregion

        #region RandomizeQuickSort

        public static void RandomizeQuickSort(int[] array)
        {
            RandomizeQuickSort(array, 0, array.Length - 1);
        }

        private static void RandomizeQuickSort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = RandomizePartition(arr, p, r);
                RandomizeQuickSort(arr, p, q - 1);
                RandomizeQuickSort(arr, q + 1, r);
            }
        }

        private static int RandomizePartition(int[] arr, int p, int r)
        {
            int i = new Random().Next(p, r);
            Swap(ref arr[r], ref arr[i]);
            return Partition(arr, p, r);
        }

        #endregion

        #endregion
    }
}
