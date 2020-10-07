namespace AlgorithmsPractice.TreesAndGraphs
{
    public class Tree
    {
        public Node Root { get; set; }

        public Node Build(int[] preorderValues)
        {
            var root = preorderValues[0];
            return new Node(root);
        }
    }
}
