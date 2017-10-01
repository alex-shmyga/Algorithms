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

        public static int[] InsertionSort(int[] ar)
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

            return ar;
        }

        public static int[] InsertionSortDesc(int[] ar)
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

            return ar;
        }


        #endregion
    }
}
