using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Implementation.Tests
{
    public class SortingTests
    {
        [Fact]
        public void InsertionSort_sorts_unsorted_array()
        {
            // arrange
            var unsortedArray = new int [] { 5, 9, 4, 1, 7 };

            // act
            var sortedArray = Sorting.InsertionSort(unsortedArray);

            // assert
            sortedArray.Should().BeInAscendingOrder();
        }


        [Fact]
        public void InsertionSortDesc_sorts_unsorted_array_in_decremental_order()
        {
            // arrange
            var unsortedArray = new int[] { 5, 9, 4, 1, 7 };

            // act
            var sortedArray = Sorting.InsertionSortDesc(unsortedArray);

            // assert
            sortedArray.Should().BeInDescendingOrder();
        }
    }
}
