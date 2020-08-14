using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class SetOfStacksWithRolloverTests
    {
        [Test]
        public void PopAt_Test()
        {
            var setOfStacks = new SetOfStacksWithRollover(2);

            setOfStacks.Push(0);
            setOfStacks.Push(1);

            Assert.AreEqual(1, setOfStacks.GetStackNumber());

            setOfStacks.Push(2);
            setOfStacks.Push(3);

            Assert.AreEqual(2, setOfStacks.GetStackNumber());

            setOfStacks.Push(4);
            setOfStacks.Push(5);

            Assert.AreEqual(3, setOfStacks.GetStackNumber());

            Assert.AreEqual(3, setOfStacks.PopAt(1));
        }
    }
}
