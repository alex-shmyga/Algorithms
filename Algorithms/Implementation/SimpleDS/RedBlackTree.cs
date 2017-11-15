﻿using System;

namespace Implementation.SimpleDS
{
    public static class RedBlackTree
    {
        public static void LeftRotate(RedBlackNode head, RedBlackNode x)
        {
            var y = x.right;                // set y
            x.right = y.left;              // set left sub-tree of y to right sub-tree of x

            if (y.left != RedBlackNullNode.Instance)
                y.left.parent = x;

            y.parent = x.parent;            //  mmoving parent from x to y

            if (x.parent == RedBlackNullNode.Instance)
                head = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;

            y.left = x;                     // set x as left child node if y

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

    public sealed class RedBlackNullNode : RedBlackNode
    {
        private static volatile RedBlackNullNode instance;
        private static object syncRoot = new Object();

        private RedBlackNullNode() { }

        public static RedBlackNullNode Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RedBlackNullNode();
                    }
                }

                return instance;
            }
        }
    }
}
