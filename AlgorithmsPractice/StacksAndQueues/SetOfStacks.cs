using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsPractice.StacksAndQueues
{
    /// <summary>
    /// SetOfStacks should be composed of several stacks, and should create a new stack once the previous one exceeds capacity   
    /// push() and pop() behave identically to a single stack
    /// </summary>
    public class SetOfStacks
    {
        private readonly int _threshold;
        private readonly List<Stack> _stacks = new List<Stack>();

        public SetOfStacks(int threshold)
        {
            _threshold = threshold;
        }

        public void Push(object value)
        {
            var stack = GetPushStack();
            stack.Push(value);
        }

        public object Pop()
        {
            var stack = GetPopStack();
            if(stack == null || stack.Count == 0)
            {
                return null;
            }

            return stack.Pop();
        }

        public int GetStackNumber() => _stacks.Count;

        private Stack GetPushStack()
        {
            var stack = _stacks.LastOrDefault();
            if (stack != null && stack.Count < _threshold)
            {
                return stack;
            }

            stack = new Stack();
            _stacks.Add(stack);
            return stack;
        }

        private Stack GetPopStack()
        {
            var stack = _stacks.LastOrDefault();
            if(stack == null)
            {
                return null;
            }

            if(stack.Count <= 1)
            {
                _stacks.Remove(stack);
            }

            return stack;
        }
    }
}
