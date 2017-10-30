using Implementation.SimpleDS;
using Xunit;
using FluentAssertions;

namespace Implementation.Tests.SimpleDS
{
    public class QueueTests
    {
        [Fact]
        public void Enqueue_should_add_element()
        {
            // arrange
            var queue = new Queue();

            // act
            queue.Enqueue(5);

            // assert
            queue.Count.Should().Be(1);
        }

        [Fact]
        public void Pop_should_return_latest_element()
        {
            // arrange
            var queue = new Queue();
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(3);

            // act
            var result = queue.Dequeue();

            // assert
            result.Should().Be(5);
            queue.Count.Should().Be(2);
        }


        [Fact]
        public void Pop_should_return_latest_element2()
        {
            // arrange
            var queue = new Queue();
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(3);

            // act
            var result = queue.Dequeue();
            result = queue.Dequeue();
            result = queue.Dequeue();

            // assert
            result.Should().Be(3);
            queue.Count.Should().Be(0);
        }
    }
}
