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

        public static void InorderTreeWalk2(BTNode head, Action<int> func)
        {
            BTNode node = Minimum(head);
            func(node.key);

            node = Successor(node);
            while (node != null)
            {
                func(node.key);
                node = Successor(node);
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

        public static void PostoderTreeWalk2(BTNode head, Action<int> func)
        {
            BTNode node = Maximum(head);
            func(node.key);

            node = Predecessor(node);
            while (node != null)
            {
                func(node.key);
                node = Predecessor(node);
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

        public static void Insert(BTNode head, BTNode newNode)
        {
            BTNode y = null;
            BTNode x = head;

            while (x != null)
            {
                y = x;
                if (newNode.key < x.key)
                    x = x.left;
                else
                    x = x.right;
            }

            newNode.parent = y;

            if (y == null)
                head = newNode;
            else if (newNode.key < y.key)
                y.left = newNode;
            else
                y.right = newNode;
        }

        public static BTNode RecursiveInsert(BTNode head, BTNode newNode)
        {
            if (head == null)
            {
                return newNode;
            }

            if (newNode.key < head.key)
            {
                head.left = RecursiveInsert(head.left, newNode);
            }
            else
            {
                head.right = RecursiveInsert(head.right, newNode);
            }

            return head;
        }

        public static void Delete(BTNode head, BTNode nodeToDelete)
        {
            if (nodeToDelete.left == null)
                Transplant(head, nodeToDelete, nodeToDelete.right);
            else if (nodeToDelete.right == null)
                Transplant(head, nodeToDelete, nodeToDelete.left);
            else
            {
                BTNode y = Minimum(nodeToDelete.right);
                if (y.parent != nodeToDelete)
                {
                    Transplant(head, y, y.right);
                    y.right = nodeToDelete.right;
                    y.right.parent = y;
                }

                Transplant(head, nodeToDelete, y);
                y.left = nodeToDelete.left;
                y.left.parent = y;
            }
        }

        private static void Transplant(BTNode head, BTNode u, BTNode v)
        {
            if (u.parent == null)
                head = v;
            else if (u == u.parent.left)
                u.parent.left = v;
            else
                u.parent.right = v;

            if (v != null)
                v.parent = u.parent;
        }

        public static void Delete2(BTNode head, BTNode nodeToDelete)
        {
            if (nodeToDelete.left == null)
                Transplant(head, nodeToDelete, nodeToDelete.right);
            else if (nodeToDelete.right == null)
                Transplant(head, nodeToDelete, nodeToDelete.left);
            else
            {
                BTNode y = Maximum(nodeToDelete.left);
                if (y.parent != nodeToDelete)
                {
                    Transplant(head, y, y.left);
                    y.left = nodeToDelete.left;
                    y.left.parent = y;
                }

                Transplant(head, nodeToDelete, y);
                y.right = nodeToDelete.right;
                y.right.parent = y;
            }
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
