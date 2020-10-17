using System;
using System.Collections.Generic;

namespace AlgorithmsPractice.TreesAndGraphs
{
    public class OrientedGrapthService
    {
        private int _numberOfVertices;
        private Dictionary<int, List<int>> _adjacencyList;

        public OrientedGrapthService(int numberOfVertices)
        {
            _numberOfVertices = numberOfVertices;
            _adjacencyList = new Dictionary<int, List<int>>();
            for (var index = 0; index < _numberOfVertices; index++)
            {
                _adjacencyList[index] = new List<int>();
            }
        }

        public void AddEdge(int fromVertex, int toVertex)
        {
            if(!_adjacencyList.ContainsKey(fromVertex))
            {
                throw new ArgumentException(nameof(fromVertex));
            }

            _adjacencyList[fromVertex].Add(toVertex);
        }

        public bool AreConnected(int start, int end)
        {
            return DepthFirstSearch(start).Contains(end);
        }

        public bool AreConnectedOptimized(int start, int end)
        {
            var visited = new HashSet<int>();
            visited.Add(start);

            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                start = queue.Dequeue();
                foreach (var adjacentVertex in _adjacencyList[start])
                {
                    if(adjacentVertex == end)
                    {
                        return true;
                    }

                    if (!visited.Contains(adjacentVertex))
                    {
                        visited.Add(adjacentVertex);
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }

            return false;
        }

        public List<int> BreadthFirstSearch(int vertex)
        {
            var traversal = new List<int>();
            var visited = new HashSet<int>();
            visited.Add(vertex);

            var queue = new Queue<int>();
            queue.Enqueue(vertex);

            while(queue.Count > 0)
            {
                vertex = queue.Dequeue();
                traversal.Add(vertex);
                foreach(var adjacentVertex in _adjacencyList[vertex])
                {
                    if (!visited.Contains(adjacentVertex))
                    {
                        visited.Add(adjacentVertex);
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }

            return traversal;
        }

        public List<int> DepthFirstSearch(int vertex)
        {
            var traversal = new List<int>();
            var visited = new HashSet<int>();

            DepthFirstSearchRecursive(vertex, visited, traversal);
            return traversal;
        }

        private void DepthFirstSearchRecursive(int vertex, HashSet<int> visited, List<int> traversal)
        {
            visited.Add(vertex);
            traversal.Add(vertex);
            foreach(var adjacentVertex in _adjacencyList[vertex])
            {
                if(!visited.Contains(adjacentVertex))
                {
                    DepthFirstSearchRecursive(adjacentVertex, visited, traversal);
                }
            }
        }
    }
}
