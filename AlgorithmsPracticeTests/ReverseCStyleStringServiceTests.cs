using AlgorithmsPractice;
using NUnit.Framework;

namespace AlgorithmsPracticeTests
{
    public class ReverseCStyleStringServiceTests
    {
        [TestCase("1\0", "\01")]
        [TestCase("yaya\0", "\0ayay")]
        [TestCase("\0", "\0")]
        public void ReverseCStyleStringService_ReverseString_Test(string input, string expectedOutput)
        {
            var result = ReverseCStyleStringService.ReverseStringUsingStringBuilder(input);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}
