﻿using FluentAssertions;
using Implementation.DynamicProgramming;
using Xunit;

namespace Implementation.Tests.DynamicProgramming
{
    public class SolutionsTests
    {
        [Fact]
        public void Cut_a_rod_find_max_price_for_the_first_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9 };

            // act
            var result = Solutions.CutRod(prices, 1);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void Cut_a_rod_find_max_price_for_the_second_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9 };

            // act
            var result = Solutions.CutRod(prices, 2);

            // assert
            result.Should().Be(5);
        }

        [Fact]
        public void Cut_a_rod_find_max_price_for_the_forth_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9 };

            // act
            var result = Solutions.CutRod(prices, 4);

            // assert
            result.Should().Be(10);
        }

        [Fact]
        public void Cut_a_rod_memo_version_aux_find_max_price_for_the_forth_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.MemoizedCutRod(prices, 9);

            // assert
            result.Should().Be(25);
        }

        [Fact]
        public void Cut_a_rod_memo_version_bottom_up_find_max_price_for_the_forth_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.BottomUpCutRod(prices, 9);

            // assert
            result.Should().Be(25);
        }
    }
}
