using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.CormenExercices
{
    public static class ArrayExtensions
    {
        public static long GetMaxSubarrSum(this long[] array)
        {
            return FindMaximumSubarray(array, 0, array.Length - 1);
        }

        private static long FindMaximumSubarray(long[] arr, long low, long high)
        {
            if (high == low)
                return arr[low];

            long mid = (low + high) / 2;

            long leftSum = FindMaximumSubarray(arr, low, mid);
            long rightSum = FindMaximumSubarray(arr, mid + 1, high);
            long crossSum = FindMaxCrossingSubarray(arr, low, mid, high);

            if (leftSum >= crossSum && leftSum >= rightSum)
                return leftSum;
            else if (rightSum >= leftSum && rightSum >= crossSum)
                return rightSum;
            else
                return crossSum;
        }

        private static long FindMaxCrossingSubarray(long[] arr, long low, long mid, long high)
        {
            long leftSum = 0;
            long sum = 0;
            long maxLeft = 0;

            long i = mid;
            while (i >= 0)
            {
                sum = sum + arr[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
                i--;
            }

            long righttSum = 0;
            sum = 0;
            long maxRight = 0;

            long j = mid + 1;
            while (j <= high)
            {
                sum = sum + arr[j];
                if (sum > righttSum)
                {
                    righttSum = sum;
                    maxRight = j;
                }
                j++;
            }

            return leftSum + righttSum;
        }

        public static long GetTheMedian(this long[] array)
        {
            long median = -1;
            for (long i = 0; i < array.Length; i++)
            {
                int[] p = Partition(array, i);
                if (p[0] == p[1])
                {
                    median = array[i];
                    break;
                }
            }

            return median;
        }

        private static int[] Partition(long[] ar, long index)
        {
            long pivot = ar[index];

            int left = 0;
            int right = 0;
            int eq = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                if (ar[i] == pivot)
                {
                    eq++;
                }
                else if (ar[i] < pivot)
                {
                    left++;
                }
                else
                {
                    right++;
                }
            }

            if (left != right)
            {
                for (int i = 0; i < eq; i++)
                {
                    if (left <= right)
                    {
                        left++;
                    }
                    else
                    {
                        right++;
                    }
                }
            }

            return new int[] { left, right };
        }
    }
}
