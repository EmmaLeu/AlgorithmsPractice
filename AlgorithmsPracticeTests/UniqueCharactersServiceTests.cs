using AlgorithmsPractice;
using NUnit.Framework;

namespace AlgorithmsPracticeTests
{
    public class UniqueCharactersServiceTests
    {
        [TestCase(null, true)]
        [TestCase("1", true)]
        [TestCase("1ABcae", true)]
        [TestCase("11ABcae", false)]
        [TestCase("1sasabsabsbaaaa", false)]
        public void UniqueCharactersService_HasUniqueCharactersFrequency_Test(string input, bool expectedOutput)
        {
            var result = UniqueCharactersService.HasUniqueCharactersFrequency(input);

            Assert.AreEqual(expectedOutput, result);
        }

        [TestCase(null, true)]
        [TestCase("1", true)]
        [TestCase("1ABcae", true)]
        [TestCase("11ABcae", false)]
        [TestCase("1sasabsabsbaaaa", false)]
        public void UniqueCharactersService_HasUniqueCharactersBruteforce_Test(string input, bool expectedOutput)
        {
            var result = UniqueCharactersService.HasUniqueCharactersBruteforce(input);

            Assert.AreEqual(expectedOutput, result);
        }

        [TestCase(null, true)]
        [TestCase("1", true)]
        [TestCase("1ABcae", true)]
        [TestCase("11ABcae", false)]
        [TestCase("1sasabsabsbaaaa", false)]
        public void UniqueCharactersService_HasUniqueCharactersSorting_Test(string input, bool expectedOutput)
        {
            var result = UniqueCharactersService.HasUniqueCharactersSorting(input);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}
