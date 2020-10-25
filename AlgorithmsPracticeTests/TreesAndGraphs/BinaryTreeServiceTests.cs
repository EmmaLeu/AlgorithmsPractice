using AlgorithmsPractice.TreesAndGraphs;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsPracticeTests.TreesAndGraphs
{
    public class BinaryTreeServiceTests
    {
        [Test]
        public void FindFirstCommonAncestor_WithParentLink_Test()
        {
            var testCases = GetCommonAncestorTestCases();
            
            foreach(var testCase in testCases)
            {
                Assert.AreEqual(testCase.FirstCommonAncestor, BinaryTreeService.FindFirstCommonAncestor(testCase.Node1, testCase.Node2));
            }
        }

        [Test]
        public void FindFirstCommonAncestor_WithoutParentLink_Test()
        {
            var testCases = GetCommonAncestorTestCases();

            foreach (var testCase in testCases)
            {
                Assert.AreEqual(testCase.FirstCommonAncestor, BinaryTreeService.FindFirstCommonAncestor(testCase.Root, testCase.Node1, testCase.Node2));
            }
        }

        [Test]
        public void IsSubtreeOf_Test()
        {
            foreach (var tc in GetSubTreeTestCases())
            {
                Assert.AreEqual(tc.IsSubtreeOf, BinaryTreeService.IsSubtreeOf(tc.FirstTree, tc.SecondTree));
            }
        }

        [Test]
        public void FindSum_Test()
        {
            foreach (var tc in GetFindSumTestCases())
            {
                Assert.AreEqual(tc.ExpectedPaths, BinaryTreeService.GetSumPaths(tc.Root, tc.Sum));
            }
        }

        private static SubTreeTestCase[] GetSubTreeTestCases()
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

        private static CommonAncestorTestCase[] GetCommonAncestorTestCases()
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
                new CommonAncestorTestCase
                {
                    Root = root,
                    Node1 = leftRight,
                    Node2 = right,
                    FirstCommonAncestor = root
                },

                new CommonAncestorTestCase
                {
                    Root = root,
                    Node1 = leftLeft,
                    Node2 = leftRight,
                    FirstCommonAncestor = left
                },

                new CommonAncestorTestCase
                {
                    Root = root,
                    Node1 = root,
                    Node2 = leftRight,
                    FirstCommonAncestor = root
                },
            };
        }

        private static FindSumTestCase[] GetFindSumTestCases()
        {
            var root = new BinaryNode(1); //L0

            var left = new BinaryNode(3);
            var right = new BinaryNode(-1);

            var leftLeft = new BinaryNode(2);
            var leftRight = new BinaryNode(1);
            var leftRightLeft = new BinaryNode(1);

            var rightLeft = new BinaryNode(4);
            var rightLeftLeft = new BinaryNode(1);
            var rightLeftRight = new BinaryNode(2);
            var rightRight= new BinaryNode(5);
            var rightRightRight = new BinaryNode(6);

            //L1
            root.Left = left; 
            root.Right = right;

            //L2
            left.Left = leftLeft;
            left.Right = leftRight;

            right.Left = rightLeft;
            right.Right = rightRight;

            //L3
            left.Right.Left = leftRightLeft;
            right.Left.Left = rightLeftLeft;
            right.Left.Right = rightLeftRight;
            right.Right.Right = rightRightRight;

            return new FindSumTestCase[]
            {
                new FindSumTestCase
                {
                    Root = root,
                    Sum = 5,
                    ExpectedPaths = new List<List<int>>
                    {
                        new List<int>{ 3, 2 },
                        new List<int>{ 1, 3, 1 },
                        new List<int>{ 3, 1, 1 },
                        new List<int>{ 4, 1 },
                        new List<int>{ 1, -1, 4, 1 },
                        new List<int>{ -1, 4, 2 },
                        new List<int>{ 5 },
                        new List<int>{ 1, -1, 5 }
                    }
                }
            };
        }

        private class SubTreeTestCase
        {
            public BinaryNode FirstTree { get; set; }

            public BinaryNode SecondTree { get; set; }

            public bool IsSubtreeOf { get; set; }
        }

        private class CommonAncestorTestCase
        {
            public BinaryNodeWithParent Root { get; set; }
            public BinaryNodeWithParent Node1 { get; set; }
            public BinaryNodeWithParent Node2 { get; set; }
            public BinaryNodeWithParent FirstCommonAncestor { get; set; }
        }

        private class FindSumTestCase
        {
            public BinaryNode Root { get; set; }
            public int Sum { get; set; }
            public List<List<int>> ExpectedPaths { get; set; }
        }
    }
}
