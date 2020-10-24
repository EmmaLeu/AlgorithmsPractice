using AlgorithmsPractice.TreesAndGraphs;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.TreesAndGraphs
{
    public class BinaryTreeServiceTests
    {
        [Test]
        public void FindFirstCommonAncestor_WithParentLink_Test()
        {
            var testCases = GetTestCases();
            
            foreach(var testCase in testCases)
            {
                Assert.AreEqual(testCase.FirstCommonAncestor, BinaryTreeService.FindFirstCommonAncestor(testCase.Node1, testCase.Node2));
            }
        }

        [Test]
        public void FindFirstCommonAncestor_WithoutParentLink_Test()
        {
            var testCases = GetTestCases();

            foreach (var testCase in testCases)
            {
                Assert.AreEqual(testCase.FirstCommonAncestor, BinaryTreeService.FindFirstCommonAncestor(testCase.Root, testCase.Node1, testCase.Node2));
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
                    Root = root,
                    Node1 = leftRight,
                    Node2 = right,
                    FirstCommonAncestor = root
                },

                new TestCase
                {
                    Root = root,
                    Node1 = leftLeft,
                    Node2 = leftRight,
                    FirstCommonAncestor = left
                },

                new TestCase
                {
                    Root = root,
                    Node1 = root,
                    Node2 = leftRight,
                    FirstCommonAncestor = root
                },
            };
        }

        private class TestCase
        {
            public BinaryNodeWithParent Root { get; set; }
            public BinaryNodeWithParent Node1 { get; set; }
            public BinaryNodeWithParent Node2 { get; set; }
            public BinaryNodeWithParent FirstCommonAncestor { get; set; }
        }

        [Test]
        public void IsSubtreeOf_Test()
        {
            foreach (var tc in GetSubTreeTestCases())
            {
                Assert.AreEqual(tc.IsSubtreeOf, BinaryTreeService.IsSubtreeOf(tc.FirstTree, tc.SecondTree));
            }
        }

        private SubTreeTestCase[] GetSubTreeTestCases()
        {
            var firstTree = new BinaryNode(1);
            var left = new BinaryNode(2);
            var right = new BinaryNode(3);
            var leftLeft = new BinaryNode(4);
            var leftRight = new BinaryNode(5);
            var rightLeft = new BinaryNode(6);
            var leftLeftLeft = new BinaryNode(7);
            var leftLeftRight = new BinaryNode(8);

            firstTree.Left = left;
            firstTree.Right = right;

            left.Left = leftLeft;
            left.Right = leftRight;

            leftLeft.Left = leftLeftLeft;
            leftLeft.Right = leftLeftRight;

            right.Left = rightLeft;

            var someTree = new BinaryNode(9);
            return new SubTreeTestCase[2]
            {
                new SubTreeTestCase
                {
                    FirstTree = firstTree,
                    SecondTree = leftLeft,
                    IsSubtreeOf = true
                },
                new SubTreeTestCase
                {
                    FirstTree = firstTree,
                    SecondTree = someTree,
                    IsSubtreeOf = false
                }
            };
        }

        private class SubTreeTestCase
        {
            public BinaryNode FirstTree { get; set; }

            public BinaryNode SecondTree { get; set; }

            public bool IsSubtreeOf { get; set; }
        }
    }
}
