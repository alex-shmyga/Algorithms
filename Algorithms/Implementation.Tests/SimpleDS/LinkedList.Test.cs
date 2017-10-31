using Implementation.SimpleDS;
using Xunit;
using FluentAssertions;

namespace Implementation.Tests.SimpleDS
{
    public class LinkedListTests
    {
        [Fact]
        public void Insert_should_add_element()
        {
            // arrange
            var list = new LinkedList();

            // act
            list.Insert(5);

            // assert
            list.Count.Should().Be(1);
        }

        [Fact]
        public void Insert_should_add_element2()
        {
            // arrange
            var list = new LinkedList();

            // act
            list.Insert(5);
            list.Insert(7);
            list.Insert(10);

            // assert
            list.Count.Should().Be(3);
        }

        [Fact]
        public void Search_should_return_asking_node()
        {
            // arrange
            var list = new LinkedList();
            list.Insert(5);
            list.Insert(7);
            list.Insert(10);

            // act
            var result = list.Search(7);

            // assert
            result.key.Should().Be(7);
        }

        [Fact]
        public void Delete_should_remove_asking_node()
        {
            // arrange
            var list = new LinkedList();
            list.Insert(5);
            list.Insert(7);
            list.Insert(10);

            // act
            list.Remove(7);
            var result = list.Search(7);

            // assert
            result.Should().BeNull();
            list.Count.Should().Be(2);
        }
    }
}
