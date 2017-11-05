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
    }


    public class BTNode
    {
        public int key;
        public BTNode parent;
        public BTNode left;
        public BTNode right;
    }
}
