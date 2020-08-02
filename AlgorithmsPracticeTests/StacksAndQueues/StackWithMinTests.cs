using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class StackWithMinTests
    {
        [Test]
        public void Min_Test()
        {
            var stack = new StackWithMin();

            stack.Push(3);
            stack.Push(2);
            stack.Push(8);
            stack.Push(1);

            Assert.AreEqual(1, stack.Min());
        }
    }
}
