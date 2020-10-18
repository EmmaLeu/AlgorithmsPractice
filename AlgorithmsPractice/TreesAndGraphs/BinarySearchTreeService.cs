using System.Collections.Generic;

namespace AlgorithmsPractice.TreesAndGraphs
{
    public class BinarySearchTreeService
    {
        private static BinaryNode BuildFromSortedArray(int[] values, int start, int end)
        {
            if(values == null || values.Length == 0 || start > end)
            {
                return null;
            }

            var middle = (start + end) / 2;
            var rootValue = values[middle];
            var root = new BinaryNode(rootValue);
            root.Left = BuildFromSortedArray(values, start, middle - 1);
            root.Right = BuildFromSortedArray(values, middle + 1, end);
            return root;
        }

        /// <summary>
        /// Given a sorted (increasing order) array, 
        /// write an algorithm to create a binary tree with minimal height 
        /// </summary>
        public static BinaryNode BuildMinimalHeightTreeFromSortedArray(int[] values)
        {
            if(values == null || values.Length == 0)
            {
                return null;
            }
            return BuildFromSortedArray(values, 0, values.Length - 1);
        }

        ///<summary>
        ///Given a binary search tree, design an algorithm which creates a linked list of all the nodes at each depth
        ///(eg, if you have a tree with depth D, you’ll have D linked lists)
        ///</summary>
        public static Dictionary<int, LinkedList<int>> GetNodeListsByLevel(BinaryNode node)
        {
            if(node == null)
            {
                return null;
            }

            var nodeListsByLevel = new Dictionary<int, LinkedList<int>>();
            var queue = new Queue<BinaryNode>();

            queue.Enqueue(node);
            queue.Enqueue(null); //level delimiter

            var level = 0;
            nodeListsByLevel[0] = new LinkedList<int>();

            while(queue.Count != 0)
            {
                node = queue.Dequeue();
                if (node == null) //cosumed level, time to upgrade
                {
                    if (queue.Count != 0)
                    {
                        queue.Enqueue(null); //but first, delimit new level
                        nodeListsByLevel[level + 1] = new LinkedList<int>();

                    }

                    level++;             
                }
                else
                {
                    nodeListsByLevel[level].AddLast(node.Value);

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
            }

            return nodeListsByLevel;
        }
    }
}
