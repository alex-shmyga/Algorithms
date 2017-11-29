using FluentAssertions;
using Implementation.DynamicProgramming.Exercices;
using Xunit;

namespace Implementation.Tests.DynamicProgramming
{
    public class ExercicesTests
    {
        [Fact]
        public void TheCoinChangeProblem_test()
        {
            // arrange
            long[] c = new long[] { 1, 2, 3 };

            // act
            long result = TheCoinChangeProblem.GetWays(4, c);

            // assert
            result.Should().Be(4);
        }

        [Fact]
        public void TheCoinChangeProblem_test_2()
        {
            // arrange
            long[] c = new long[] { 2, 5, 3, 6 };

            // act
            long result = TheCoinChangeProblem.GetWays(10, c);

            // assert
            result.Should().Be(5);
        }
    }
}
