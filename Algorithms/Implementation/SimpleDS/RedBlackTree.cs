using System;

namespace Implementation.SimpleDS
{
    public static class RedBlackTree
    {
        public static void LeftRotate(RedBlackNode head, RedBlackNode x)
        {
            var y = x.right;                // set y
            x.right = y.left;              // set left sub-tree of y to right sub-tree of x

            if (y.left != NilNode.Instance)
                y.left.parent = x;

            y.parent = x.parent;            //  moving parent from x to y

            if (x.parent == NilNode.Instance)
                head = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;

            y.left = x;                     // set x as left child node if y

            x.parent = y;
        }

        public static void RightRotate(RedBlackNode head, RedBlackNode x)
        {
            var y = x.left;                // set y
            x.left = y.right;              // set right sub-tree of y to left sub-tree of x

            if (y.right != NilNode.Instance)
                y.right.parent = x;

            y.parent = x.parent;            //  moving parent from x to y

            if (x.parent == NilNode.Instance)
                head = y;
            else if (x == x.parent.right)
                x.parent.right = y;
            else
                x.parent.left = y;

            y.right = x;                     // set x as right child node if y

            x.parent = y;
        }

        public static void Insert(RedBlackNode head, RedBlackNode z)
        {
            RedBlackNode y = NilNode.Instance;
            RedBlackNode x = head;

            while (x != NilNode.Instance)
            {
                y = x;
                if (z.key < x.key)
                    x = x.left;
                else
                    x = x.right;
            }

            z.parent = y;
            if (y == NilNode.Instance)
                head = z;
            else if (z.key < y.key)
                y.left = z;
            else
                y.right = z;

            z.left = NilNode.Instance;
            z.right = NilNode.Instance;
            z.color = Color.Red;
            InsertFixup(head, z);
        }

        private static void InsertFixup(RedBlackNode head, RedBlackNode z)
        {
            while (z.parent.color == Color.Red)
            {
                if (z.parent == z.parent.parent.left)
                {
                    RedBlackNode y = z.parent.parent.right;
                    if (y.color == Color.Red)
                    {
                        z.parent.color = Color.Black;
                        y.color = Color.Black;
                        z.parent.parent.color = Color.Red;
                        z = z.parent.parent;
                    }
                    else
                    {
                        if (z == z.parent.right)
                        {
                            z = z.parent;
                            LeftRotate(head, z);
                        }
                        z.parent.color = Color.Black;
                        z.parent.parent.color = Color.Red;
                        RightRotate(head, z.parent.parent);
                    }
                }
                else
                {
                    RedBlackNode y = z.parent.parent.left;
                    if (y.color == Color.Black)
                    {
                        z.parent.color = Color.Red;
                        y.color = Color.Red;
                        z.parent.parent.color = Color.Black;
                        z = z.parent.parent;
                    }
                    else
                    {
                        if (z == z.parent.left)
                        {
                            z = z.parent;
                            RightRotate(head, z);
                        }
                        z.parent.color = Color.Black;
                        z.parent.parent.color = Color.Red;
                        LeftRotate(head, z.parent.parent);
                    }
                }
            }

            var root = head;
            while (root.parent != NilNode.Instance)
                root = root.parent;

            root.color = Color.Black;
        }
    }

    public class RedBlackNode
    {
        public Color color;
        public int key;
        public RedBlackNode parent;
        public RedBlackNode left;
        public RedBlackNode right;
    }

    public enum Color
    {
        Black,
        Red
    }

    public sealed class NilNode
    {
        private static volatile RedBlackNode instance;
        private static object syncRoot = new Object();

        private NilNode() { }

        public static RedBlackNode Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RedBlackNode();
                    }
                }

                return instance;
            }
        }
    }
}
