using AlgorithmsPractice.TreesAndGraphs;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.TreesAndGraphs
{
    public class BinaryTreeServiceTests
    {
        [Test]
        public void FindFirstCommonAncestor_Test()
        {
            var testCases = GetTestCases();
            
            foreach(var testCase in testCases)
            {
                Assert.AreEqual(testCase.FirstCommonAncestor, BinaryTreeService.FindFirstCommonAncestor(testCase.Node1, testCase.Node2));
            }
        }

        private static TestCase[] GetTestCases()
        {
            var root = new BinaryNodeWithParent(1);
            var leftLeft = new BinaryNodeWithParent(4);
            var leftRight = new BinaryNodeWithParent(5);

            var left = new BinaryNodeWithParent(2)
            {
                Parent = root,
                Left = leftLeft,
                Right = leftRight
            };

            leftLeft.Parent = left;
            leftRight.Parent = left;

            var right = new BinaryNodeWithParent(3)
            {
                Parent = root
            };

            root.Left = left;
            root.Right = right;

            return new[]
            {
                new TestCase
                {
                    Node1 = leftRight,
                    Node2 = right,
                    FirstCommonAncestor = root
                },

                new TestCase
                {
                    Node1 = leftLeft,
                    Node2 = leftRight,
                    FirstCommonAncestor = left
                },

                new TestCase
                {
                    Node1 = root,
                    Node2 = leftRight,
                    FirstCommonAncestor = root
                },
            };
        }

        private class TestCase
        {
            public BinaryNodeWithParent Node1 { get; set; }
            public BinaryNodeWithParent Node2 { get; set; }
            public BinaryNodeWithParent FirstCommonAncestor { get; set; }
        }
    }
}
