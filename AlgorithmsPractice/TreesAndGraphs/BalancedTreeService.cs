using System;

namespace AlgorithmsPractice.TreesAndGraphs
{
    /// <summary>
    /// Implement a function to check if a tree is balanced   
    /// For the purposes of this question, a balanced tree is defined to be a tree such that 
    /// no two leaf nodes differ in distance from the root by more than one 
    /// </summary>
    public class BalancedTreeService
    {
        public bool IsBalanced(BinaryNode root)
        {
            if (root == null)
            {
                return true;
            }

            return (MaxDepth(root) - MinDepth(root) <= 1);
        }

        public int MaxDepth(BinaryNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(MaxDepth(node.Left), MaxDepth(node.Right));
        }

        public int MinDepth(BinaryNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Min(MinDepth(node.Left), MinDepth(node.Right));
        }
    }
}
