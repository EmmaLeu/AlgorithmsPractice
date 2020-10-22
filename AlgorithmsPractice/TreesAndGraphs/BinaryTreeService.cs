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
    }
}
