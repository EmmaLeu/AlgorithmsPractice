using AlgorithmsPractice.TreesAndGraphs;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.TreesAndGraphs
{
    public class BalancedTreeServiceTests
    {
        [Test]
        public void IsBalanced_True_Test()
        {
            var tree = new BinaryNode(1);
            var l11 = new BinaryNode(2);
            var l12 = new BinaryNode(3);

            var l211 = new BinaryNode(4);
            var l221 = new BinaryNode(5);

            var l212 = new BinaryNode(6);
            var l222 = new BinaryNode(7);

            var l3212 = new BinaryNode(8);

            l222.Left = l3212;

            l11.Left = l211;
            l11.Right = l221;

            l12.Left = l212;
            l12.Right = l222;

            tree.Left = l11;
            tree.Right = l12;

            var service = new BalancedTreeService();
            var result = service.IsBalanced(tree);

            Assert.True(result);
        }

        [Test]
        public void IsBalanced_False_Test()
        {
            var tree = new BinaryNode(1);
            var l11 = new BinaryNode(2);
            var l12 = new BinaryNode(3);

            var l211 = new BinaryNode(4);
            var l3211 = new BinaryNode(8);

            l211.Left = l3211;
            l11.Left = l211;

            tree.Left = l11;
            tree.Right = l12;

            var service = new BalancedTreeService();
            var result = service.IsBalanced(tree);

            Assert.False(result);
        }
    }
}
