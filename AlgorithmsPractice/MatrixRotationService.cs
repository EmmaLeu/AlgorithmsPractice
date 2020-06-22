namespace AlgorithmsPractice
{

    /// <summary>
    /// Rotate a NxN matrix by 90 degrees
    /// </summary>
    public class MatrixRotationService
    {
        public static void RotateInPlace(int[][] matrix)
        {
            if (matrix == null)
            {
                return;
            }

            var length = matrix.GetLength(0);

            for (var layer = 0; layer < length / 2; ++layer)
            {
                var first = layer;
                var last = length - 1 - layer;
                for (var index = first; index < last; ++index)
                {
                    var offset = index - first;
                    var top = matrix[first][index];
                    matrix[first][index] = matrix[last - offset][first]; //left -> top
                    matrix[last - offset][first] = matrix[last][last - offset]; //bottom -> left
                    matrix[last][last - offset] = matrix[index][last]; // right -> bottom
                    matrix[index][last] = top; //top -> right
                }
            }
        }

        public static int[][] RotateUsingAdditionalMemory(int[][] matrix)
        {
            if (matrix == null)
            {
                return null;
            }

            var length = matrix.GetLength(0);
            int[][] rotatedMatrix = GetInitializedRotatedMatrix(length);

            for (var lineIndex = 0; lineIndex < length; lineIndex++)
            {
                for (var columnIndex = 0; columnIndex < length; columnIndex++)
                {
                    rotatedMatrix[columnIndex][length - lineIndex - 1] = matrix[lineIndex][columnIndex];
                }
            }

            return rotatedMatrix;
        }

        private static int[][] GetInitializedRotatedMatrix(int length)
        {
            var rotatedMatrix = new int[length][];

            for (var lineIndex = 0; lineIndex < length; lineIndex++)
            {
                rotatedMatrix[lineIndex] = new int[length];
            }

            return rotatedMatrix;
        }
    }
}
