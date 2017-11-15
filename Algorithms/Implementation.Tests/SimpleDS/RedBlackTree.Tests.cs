using Implementation.SimpleDS;
using Xunit;
using FluentAssertions;

namespace Implementation.Tests.SimpleDS
{
    public class RedBlackTreeTests
    {
        [Fact]
        public void LeftRotate_rotates_tree_into_left_direction()
        {
            // arrange
            var head = new RedBlackNode() { key = 1 };
            head.parent = NilNode.Instance;
            head.left = NilNode.Instance;

            head.right = new RedBlackNode() { key = 5 };
            head.right.parent = head;

            head.right.right = new RedBlackNode() { key = 10 };
            head.right.right.parent = head.right;

            head.right.left = new RedBlackNode() { key = 4 };
            head.right.left.parent = head.right;
            head.right.left.left = NilNode.Instance;
            head.right.left.right = NilNode.Instance;

            head.right.right.right = new RedBlackNode() { key = 12 };
            head.right.right.right.parent = head.right.right;
            head.right.right.right.left = NilNode.Instance;
            head.right.right.right.right = NilNode.Instance;

            head.right.right.left = new RedBlackNode() { key = 8 };
            head.right.right.left.parent = head.right.right;
            head.right.right.left.left = NilNode.Instance;
            head.right.right.left.right = NilNode.Instance;


            // act
            RedBlackTree.LeftRotate(head, head.right);

            // assert
            head.key.Should().Be(1);
            head.right.key.Should().Be(10);
            head.right.left.key.Should().Be(5);
            head.right.left.left.key.Should().Be(4);
            head.right.left.right.key.Should().Be(8);
            head.right.right.key.Should().Be(12);
            head.right.left.right.parent.parent.parent.ShouldBeEquivalentTo(head);
        }

        [Fact]
        public void RightRotate_rotates_tree_into_right_direction()
        {
            // arrange
            var head = new RedBlackNode() { key = 1 };
            head.parent = NilNode.Instance;
            head.left = NilNode.Instance;

            head.right = new RedBlackNode() { key = 10 };
            head.right.parent = head;

            head.right.right = new RedBlackNode() { key = 12 };
            head.right.right.parent = head.right;
            head.right.right.right = NilNode.Instance;
            head.right.right.left = NilNode.Instance;

            head.right.left = new RedBlackNode() { key = 5 };
            head.right.left.parent = head.right;

            head.right.left.left = new RedBlackNode() { key = 4 };
            head.right.left.left.parent = head.right.left;
            head.right.left.left.left = NilNode.Instance;
            head.right.left.left.right = NilNode.Instance;

            head.right.left.right = new RedBlackNode() { key = 8 };
            head.right.left.right.parent = head.right.left;
            head.right.left.right.left = NilNode.Instance;
            head.right.left.right.right = NilNode.Instance;

            // act
            RedBlackTree.RightRotate(head, head.right);


            // assert
            head.key.Should().Be(1);
            head.right.key.Should().Be(5);
            head.right.left.key.Should().Be(4);
            head.right.right.key.Should().Be(10);
            head.right.right.left.key.Should().Be(8);
            head.right.right.right.key.Should().Be(12);
            head.right.right.right.parent.parent.parent.ShouldBeEquivalentTo(head);
        }

        [Fact]
        public void Insert_new_element_into_existing_tree()
        {
            // arrange
            var head = new RedBlackNode() { key = 10 };
            head.parent = NilNode.Instance;

            head.left = new RedBlackNode() { key = 5 };
            head.left.parent = head;
            head.left.left = NilNode.Instance;
            head.left.right = NilNode.Instance;

            head.right = new RedBlackNode() { key = 15 };
            head.right.parent = head;
            head.right.left = NilNode.Instance;
            head.right.right = NilNode.Instance;


            // act
            RedBlackTree.Insert(head, new RedBlackNode() { key = 12 });

            // assert
            head.key.Should().Be(10);
            head.color.Should().Be(Color.Black);

            head.right.key.Should().Be(15);
            head.right.color.Should().Be(Color.Black);

            head.left.key.Should().Be(5);
            head.left.color.Should().Be(Color.Black);

            head.right.left.key.Should().Be(12);
            head.right.left.color.Should().Be(Color.Red);
        }
    }
}
