namespace AlgorithmsPractice.TreesAndGraphs
{
    /// <summary>
    /// Given a sorted (increasing order) array, 
    /// write an algorithm to create a binary tree with minimal height 
    /// </summary>
    public class BinarySearchTreeService
    {
        private static BinaryNode BuildFromSortedArray(int[] values, int start, int end)
        {
            if(values == null || values.Length == 0 || start > end)
            {
                return null;
            }

            var middle = (start + end) / 2;
            var rootValue = values[middle];
            var root = new BinaryNode(rootValue);
            root.Left = BuildFromSortedArray(values, start, middle - 1);
            root.Right = BuildFromSortedArray(values, middle + 1, end);
            return root;
        }

        public static BinaryNode BuildMinimalHeightTreeFromSortedArray(int[] values)
        {
            if(values == null || values.Length == 0)
            {
                return null;
            }
            return BuildFromSortedArray(values, 0, values.Length - 1);
        }
    }
}
