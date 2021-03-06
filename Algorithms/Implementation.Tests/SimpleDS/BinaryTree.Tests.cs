﻿using Implementation.SimpleDS;
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
            BTNode result = BinaryTree.Minimum(head);

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

        [Fact]
        public void Successor_returns_next_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };

            head.left = new BTNode() { key = 4 };
            head.left.parent = head;

            var successorNode = new BTNode() { key = 7 };
            head.right = successorNode;
            successorNode.parent = head;

            head.right.right = new BTNode() { key = 11 };
            head.right.right.parent = head.right;


            // act
            BTNode result = BinaryTree.Successor(head);

            // assert
            result.Should().Be(successorNode);
        }

        [Fact]
        public void Predecessor_returns_previous_node()
        {
            // arrange
            var head = new BTNode() { key = 7 };

            head.left = new BTNode() { key = 5 };
            head.left.parent = head;

            head.left.left = new BTNode() { key = 4 };
            head.left.left.parent = head.left;

            head.left.right = new BTNode() { key = 6 };
            head.left.right.parent = head.left;

            head.right = new BTNode() { key = 9 }; ;
            head.right.parent = head;

            head.right.right = new BTNode() { key = 11 };
            head.right.right.parent = head.right;


            // act
            BTNode result = BinaryTree.Predecessor(head.right);

            // assert
            result.Should().Be(head);
        }

        [Fact]
        public void IterativeMinimum_returns_smallest_key_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            var minMode = new BTNode() { key = 3 };
            head.left.left = minMode;

            // act
            BTNode result = BinaryTree.IterativeMinimum(head);

            // assert
            result.Should().Be(minMode);
        }

        [Fact]
        public void IterativeMaximum_returns_biggest_key_node()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            head.left = new BTNode() { key = 4 };
            head.right = new BTNode() { key = 7 };
            var maxMode = new BTNode() { key = 11 };
            head.right.right = maxMode;

            // act
            BTNode result = BinaryTree.IterativeMaximum(head);

            // assert
            result.Should().Be(maxMode);
        }

        [Fact]
        public void InorderTreeWalk2_goes_through_tree_in_an_ascending_order()
        {
            // arrange
            var head = new BTNode() { key = 5 };

            head.left = new BTNode() { key = 4 };
            head.left.parent = head;

            head.right = new BTNode() { key = 7 };
            head.right.parent = head;

            head.left.left = new BTNode() { key = 3 };
            head.left.left.parent = head.left;

            var printedValues = new Queue<int>();


            // act
            BinaryTree.InorderTreeWalk2(head, (int value) => printedValues.Enqueue(value));


            // assert
            printedValues.Should().BeEquivalentTo(new[] { 3, 4, 5, 7 });
        }

        [Fact]
        public void PostoderTreeWalk2_goes_through_tree_in_a_descending_order()
        {
            // arrange
            var head = new BTNode() { key = 5 };

            head.left = new BTNode() { key = 4 };
            head.left.parent = head;

            head.right = new BTNode() { key = 7 };
            head.right.parent = head;

            head.left.left = new BTNode() { key = 3 };
            head.left.left.parent = head.left;

            var printedValues = new Queue<int>();


            // act
            BinaryTree.PostoderTreeWalk2(head, (int value) => printedValues.Enqueue(value));


            // assert
            printedValues.Should().BeEquivalentTo(new[] { 7, 5, 4, 3 });
        }

        [Fact]
        public void Insert_should_add_new_element_in_a_preper_place()
        {
            // arrange
            var head = new BTNode() { key = 7 };

            // act
            BinaryTree.Insert(head, new BTNode() { key = 10 });
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 6 });
            BinaryTree.Insert(head, new BTNode() { key = 5 });
            BinaryTree.Insert(head, new BTNode() { key = 8 });
            BinaryTree.Insert(head, new BTNode() { key = 14 });
            BinaryTree.Insert(head, new BTNode() { key = 12 });
            BinaryTree.Insert(head, new BTNode() { key = 9 });

            // assert
            head.right.key.Should().Be(10);
            head.left.key.Should().Be(3);
            head.left.right.key.Should().Be(6);
            head.left.right.left.key.Should().Be(5);
            head.right.left.key.Should().Be(8);
            head.right.right.key.Should().Be(14);
            head.right.right.left.key.Should().Be(12);
            head.right.left.right.key.Should().Be(9);
        }

        [Fact]
        public void Delete_node_with_only_left_child_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 1 });

            // act
            BinaryTree.Delete(head, head.left);

            // assert
            head.key.Should().Be(5);
            head.left.key.Should().Be(1);
            head.left.left.Should().BeNull();
            head.left.right.Should().BeNull();
        }

        [Fact]
        public void Delete_node_with_only_right_child_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 4 });

            // act
            BinaryTree.Delete(head, head.left);

            // assert
            head.key.Should().Be(5);
            head.left.key.Should().Be(4);
            head.left.left.Should().BeNull();
            head.left.right.Should().BeNull();
        }

        [Fact]
        public void Delete_node_with_right_and_left_child_elements_without_children_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 1 });
            BinaryTree.Insert(head, new BTNode() { key = 4 });

            // act
            BinaryTree.Delete(head, head.left);

            // assert
            head.key.Should().Be(5);
            head.left.key.Should().Be(4);
            head.left.left.key.Should().Be(1);
            head.left.right.Should().BeNull();
        }

        [Fact]
        public void Delete_node_with_right_and_left_child_elements_and_right_child_has_right_child_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 20 };
            BinaryTree.Insert(head, new BTNode() { key = 10 });
            BinaryTree.Insert(head, new BTNode() { key = 15 });
            BinaryTree.Insert(head, new BTNode() { key = 5 });
            BinaryTree.Insert(head, new BTNode() { key = 12 });
            BinaryTree.Insert(head, new BTNode() { key = 17 });

            // act
            BinaryTree.Delete(head, head.left);

            // assert
            head.key.Should().Be(20);
            head.left.key.Should().Be(12);
            head.left.left.key.Should().Be(5);
            head.left.right.key.Should().Be(15);
            head.left.right.right.key.Should().Be(17);
        }

        [Fact]
        public void Delete_node_with_right_and_left_child_elements_and_right_child_has_right_child_should_replace_parent2()
        {
            // arrange
            var head = new BTNode() { key = 20 };
            BinaryTree.Insert(head, new BTNode() { key = 10 });
            BinaryTree.Insert(head, new BTNode() { key = 15 });
            BinaryTree.Insert(head, new BTNode() { key = 5 });
            BinaryTree.Insert(head, new BTNode() { key = 17 });

            // act
            BinaryTree.Delete(head, head.left);

            // assert
            head.key.Should().Be(20);
            head.left.key.Should().Be(15);
            head.left.left.key.Should().Be(5);
            head.left.right.key.Should().Be(17);
        }

        [Fact]
        public void RecursiveInsert_should_add_new_element_in_a_preper_place()
        {
            // arrange
            var head = new BTNode() { key = 7 };

            // act
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 10 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 3 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 6 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 5 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 8 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 14 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 12 });
            BinaryTree.RecursiveInsert(head, new BTNode() { key = 9 });

            // assert
            head.right.key.Should().Be(10);
            head.left.key.Should().Be(3);
            head.left.right.key.Should().Be(6);
            head.left.right.left.key.Should().Be(5);
            head.right.left.key.Should().Be(8);
            head.right.right.key.Should().Be(14);
            head.right.right.left.key.Should().Be(12);
            head.right.left.right.key.Should().Be(9);
        }

        [Fact]
        public void Delete2_node_with_only_left_child_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 1 });

            // act
            BinaryTree.Delete2(head, head.left);

            // assert
            head.key.Should().Be(5);
            head.left.key.Should().Be(1);
            head.left.left.Should().BeNull();
            head.left.right.Should().BeNull();
        }

        [Fact]
        public void Delete2_node_with_only_right_child_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 4 });

            // act
            BinaryTree.Delete2(head, head.left);

            // assert
            head.key.Should().Be(5);
            head.left.key.Should().Be(4);
            head.left.left.Should().BeNull();
            head.left.right.Should().BeNull();
        }

        [Fact]
        public void Delete2_node_with_right_and_left_child_elements_without_children_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 5 };
            BinaryTree.Insert(head, new BTNode() { key = 3 });
            BinaryTree.Insert(head, new BTNode() { key = 1 });
            BinaryTree.Insert(head, new BTNode() { key = 4 });

            // act
            BinaryTree.Delete2(head, head.left);

            // assert
            head.key.Should().Be(5);
            head.left.key.Should().Be(1);
            head.left.right.key.Should().Be(4);
            head.left.left.Should().BeNull();
        }

        [Fact]
        public void Delete2_node_with_right_and_left_child_elements_and_right_child_has_right_child_should_replace_parent()
        {
            // arrange
            var head = new BTNode() { key = 20 };
            BinaryTree.Insert(head, new BTNode() { key = 15 });
            BinaryTree.Insert(head, new BTNode() { key = 17 });
            BinaryTree.Insert(head, new BTNode() { key = 5 });
            BinaryTree.Insert(head, new BTNode() { key = 10 });
            BinaryTree.Insert(head, new BTNode() { key = 7 });
            BinaryTree.Insert(head, new BTNode() { key = 3 });

            // act
            BinaryTree.Delete2(head, head.left);

            // assert
            head.key.Should().Be(20);
            head.left.key.Should().Be(10);
            head.left.left.key.Should().Be(5);
            head.left.left.left.key.Should().Be(3);
            head.left.right.key.Should().Be(17);
            head.left.left.right.key.Should().Be(7);
        }

        [Fact]
        public void Delete2_node_with_right_and_left_child_elements_and_right_child_has_right_child_should_replace_parent2()
        {
            // arrange
            var head = new BTNode() { key = 20 };
            BinaryTree.Insert(head, new BTNode() { key = 15 });
            BinaryTree.Insert(head, new BTNode() { key = 17 });
            BinaryTree.Insert(head, new BTNode() { key = 5 });
            BinaryTree.Insert(head, new BTNode() { key = 3 });

            // act
            BinaryTree.Delete2(head, head.left);

            // assert
            head.key.Should().Be(20);
            head.left.key.Should().Be(5);
            head.left.left.key.Should().Be(3);
            head.left.right.key.Should().Be(17);
        }

        [Fact]
        public void Delete3_deletes_proper_nodes()
        {
            // arrange
            var head = new BTNode() { key = 20 };
            BinaryTree.Insert(head, new BTNode() { key = 10 });
            BinaryTree.Insert(head, new BTNode() { key = 15 });
            var nodeToDelete1 = new BTNode() { key = 5 };
            BinaryTree.Insert(head, nodeToDelete1);
            BinaryTree.Insert(head, new BTNode() { key = 4 });  
            BinaryTree.Insert(head, new BTNode() { key = 89 });
            var nodeToDelete2 = new BTNode() { key = 41 };
            BinaryTree.Insert(head, nodeToDelete2);
            var nodeToDelete3 = new BTNode() { key = 44 };
            BinaryTree.Insert(head, nodeToDelete3);
            BinaryTree.Insert(head, new BTNode() { key = 411 });
            var nodeToDelete4 = new BTNode() { key = 99 };
            BinaryTree.Insert(head, nodeToDelete4);
            BinaryTree.Insert(head, new BTNode() { key = 7 });

            var printedValues = new Queue<int>();

            // act
            BinaryTree.Delete3(head, nodeToDelete1);
            BinaryTree.Delete3(head, nodeToDelete2);
            BinaryTree.Delete3(head, nodeToDelete3);
            BinaryTree.Delete3(head, nodeToDelete4);
            BinaryTree.InorderTreeWalk(head, (int value) => printedValues.Enqueue(value));

            // assert
            printedValues.Should().BeEquivalentTo(new[] {4, 7, 10, 15, 20, 89, 411 });
        }
    }
}
