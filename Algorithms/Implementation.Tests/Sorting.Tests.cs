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
            var array = new int [] { 5, 9, 4, 1, 7 };

            // act
            Sorting.InsertionSort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }


        [Fact]
        public void InsertionSortDesc_sorts_unsorted_array_in_decremental_order()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7 };

            // act
             Sorting.InsertionSortDesc(array);

            // assert
            array.Should().BeInDescendingOrder();
        }

        [Fact]
        public void SelectionSort_sorts_unsorted_array()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7 };

            // act
            Sorting.SelectionSort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void HeapSort_sorts_unsorted_array()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7 };

            // act
            Sorting.HeapSort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void HeapSortDesc_sorts_unsorted_array()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7 };

            // act
            Sorting.HeapSortDesc(array);

            // assert
            array.Should().BeInDescendingOrder();
        }

        [Fact]
        public void QuickSort_sorts_unsorted_array()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7 };

            // act
            Sorting.QuickSort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void RandomizeQuickSort_sorts_unsorted_array()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7 };

            // act
            Sorting.RandomizeQuickSort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void MergeSort_sorts_unsorted_array()
        {
            // arrange
            var array = new int[] { 5, 9, 4, 1, 7, 12, 10, 2, 11, 8 };

            // act
            Sorting.MergeSort(array);

            // assert
            array.Should().BeInAscendingOrder();
        }
    }
}
