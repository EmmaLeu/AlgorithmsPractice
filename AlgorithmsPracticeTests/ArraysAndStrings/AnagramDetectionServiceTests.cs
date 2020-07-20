using AlgorithmsPractice.ArraysAndStrings;
using NUnit.Framework;

namespace AlgorithmsPracticeTests.ArraysAndStrings
{
    public class AnagramDetectionServiceTests
    {
        [TestCase(null, null, true)]
        [TestCase("", "", true)]
        [TestCase("", null, true)] //consider null or empty string anagrams
        [TestCase("aba", "baa", true)]
        [TestCase(null, "a", false)]
        [TestCase("a", null, false)]
        [TestCase("aba", "baaa", false)]
        public void AnagramDetectionService_AreAnagramsSorting_Test(string firstString, string secondString, bool shouldBeAnagrams)
        {
            var result = AnagramDetectionService.AreAnagrams_Sorting(firstString, secondString);

            Assert.AreEqual(shouldBeAnagrams, result);
        }

        [TestCase(null, null, true)]
        [TestCase("", "", true)]
        [TestCase("", null, true)] //consider null or empty string anagrams
        [TestCase("aba", "baa", true)]
        [TestCase(null, "a", false)]
        [TestCase("a", null, false)]
        [TestCase("aba", "baaa", false)]
        public void AnagramDetectionService_AreAnagramsFrequency_Test(string firstString, string secondString, bool shouldBeAnagrams)
        {
            var result = AnagramDetectionService.AreAnagrams_Frequency(firstString, secondString);

            Assert.AreEqual(shouldBeAnagrams, result);
        }
    }
}
