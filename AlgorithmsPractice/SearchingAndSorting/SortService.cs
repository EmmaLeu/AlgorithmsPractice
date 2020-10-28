using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlgorithmsPractice.SearchingAndSorting
{
    public class SortService
    {
        /// <summary>
        /// Merge 2 sorted arrays knowing that the first one has a buffer for the second one's length
        /// </summary>
        /// <param name="a">First array (the longer one)</param>
        /// <param name="b">Second array</param>
        /// <param name="aElementNumber">Number of occupied positions in a</param>
        /// <param name="bElementNumber">Number of occupied positions in b</param>
        public static void MergeSortedArrays(int[] a, int[] b, int aElementNumber, int bElementNumber)
        {
            int lastAPosition = a.Length - 1;
            var lastBIndex = bElementNumber - 1;
            var lastAIndex = aElementNumber - 1;

            while(lastBIndex >= 0 && lastAIndex >= 0)
            {
                if (a[lastAIndex] > b[lastBIndex])
                {
                    a[lastAPosition--] = a[lastAIndex--];
                }
                else
                {
                    a[lastAPosition--] = b[lastBIndex--];
                }
            }

            while(lastBIndex >= 0)
            {
                a[lastAPosition--] = b[lastBIndex--];
            }
        }
        /// <summary>
        /// Sort an array of strings so that all the anagrams are next to each other   
        /// </summary>
        public static string[] SortByAnagrams(string[] input)
        {
            return input.OrderBy(a => a, new AnagramComparer()).ToArray();
        }

        private class AnagramComparer : IComparer<string>
        {
            public int Compare([AllowNull] string x, [AllowNull] string y)
            {
                return string.Concat(x.OrderBy(a => a)).CompareTo(string.Concat(y.OrderBy(a => a)));
            }
        }
    }
}
