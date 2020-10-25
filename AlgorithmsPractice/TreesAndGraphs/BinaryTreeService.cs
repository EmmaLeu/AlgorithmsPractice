using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsPractice.TreesAndGraphs
{
    public class BinaryTreeService
    {
        public static BinaryNodeWithParent FindFirstCommonAncestor(BinaryNodeWithParent node1, BinaryNodeWithParent node2)
        {
            if (node1 == null || node2 == null)
            {
                return null;
            }

            while(node1 != null)
            {
                var tempNode = node2;
                while (tempNode != null)
                {
                    if (node1 == tempNode)
                    {
                        return node1;
                    }

                    tempNode = tempNode.Parent;
                }

                node1 = node1.Parent;
            }

            return null;
        }

        public static BinaryNode FindFirstCommonAncestor(BinaryNode root, BinaryNode node1, BinaryNode node2)
        {
            if(node1 == node2 && (root.Left == node1 || root.Right == node2))
            {
                return root;
            }

            var leftNodes = GetContainedNodes(root.Left, node1, node2);

            if(leftNodes == 2)
            {
                if(root.Left == node1 || root.Left == node2)
                {
                    return root.Left;
                }
                else
                {
                    return FindFirstCommonAncestor(root.Left, node1, node2);
                }
            }
            else if (leftNodes == 1)
            {
                if(root == node1)
                {
                    return node1;  
                }
                else if(root == node2)
                {
                    return node2;
                }
            }

            var rightNodes = GetContainedNodes(root.Right, node1, node2);

            if (rightNodes == 2)
            {
                if (root.Right == node1 || root.Right == node2)
                {
                    return root.Right;
                }
                else
                {
                    return FindFirstCommonAncestor(root.Right, node1, node2);
                }
            }
            else if (rightNodes == 1)
            {
                if (root == node1)
                {
                    return node1;
                }
                else if (root == node2)
                {
                    return node2;
                }
            }

            if(leftNodes == 1 && rightNodes == 1)
            {
                return root;
            }
            else
            {
                return null;
            }
        }

        public static bool IsSubtreeOf(BinaryNode t1, BinaryNode t2)
        {
            var inorderT2 = new StringBuilder();
            InOrder(t2, inorderT2);

            var inorderT1 = new StringBuilder();
            InOrder(t1, inorderT1);

            if (!inorderT1.ToString().Contains(inorderT2.ToString()))
            {
                return false;
            }

            var preorderT2 = new StringBuilder();
            InOrder(t2, preorderT2);

            var preorderT1 = new StringBuilder();
            InOrder(t1, preorderT1);

            if (!preorderT1.ToString().Contains(preorderT2.ToString()))
            {
                return false;
            }

            return true;
        }

        public static List<List<int>> GetSumPaths(BinaryNode node, int sum)
        {
            var paths = new List<List<int>>();
            FindSum(node, sum, new List<int>(), 0, paths);
            return paths;
        }

        private static void FindSum(BinaryNode node, int sum, List<int> buffer, int level, List<List<int>> paths)
        {
            if(node == null)
            {
                return;
            }

            var temporarySum = sum;
            buffer.Add(node.Value);

            for (var index = level; index > -1; index--)
            {
                temporarySum -= buffer[index];
                if(temporarySum == 0)
                {
                    paths.Add(GetPath(buffer, index, level));
                }
            }

            FindSum(node.Left, sum, buffer.ToList(), level + 1, paths);
            FindSum(node.Right, sum, buffer.ToList(), level + 1, paths);
        }

        private static List<int> GetPath(List<int> buffer, int startIndex, int endIndex)
        {
            var path = new List<int>();
            for(var index = startIndex; index <= endIndex; index++)
            {
                path.Add(buffer[index]);
            }

            return path;
        }

        private static int GetContainedNodes(BinaryNode root, BinaryNode node1, BinaryNode node2)
        {
            int foundNodes = 0;

            if(root == null)
            {
                return foundNodes;
            }

            if(root == node1 || root == node2)
            {
                foundNodes++;
            }

            foundNodes += GetContainedNodes(root.Left, node1, node2);

            if(foundNodes == 2)
            {
                return foundNodes;
            }

            return foundNodes + GetContainedNodes(root.Right, node1, node2);
        }

        public static void InOrder(BinaryNode root, StringBuilder traversal)
        {
            if (root == null)
            {
                return;
            }

            if (root.Left != null)
            {
                InOrder(root.Left, traversal);
            }

            traversal.Append(root.Value);

            if (root.Right != null)
            {
                InOrder(root.Right, traversal);
            }
        }

        public static void PreOrder(BinaryNode root, StringBuilder traversal)
        {
            if (root == null)
            {
                return;
            }

            traversal.Append(root.Value);

            if (root.Left != null)
            {
                InOrder(root.Left, traversal);
            }

            if (root.Right != null)
            {
                InOrder(root.Right, traversal);
            }
        }
    }
}
