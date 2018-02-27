namespace Implementation.SimpleDS.Exercices
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/is-binary-search-tree/problem
    /// </summary>
    class IsBinarySearchTree
    {
        bool checkBST(Node root)
        {
            return checkNode(root, int.MinValue, int.MaxValue);
        }

        private bool checkNode(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.data <= min || root.data >= max)
                return false;

            return checkNode(root.left, min, root.data)
                   && checkNode(root.right, root.data, max);

        }

        class Node
        {
            internal int data;
            internal Node left;
            internal Node right;
        }
    }
}
