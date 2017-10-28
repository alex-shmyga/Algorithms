using System;

namespace Implementation.KormanExercices
{
    public class SmartMergeSort
    {
        private static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int ii = 0; ii < n1; ++ii)
                L[ii] = arr[l + ii];
            for (int jj = 0; jj < n2; ++jj)
                R[jj] = arr[m + 1 + jj];

            int i = 0, j = 0;

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

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        private static void Sort(int[] arr, int l, int r, int k)
        {
            if (arr.Length <= k)
            {
                Sorting.InsertionSort(arr);
                return;
            }

            if (l < r)
            {
                int m = (l + r) / 2;

                Sort(arr, l, m, k);
                Sort(arr, m + 1, r, k);
                Merge(arr, l, m, r);
            }
        }

        public static void Sort(int[] arr)
        {
            int k = GetK();
            Sort(arr, 0, arr.Length - 1, k);
        }

        private static int GetK()
        {
            int k = 2;
            while (Math.Pow(k, 2) < (k * Math.Log(2, k)))
            {
                k = k * 2;
            }

            return k;
        }
    }
}
