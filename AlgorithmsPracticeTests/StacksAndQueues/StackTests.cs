using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class StackTests
    {
        [Test]
        public void Stack_LIFO_Test()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            var item = stack.Pop();
            Assert.AreEqual(2, item);

            item = stack.Pop();
            Assert.AreEqual(1, item);
        }

        [Test]
        public void Stack_Pop_EmptyStack_Test()
        {
            var stack = new Stack<int>();
            var item = stack.Pop();
            Assert.AreEqual(default(int), item);
        }
    }
}
