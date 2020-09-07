namespace AlgorithmsPractice.StacksAndQueues
{
    /// <summary>
    /// Sort stack in ascending order without making assumptions regarding the stack implementation
    /// Use Pop/Push/Peek/IsEmpty
    /// </summary>
    public static class StackSortingService
    {
        public static Stack<int> Sort(Stack<int> stack)
        {
            var helpingStack = new Stack<int>();
            while (!stack.IsEmpty())
            {
                var top = stack.Pop();
                while(!helpingStack.IsEmpty() && helpingStack.Peek() > top)
                {
                    stack.Push(helpingStack.Pop());
                }

                helpingStack.Push(top);
            }

            return helpingStack;
        }
    }
}
