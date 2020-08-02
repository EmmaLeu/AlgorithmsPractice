using System;
using System.Collections;

namespace AlgorithmsPractice.StacksAndQueues
{
    public class StackWithMin : Stack
    {
        public void Push(int value) 
        { 
            int newMin = Math.Min(value, Min()); 
            Push(new NodeWithMin(value, newMin));
        }

        public int Min() 
        {
            if (Count == 0) 
            {
                return int.MaxValue;
            } 

            return (Peek() as NodeWithMin).Min;
        }
    }

    /// <summary>
    /// Node holding current min information
    /// </summary>
    public class NodeWithMin
    {
        public int Min;
        public int Value;

        public NodeWithMin(int value, int min)
        {
            Value = value;
            Min = min;
        }
    }
}

