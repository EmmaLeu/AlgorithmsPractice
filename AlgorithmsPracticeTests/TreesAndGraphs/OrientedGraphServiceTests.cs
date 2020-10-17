using AlgorithmsPractice.TreesAndGraphs;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsPracticeTests.TreesAndGraphs
{
    public class OrientedGraphServiceTests
    {
        [Test]
        public void DFS()
        {
            var service = new OrientedGrapthService(4);
            service.AddEdge(2, 0);
            service.AddEdge(0, 2);
            service.AddEdge(1, 2);
            service.AddEdge(0, 1);
            service.AddEdge(3, 3);
            service.AddEdge(1, 3);
            var expectedTraversal = new List<int>(new int[] { 2, 0, 1, 3 });

            var result = service.DepthFirstSearch(2);

            Assert.AreEqual(expectedTraversal, result);
        }

        [Test]
        public void BFS()
        {
            var service = new OrientedGrapthService(4);
            service.AddEdge(2, 0);
            service.AddEdge(0, 2);
            service.AddEdge(1, 2);
            service.AddEdge(0, 1);
            service.AddEdge(3, 3);
            service.AddEdge(2, 3);
            var expectedTraversal = new List<int>(new int[] { 2, 0, 3, 1 });

            var result = service.BreadthFirstSearch(2);

            Assert.AreEqual(expectedTraversal, result);
        }
    }
}
