using AlgorithmsPractice.SearchingAndSorting;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.SearchingAndSorting
{
    public class SortServiceTests
    {
        [Test]
        public void MergeArraysTest_Intertwined_Test()
        {
            var a = new[]{ 1, 7, 10, 15, 19, 0, 0, 0, 0 };
            var b = new[] { 2, 8, 20, 21 };
            SortService.MergeSortedArrays(a, b, 5, 4);
            Assert.AreEqual(new[] { 1, 2, 7, 8, 10, 15, 19, 20, 21 }, a);
        }

        [Test]
        public void MergeArraysTest_NotIntertwined_bLast_Test()
        {
            var a = new[] { 1, 7, 10, 15, 19, 0, 0, 0, 0 };
            var b = new[] { 20, 21, 29, 30 };
            SortService.MergeSortedArrays(a, b, 5, 4);
            Assert.AreEqual(new[] { 1, 7, 10, 15, 19, 20, 21, 29, 30 }, a);
        }

        [Test]
        public void MergeArraysTest_NotIntertwined_aLast_Test()
        {
            var a = new[] { 19, 20, 21, 29, 30, 0, 0, 0, 0 };
            var b = new[] { 1, 2, 3, 4 };
            SortService.MergeSortedArrays(a, b, 5, 4);
            Assert.AreEqual(new[] { 1, 2, 3, 4, 19, 20, 21, 29, 30 }, a);
        }

        [Test]
        public void SortByAnagrams_Test()
        {
            var input = new[] { "bad", "a", "dab", "can", "a", "nac" };
            var actual = SortService.SortByAnagrams(input);
            Assert.AreEqual(new string[] { "a", "a", "bad", "dab", "can", "nac"}, actual );
        }
    }
}
