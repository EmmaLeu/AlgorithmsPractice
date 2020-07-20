using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class QueueTests
    {
        [Test]
        public void Queue_FIFO_Test()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            var item = queue.Dequeue();
            Assert.AreEqual(1, item);

            item = queue.Dequeue();
            Assert.AreEqual(2, item);
        }

        [Test]
        public void Dequeue_EmptyQueue_Test()
        {
            var queue = new Queue<int>();

            var item = queue.Dequeue();
            Assert.AreEqual(default(int), item);
        }
    }
}
