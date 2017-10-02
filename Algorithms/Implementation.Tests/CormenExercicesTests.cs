using System;
using FluentAssertions;
using Implementation.KormanExercices;
using Xunit;
using System.Linq;
using Implementation.CormenExercices;

namespace Implementation.Tests
{
    public class CormenExercicesTests
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
    }
}
