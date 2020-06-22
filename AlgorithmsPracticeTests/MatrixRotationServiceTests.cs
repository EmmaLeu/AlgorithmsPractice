using AlgorithmsPractice;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsPracticeTests
{
    public class MatrixRotationServiceTests
    {
        [TestCaseSource(nameof(TestCaseData))]
        public void MatrixRotationService_Rotate_Test(int[][] input, int[][] expected)
        {
            var actual = MatrixRotationService.RotateUsingAdditionalMemory(input);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(TestCaseData))]
        public void MatrixRotationService_RotateInPlace_Test(int[][] input, int[][] expected)
        {
            MatrixRotationService.RotateInPlace(input);

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
                        new int[] { 1, 2, 3 },
                        new int[] { 4, 5, 6 },
                        new int[] { 7, 8, 9}
                    },
                    new int[][] //expected
                    {
                        new int[] { 7, 4, 1 },
                        new int[] { 8, 5, 2 },
                        new int[] { 9, 6, 3}
                    }
                };

                yield return new object[]
                {
                    new int[][] //input
                    {
                        new int[] { 1 }
                    },
                    new int[][] //expected
                    {
                        new int[] { 1 }
                    }
                };

                yield return new object[]
                {
                    null,
                    null
                };
            }
        }
    }
}
