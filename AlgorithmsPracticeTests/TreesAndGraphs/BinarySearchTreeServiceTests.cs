using NUnit.Framework;
using AlgorithmsPractice.TreesAndGraphs;
using System.Collections.Generic;

namespace AlgorithmsPracticeTests.TreesAndGraphs
{
    public class BinarySearchTreeServiceTests
    {
        [Test]
        public void BuildMinimalHeightTreeFromSortedArray_Length8_Test()
        {
            var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8};
            var node = BinarySearchTreeService.BuildMinimalHeightTreeFromSortedArray(values);

            Assert.AreEqual(4, node.Value);

            Assert.AreEqual(2, node.Left.Value);
            Assert.AreEqual(1, node.Left.Left.Value);
            Assert.AreEqual(3, node.Left.Right.Value);

            Assert.AreEqual(6, node.Right.Value);
            Assert.AreEqual(5, node.Right.Left.Value);
            Assert.AreEqual(7, node.Right.Right.Value);
            Assert.AreEqual(8, node.Right.Right.Right.Value);
        }

        [Test]
        public void BuildMinimalHeightTreeFromSortedArray_Null_Test()
        {
            int[] values = null;
            var node = BinarySearchTreeService.BuildMinimalHeightTreeFromSortedArray(values);

            Assert.Null(node);
        }

        [Test]
        public void BuildMinimalHeightTreeFromSortedArray_Length1_Test()
        {
            int[] values = { 1 };
            var node = BinarySearchTreeService.BuildMinimalHeightTreeFromSortedArray(values);

            Assert.AreEqual(1, node.Value);
        }

        [Test]
        public void GetNodesByLevel_Test()
        {
            var tree = BinarySearchTreeService.BuildMinimalHeightTreeFromSortedArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });

            var result = BinarySearchTreeService.GetNodeListsByLevel(tree);

            var expected = new Dictionary<int, LinkedList<int>>()
            {
                { 0, new LinkedList<int>(new[] { 4 })},
                { 1, new LinkedList<int>(new[] { 2, 6 }) },
                { 2, new LinkedList<int>(new[] { 1, 3, 5, 7 }) },
                { 3, new LinkedList<int>(new[] { 8 }) }
            };

            Assert.AreEqual(expected, result);
        }
    }
}
