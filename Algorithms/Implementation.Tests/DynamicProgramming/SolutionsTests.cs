using FluentAssertions;
using Implementation.DynamicProgramming;
using System.Collections.Generic;
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
        public void Cut_a_rod_memo_version_aux_find_max_price_for_the_asked_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.MemoizedCutRod(prices, 9);

            // assert
            result.Should().Be(25);
        }

        [Fact]
        public void Cut_a_rod_memo_version_bottom_up_find_max_price_for_the_asked_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.BottomUpCutRod(prices, 9);

            // assert
            result.Should().Be(25);
        }

        [Fact]
        public void Cut_a_rod_extended_version_bottom_up_find_max_price_for_the_asked_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            var printedValues = new Queue<int>();

            // act
            Solutions.PrintCutRodSolution(prices, 10, (int value) => printedValues.Enqueue(value));

            // assert
            printedValues.Should().BeEquivalentTo(new[] { 10 });
        }

        [Fact]
        public void Cut_a_rod_extended_version_bottom_up_find_max_price_for_the_asked_element_2()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            var printedValues = new Queue<int>();

            // act
            Solutions.PrintCutRodSolution(prices, 7, (int value) => printedValues.Enqueue(value));

            // assert
            printedValues.Should().BeEquivalentTo(new[] { 1, 6 });
        }

        [Fact]
        public void Fibonacci_numbers_for_zero_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.GetFibonacciNumber(0);

            // assert
            result.Should().Be(0);
        }

        [Fact]
        public void Fibonacci_numbers_for_first_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.GetFibonacciNumber(1);

            // assert
            result.Should().Be(1);
        }

        [Fact]
        public void Fibonacci_numbers_for_fourth_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.GetFibonacciNumber(4);

            // assert
            result.Should().Be(3);
        }

        [Fact]
        public void Fibonacci_numbers_for_twenty_fifth_element()
        {
            // arrange
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            // act
            var result = Solutions.GetFibonacciNumber(25);

            // assert
            result.Should().Be(75025);
        }

        [Fact]
        public void Longest_common_subsequence_problem()
        {
            // arrange
            string x = "ABCBDAB";
            string y = "BDCABA";
            var printedValues = "";

            // act
            Solutions.Print_LCS(x, y, (char value) => printedValues += value);

            // assert
            printedValues.Should().Be("BCBA");
        }
    }
}
