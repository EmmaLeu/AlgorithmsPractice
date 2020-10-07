using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsPractice.TreesAndGraphs
{
    public class BinaryNode
    {
        public BinaryNode(int value)
        {
            Value = value;
        }

        public BinaryNode Left { get; set; }

        public BinaryNode Right { get; set; }

        public int Value { get; private set; }
    }
}
