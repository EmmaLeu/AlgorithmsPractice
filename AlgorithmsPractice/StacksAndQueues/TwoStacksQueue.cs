namespace AlgorithmsPractice.StacksAndQueues
{
    public class TwoStacksQueue
    {
        private readonly Stack<int> _enqueueStack = new Stack<int>();
        private readonly Stack<int> _dequeueStack = new Stack<int>();

        public void Enqueue(int value)
        {
            _enqueueStack.Push(value);
        }

        public int Dequeue() //O(n), n - number of elements
        {
            MoveElements(_enqueueStack, _dequeueStack);
            var value = _dequeueStack.Pop();
            MoveElements(_dequeueStack, _enqueueStack);
            return value;
        }

        private void MoveElements(Stack<int> _stack1, Stack<int> _stack2)
        {
            while (!_stack1.IsEmpty())
            {
                var element = _stack1.Pop();
                _stack2.Push(element);
            }
        }
    }
}
