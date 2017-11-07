﻿using System;

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
    }


    public class BTNode
    {
        public int key;
        public BTNode parent;
        public BTNode left;
        public BTNode right;
    }
}