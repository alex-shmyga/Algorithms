using Implementation.SimpleDS;
using Xunit;
using FluentAssertions;

namespace Implementation.Tests.SimpleDS
{
    public class StackTests
    {
        [Fact]
        //public void Pop_should_return_latest_element()
        public void Push_should_add_element()
        {
            // arrange
            var stack = new Stack();

            // act
            stack.Push(5);

            // assert
            stack.Count.Should().Be(1);
        }

        [Fact]
        public void Pop_should_return_latest_element()
        {
            // arrange
            var stack = new Stack();
            stack.Push(5);
            stack.Push(7);
            stack.Push(3);

            // act
            var result = stack.Pop();

            // assert
            result.Should().Be(3);
            stack.Count.Should().Be(2);
        }
    }
}
