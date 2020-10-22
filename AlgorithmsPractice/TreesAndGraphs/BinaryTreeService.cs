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
    }
}
