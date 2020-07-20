using System.Linq;

namespace AlgorithmsPractice
{
    /// <summary>
    /// We assume we have only alphanumeric characters with ASCII between 0..255
    /// and that lower case letter is diffrent than upper case letter
    /// </summary>
    public static class UniqueCharactersService
    {
        public static bool HasUniqueCharactersFrequency(string input) // Time O(input.Length); Space O(256)
        {
            if(string.IsNullOrEmpty(input))
            {
                return true;
            }

            var frequencyArray = new int[256];

            foreach(var character in input)
            {
                frequencyArray[character]++;
                if(frequencyArray[character] > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasUniqueCharactersBruteforce(string input) // O(input.Length^2)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            if(input.Length == 1)
            {
                return true;
            }

            for(var index = 0; index < input.Length - 1; index ++)
            {
                for(var otherIndex = index + 1; otherIndex < input.Length; otherIndex++)
                {
                    if(input[index] == input[otherIndex])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool HasUniqueCharactersSorting(string input) // Time O(input.Length * log(input.Length)); Space: O(input.Length)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            if (input.Length == 1)
            {
                return true;
            }

            var sortedInput = input.OrderBy(c => c).ToArray();

            for (var index = 0; index < sortedInput.Length - 1; index++)
            { 
                if(sortedInput[index] == sortedInput[index + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
