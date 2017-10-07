
namespace Implementation.CormenExercices
{
    public class InversionCounter
    {
        public static long GetCount(int[] arr)
        {
            return MergeSort(arr, 0, arr.Length - 1);
        }

        private static long Merge(int[] arr, int l, int m, int r)
        {
            long inversions = 0;

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
            bool counted = false;
            while (i < n1 && j < n2)
            {
                if (!counted && L[i] > R[j])
                {
                    inversions = inversions + n1 - i;
                    counted = true;
                }

                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                    counted = false;
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

            return inversions;
        }

        private static long MergeSort(int[] arr, int l, int r)
        {
            long inversions = 0;
            if (l < r)
            {
                int m = (l + r) / 2;
                inversions += MergeSort(arr, l, m);
                inversions += MergeSort(arr, m + 1, r);
                inversions += Merge(arr, l, m, r);
            }

            return inversions;
        }
    }
}
