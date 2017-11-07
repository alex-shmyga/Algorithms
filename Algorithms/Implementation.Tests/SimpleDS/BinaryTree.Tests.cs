using Implementation.SimpleDS;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace Implementation.Tests.SimpleDS
{
    public class BinaryTreeTests
    {
        [Fact]
        public void InorderTreeWalk_goes_through_tree_in_an_ascending_order()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            head.left.left = new BTNode() { key = 3 };

            var printedValues = new Queue<int>();

            // act
            BinaryTree.InorderTreeWalk(head, (int value) => printedValues.Enqueue(value));


            // assert
            printedValues.Should().BeEquivalentTo(new[] { 3, 4, 5, 7 });
        }

        [Fact]
        public void PreoderTreeWalk_goes_through_tree_starting_from_the_root()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            head.left.left = new BTNode() { key = 3 };

            var printedValues = new Queue<int>();

            // act
            BinaryTree.PreoderTreeWalk(head, (int value) => printedValues.Enqueue(value));


            // assert
            printedValues.Should().BeEquivalentTo(new[] { 5, 4, 7, 3 });
        }

        [Fact]
        public void PostoderTreeWalk_goes_through_tree_in_a_descending_order()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            head.left.left = new BTNode() { key = 3 };

            var printedValues = new Queue<int>();

            // act
            BinaryTree.PostoderTreeWalk(head, (int value) => printedValues.Enqueue(value));


            // assert
            printedValues.Should().BeEquivalentTo(new[] { 7, 5, 4, 3 });
        }

        [Fact]
        public void TreeSearch_returns_asking_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            var node = new BTNode() { key = 7 };
            head.right = node;
            head.left.left = new BTNode() { key = 3 };

            // act
            BTNode result = BinaryTree.Search(head, 7);

            // assert
            result.Should().Be(node);
        }

        [Fact]
        public void TreeSearch_returns_null_when_asking_node_does_not_exist()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            var node = new BTNode() { key = 7 };
            head.right = node;
            head.left.left = new BTNode() { key = 3 };

            // act
            BTNode result = BinaryTree.Search(head, 1);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public void TreeIterativeSearch_returns_asking_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            var node = new BTNode() { key = 7 };
            head.right = node;
            head.left.left = new BTNode() { key = 3 };

            // act
            BTNode result = BinaryTree.IterativeSearch(head, 7);

            // assert
            result.Should().Be(node);
        }

        [Fact]
        public void TreeIterativeSearch_returns_null_when_asking_node_does_not_exist()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            var node = new BTNode() { key = 7 };
            head.right = node;
            head.left.left = new BTNode() { key = 3 };

            // act
            BTNode result = BinaryTree.IterativeSearch(head, 1);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public void Minimum_returns_smallest_key_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            var minMode = new BTNode() { key = 3 };
            head.left.left = minMode;

            // act
            BTNode result = BinaryTree.Minumum(head);

            // assert
            result.Should().Be(minMode);
        }

        [Fact]
        public void Maximum_returns_biggest_key_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            var maxMode = new BTNode() { key = 11 };
            head.right.right = maxMode;

            // act
            BTNode result = BinaryTree.Maximum(head);

            // assert
            result.Should().Be(maxMode);
        }
    }
}
