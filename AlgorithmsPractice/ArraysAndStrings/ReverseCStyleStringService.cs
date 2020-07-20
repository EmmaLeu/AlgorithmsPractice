using System;
using System.Text;

namespace AlgorithmsPractice
{
    public class ReverseCStyleStringService
    {
        public const string NullUnicode = "\0";

        public static string ReverseStringUsingStringBuilder(string CStyleString)
        {
            if(string.IsNullOrEmpty(CStyleString))
            {
                throw new ArgumentNullException(nameof(CStyleString));
            }

            if (CStyleString == NullUnicode)
            {
                return CStyleString;
            }

            var reversedString = new StringBuilder();
            for(var charIndex = CStyleString.Length - 1; charIndex >= 0; charIndex--)
            {
                reversedString.Append(CStyleString[charIndex]);
            }

            return reversedString.ToString();
        }
    }
}
