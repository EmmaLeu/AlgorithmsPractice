namespace AlgorithmsPractice.TreesAndGraphs
{
    public class BinaryNodeWithParent : BinaryNode
    {
        public BinaryNodeWithParent(int value) : base(value)
        {
        }

        public BinaryNodeWithParent Parent { get; set; }
    }
}
