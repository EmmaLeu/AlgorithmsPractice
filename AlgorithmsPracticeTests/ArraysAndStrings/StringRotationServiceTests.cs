using AlgorithmsPractice;
using NUnit.Framework;

namespace AlgorithmsPracticeTests
{
    public class StringRotationServiceTests
    {
        [TestCase("", "", true)]
        [TestCase(null, null, true)]
        [TestCase("a","a", true)]
        [TestCase("aba", "aba", true)]
        [TestCase("waterbottle", "erbottlewat", true)]
        [TestCase("aba", "a", false)]
        public void StringRotationService_IsRotation_Test(string s1, string s2, bool isRotation)
        {
            var result = StringRotationService.IsRotation(s1, s2);
            Assert.AreEqual(isRotation, result);
        }
    }
}
