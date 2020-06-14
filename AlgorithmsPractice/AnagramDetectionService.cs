using System;
using System.Linq;

namespace AlgorithmsPractice
{
    /// <summary>
    /// Assuming we have only alphanumeric characters with ASCII between 0..255
    /// and that lower case letter is same as upper case
    /// </summary>
    public class AnagramDetectionService
    {
        //O(nlogn) complexity because of sorting
        public static bool AreAnagrams_Sorting(string firstString, string secondString)
        {
            if(string.IsNullOrEmpty(firstString) && string.IsNullOrEmpty(secondString))
            {
                return true;
            }

            if(firstString == null || secondString == null)
            {
                return false;
            }

            if(firstString.Length != secondString.Length)
            {
                return false;
            }

            var orderedFirstString = firstString.OrderBy(s => s).ToString();
            var orderedSecondString = secondString.OrderBy(s => s).ToString();

            if (orderedFirstString.Equals(orderedSecondString, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            
            return false;
        }

        //O(n) complexity
        public static bool AreAnagrams_Frequency(string firstString, string secondString)
        {
            if (string.IsNullOrEmpty(firstString) && string.IsNullOrEmpty(secondString))
            {
                return true;
            }

            if (firstString == null || secondString == null)
            {
                return false;
            }

            if (firstString.Length != secondString.Length)
            {
                return false;
            }

            var frequencyArray = new int[256];

            foreach(var character in firstString)
            {
                 frequencyArray[char.ToLower(character)]++;
            }
            
            foreach(var character in secondString)
            {
                frequencyArray[char.ToLower(character)]--;
            }

            foreach(var character in frequencyArray)
            {
                if(character != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
