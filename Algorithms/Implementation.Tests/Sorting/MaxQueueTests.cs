using FluentAssertions;
using Implementation.CormenExercices;
using System.Collections.Generic;
using Xunit;

namespace Implementation.Tests
{
    public class MaxQueueTests
    {
        [Fact]                   
        public void Should_return_max_element()
        {
            // arrange
            var array = new List<int> { 2, 3, 5, 4, 1 };
            var priorityQueue = new MaxPriorityQueue();
            array.ForEach(e => priorityQueue.Insert(e));

            // act 
            int max = priorityQueue.GetMax();

            // assert
            max.Should().Be(5);
        }

        [Fact]
        public void Should_extract_max_element()
        {
            // arrange
            var array = new List<int> { 2, 3, 5, 4, 1 };
            var priorityQueue = new MaxPriorityQueue();
            array.ForEach(e => priorityQueue.Insert(e));

            // act 
            int max = priorityQueue.ExtractMax();
            int nextMax = priorityQueue.GetMax();

            // assert
            nextMax.Should().Be(4);
        }
    }
}
