using System;

namespace Implementation.SimpleDS
{
    public static class BinaryTree
    {
        public static void InorderTreeWalk(this BTNode node, Action<int> func)
        {
            if (node != null)
            {
                InorderTreeWalk(node.left, func);
                func(node.key);
                InorderTreeWalk(node.right, func);
            }
        }

        public static void PreoderTreeWalk(this BTNode node, Action<int> func)
        {
            if (node != null)
            {
                func(node.key);
                PreoderTreeWalk(node.left, func);
                PreoderTreeWalk(node.right, func);
            }
        }

        public static void PostoderTreeWalk(this BTNode node, Action<int> func)
        {
            if (node != null)
            {
                PostoderTreeWalk(node.left, func);
                PostoderTreeWalk(node.right, func);
                func(node.key);
            }
        }

        public static BTNode Search(BTNode head, int k)
        {
            if (head == null || head.key == k)
                return head;

            if (k < head.key)
                return Search(head.left, k);
            else
                return Search(head.right, k);
        }

        public static BTNode IterativeSearch(BTNode head, int k)
        {
            while (head != null && k != head.key)
                if (k < head.key)
                    head = head.left;
                else
                    head = head.right;

            return head;
        }

        public static BTNode Minimum(BTNode head)
        {
            while (head.left != null)
                head = head.left;

            return head;
        }

        public static BTNode IterativeMinimum(BTNode head)
        {
            if (head.left != null)
                return IterativeMinimum(head.left);

            return head;
        }

        public static BTNode Maximum(BTNode head)
        {
            while (head.right != null)
                head = head.right;

            return head;
        }

        public static BTNode IterativeMaximum(BTNode head)
        {
            if (head.right != null)
                return IterativeMaximum(head.right);

            return head;
        }

        public static BTNode Successor(BTNode head)
        {
            if (head.right != null)
                return Minimum(head.right);

            var node = head.parent;
            while (node != null && head == node.right)
            {
                head = node;
                node = head.parent;
            }

            return node;
        }


        public static BTNode Predecessor(BTNode head)
        {
            if (head.left != null)
                return Maximum(head.left);

            var node = head.parent;
            while (node != null && head == node.left)
            {
                head = node;
                node = head.parent;
            }

            return node;
        }
    }


    public class BTNode
    {
        public int key;
        public BTNode parent;
        public BTNode left;
        public BTNode right;
    }
}
