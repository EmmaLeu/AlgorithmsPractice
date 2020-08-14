using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsPractice.StacksAndQueues
{
    public class SetOfStacksWithRollover
    {
        private readonly int _threshold;
        private readonly List<StackWithRollover> _stacks = new List<StackWithRollover>();

        public SetOfStacksWithRollover(int threshold)
        {
            _threshold = threshold;
        }

        public int GetStackNumber()
        {
            return _stacks.Count;
        }

        public void Push(int value)
        {
            var stack = GetPushStack();
            stack.Push(value);
        }

        public int Pop()
        {
            var last = GetLastStack();
            var value = last.Pop();
            if(last.IsEmpty())
            {
                _stacks.Remove(last);
            }

            return value;
        }

        /// <summary>
        /// Performs a pop operation on a specific sub-stack
        /// </summary>
        /// <param name="index"></param>
        public int PopAt(int index)
        {
            return LeftShift(index, true);
        }

        private int LeftShift(int index, bool removeTop)
        {
            var stack = _stacks.ElementAt(index);
            var removedItem = 0;
            if(removeTop)
            {
                removedItem = stack.Pop();
            }
            else
            {
                stack.RemoveBottom();
            }

            if(stack.IsEmpty())
            {
                _stacks.Remove(stack);
            }
            else if(_stacks.Count > index + 1)
            {
                var value = LeftShift(index + 1, false);
                stack.Push(value);
            }

            return removedItem;
        }

        private StackWithRollover GetLastStack()
        {
            return _stacks.LastOrDefault();
        }

        private StackWithRollover GetPushStack()
        {
            var last = GetLastStack();
            if (last != null && last.Count < _threshold)
            {
                return last;
            }

            last = new StackWithRollover(_threshold);
            _stacks.Add(last);
            return last;
        }
    }

    public class StackWithRollover
    {
        private readonly int _threshold;

        public StackWithRollover(int threshold)
        {
            _threshold = threshold;
        }

        public Node Top { get; private set; }

        public Node Bottom { get; private set; }

        public int Count { get; private set; }

        public bool IsFull()
        {
            return _threshold == Count;
        }

        public void Join(Node above, Node below)
        {
            if(below != null)
            {
                below.Above = above;
            }
            
            if(above != null)
            {
                above.Below = below;
            }
        }

        public bool Push(int value)
        {
            if(IsFull())
            {
                return false;
            }

            Count++;

            var node = new Node(value);
            if(Count == 1)
            {
                Bottom = node;
            }

            Join(node, Top);
            Top = node;

            return true;
        }

        public int Pop()
        {
            var value = Top.Value;
            Top = Top.Below;
            Count--;
            return value;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int RemoveBottom()
        {
            var value = Bottom.Value;
            Bottom = Bottom.Above;
            if(Bottom != null)
            {
                Bottom.Below = null;
            }

            Count--;
            return value;
        }
    }

    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public Node Above { get; set; }

        public Node Below { get; set; }
    }
}
