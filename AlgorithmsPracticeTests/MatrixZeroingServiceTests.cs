using AlgorithmsPractice;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsPracticeTests
{
    public class MatrixZeroingServiceTests
    {
        [TestCaseSource(nameof(TestCaseData))]
        public void MatrixZeroingService_ZeroMarix_Test(int[][] input, int lines, int columns, int[][] expected)
        {
            MatrixZeroingService.ZeroMartrix(input, lines, columns);

            Assert.AreEqual(expected, input);
        }

        public static IEnumerable<object[]> TestCaseData
        {
            get
            {
                yield return new object[]
                {
                    new int[][] //input
                    {
                        new int[] { 7, 4, 3 },
                        new int[] { 4, 5, 0 },
                        new int[] { 7, 8, 0}
                    },
                    3,
                    3,
                    new int[][] //expected
                    {
                        new int[] { 7, 4, 0 },
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0}
                    }
                };

                yield return new object[]
                {
                    new int[][] //input
                    {
                        new int[] { 1, 1, 0 },
                        new int[] { 1, 1, 0 },
                        new int[] { 1, 1, 0 },
                        new int[] { 1, 1, 0 }
                    },
                    4,
                    3,
                    new int[][] //expected
                    {
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0 }
                    }
                };

                yield return new object[]
                {
                    null,
                    0,
                    0,
                    null
                };
            }
        }
    }
}
