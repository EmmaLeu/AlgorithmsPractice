using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class ThreeStackServiceTest
    {
        [Test]
        public void Peek_Test()
        {
            var service = new ThreeStackService(3);

            service.Push(0, 1);
            service.Push(1, 2);
            service.Push(2, 3);

            var firstStackValue = service.Peek(0);
            Assert.AreEqual(1, firstStackValue);

            var secondStackValue = service.Peek(1);
            Assert.AreEqual(2, secondStackValue);

            var thirdStackValue = service.Peek(2);
            Assert.AreEqual(3, thirdStackValue);

            Assert.False(service.IsEmpty(0));
            Assert.False(service.IsEmpty(1));
            Assert.False(service.IsEmpty(2));
        }

        [Test]
        public void Pop_Test()
        {
            var service = new ThreeStackService(9);

            service.Push(0, 1);
            service.Push(1, 2);
            service.Push(2, 3);

            var firstStackValue = service.Pop(0);
            Assert.AreEqual(1, firstStackValue);

            var secondStackValue = service.Pop(1);
            Assert.AreEqual(2, secondStackValue);

            var thirdStackValue = service.Pop(2);
            Assert.AreEqual(3, thirdStackValue);

            Assert.True(service.IsEmpty(0));
            Assert.True(service.IsEmpty(1));
            Assert.True(service.IsEmpty(2));
        }
    }
}
