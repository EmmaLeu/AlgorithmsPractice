using System.Collections.Generic;

namespace AlgorithmsPractice
{
    ///<summary>
    ///Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column is set to 0 
    ///O(lineLengthxcolumnLength) time
    ///Auxiliary O(lineLength) + O(columnLength) space
    ///</summary>
    public class MatrixZeroingService
    {
        public static void ZeroMartrix(int[][] matrix, int lineLength, int columnLength)
        {
            if (matrix == null)
            {
                return;
            }

            var columnsToZero = new HashSet<int>();
            var linesToZero = new HashSet<int>();
            for (var lineIndex = 0; lineIndex < lineLength; lineIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    if (matrix[lineIndex][columnIndex] == 0)
                    {
                        columnsToZero.Add(columnIndex);
                        linesToZero.Add(lineIndex);
                    }
                }
            }

            SetColumnsToZero(matrix, lineLength, columnsToZero);
            SetLinesToZero(matrix, columnLength, linesToZero);
        }

        private static void SetLinesToZero(int[][] matrix, int columnLength, HashSet<int> linesToZero)
        {
            foreach (var lineIndex in linesToZero)
            {
                for (var columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    matrix[lineIndex][columnIndex] = 0;
                }
            }
        }

        private static void SetColumnsToZero(int[][] matrix, int lineLength, HashSet<int> columnsToZero)
        {
            foreach (var columnIndex in columnsToZero)
            {
                for (var lineIndex = 0; lineIndex < lineLength; lineIndex++)
                {
                    matrix[lineIndex][columnIndex] = 0;
                }
            }
        }
    }
}
