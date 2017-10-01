using System;
using FluentAssertions;
using Implementation.KormanExercices;
using Xunit;
using System.Linq;

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
            Solutions.SmartMergeSort(array);

            // assert
            array.Should().BeInAscendingOrder();
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
