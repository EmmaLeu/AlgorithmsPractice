using System.Collections.Generic;

namespace AlgorithmsPractice.TreesAndGraphs
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public List<Node> Children { get; set; }
    }
}
