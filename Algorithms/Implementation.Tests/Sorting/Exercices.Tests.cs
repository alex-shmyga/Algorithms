using System;
using FluentAssertions;
using Implementation.KormanExercices;
using Xunit;
using System.Linq;
using Implementation.CormenExercices;

namespace Implementation.Tests
{
    public class ExercicesTests
    {
        [Fact]
        public void SmartMergeSort_sorts_unsorted_array()
        {
            // arrange
            var array = GetRandomIntArray(100000);

            // act
            SmartMergeSort.Sort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }


        [Fact]
        public void CountInversions_returns_zero_for_sorted_array()
        {
            // arrange
            var array = new int[] {1, 1, 1, 2, 2 };

            // act
            var count = InversionCounter.GetCount(array);

            // assert
            count.Should().Be(0);
        }

        [Fact]
        public void CountInversions_calculate_invariants_for_unsorted_array()
        {
            // arrange
            var array = new int[] { 2, 1, 3, 1, 2 };

            // act
            var count = InversionCounter.GetCount(array);

            // assert
            count.Should().Be(4);
        }

        [Fact]
        public void MaxSubarrSum_from_real_int_array()
        {
            // arrange
            var array = new long[] { 3, 3, 9, 9, 5 };

            // act 
            var sum = ArrayExtensions.GetMaxSubarrSum(array);

            // assert
            sum.Should().Be(29);
        }

        [Fact]
        public void MaxSubarrSum_from_int_array()
        {
            // arrange
            var array = new long[] { -2, -3, 4, -1, -2, 1, 5, -3 };

            // act 
            var sum = ArrayExtensions.GetMaxSubarrSum(array);

            // assert
            sum.Should().Be(7);
        }

        private int[] GetRandomIntArray(int size)
        {
            int Min = Int32.MinValue;
            int Max = Int32.MaxValue;
            var randNum = new Random();
            int[] arr = Enumerable
                .Repeat(0, size)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();

            return arr;
        }

        /// <summary>
        /// hackerrank problem: https://www.hackerrank.com/challenges/find-the-median/problem
        /// </summary>
        [Fact]
        public void FindTheMedian()
        {
            // arrange
            var array = new long[] { 0, 1, 2, 4, 6, 5, 3 };

            // act 
            var median = array.GetTheMedian();

            // assert
            median.Should().Be(3);
        }
    }
}
