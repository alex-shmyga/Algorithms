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
