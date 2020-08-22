using AlgorithmsPractice.StacksAndQueues;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsPracticeTests.StacksAndQueues
{
    public class TowersOfHanoiTests
    {
        [Test]
        public void MoveTowersToLastRod_Test()
        {
            var n = 5;
            var towers = new TowerOfHanoi[n];

            for(var i = 0; i < 3; i++)
            {
                towers[i] = new TowerOfHanoi(i);
            }

            for(var i = n - 1; i >= 0; i--)
            {
                towers[0].Add(i);
            }

            towers[0].MoveDisks(n, towers[2], towers[1]);

            Assert.AreEqual(0, towers[2].Pop());
            Assert.AreEqual(1, towers[2].Pop());
            Assert.AreEqual(2, towers[2].Pop());
            Assert.AreEqual(3, towers[2].Pop());
            Assert.AreEqual(4, towers[2].Pop());
        }
    }
}
