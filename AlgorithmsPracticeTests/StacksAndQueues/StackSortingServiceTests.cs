using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class StackSortingServiceTests
    {
        [Test]
        public void Sort_Test()
        {
            var stack = new AlgorithmsPractice.StacksAndQueues.Stack<int>();
            stack.Push(1);
            stack.Push(5);
            stack.Push(2);
            stack.Push(4);
            stack.Push(3);

            var result = StackSortingService.Sort(stack);

            Assert.AreEqual(5, result.Pop());
            Assert.AreEqual(4, result.Pop());
            Assert.AreEqual(3, result.Pop());
            Assert.AreEqual(2, result.Pop());
            Assert.AreEqual(1, result.Pop());
        }
    }
}
