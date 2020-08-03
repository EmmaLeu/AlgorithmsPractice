using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class SetOfStacksTests
    {
        [Test]
        public void Init_Test()
        {
            var stack = new SetOfStacks(0);
            Assert.AreEqual(0, stack.GetStackNumber());
        }

        [Test]
        public void Push_Test()
        {
            var stack = new SetOfStacks(2);
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(1, stack.GetStackNumber());

            stack.Push(3);
            Assert.AreEqual(2, stack.GetStackNumber());
        }


        [Test]
        public void Pop_Test()
        {
            var stack = new SetOfStacks(2);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var value = stack.Pop();
            Assert.AreEqual(3, value);
            Assert.AreEqual(1, stack.GetStackNumber());

            value = stack.Pop();
            Assert.AreEqual(2, value);
            Assert.AreEqual(1, stack.GetStackNumber());

            value = stack.Pop();
            Assert.AreEqual(1, value);
            Assert.AreEqual(0, stack.GetStackNumber());
        }
    }
}
