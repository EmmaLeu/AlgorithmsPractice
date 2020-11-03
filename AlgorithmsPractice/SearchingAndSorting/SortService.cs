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

        /// <summary>
        /// Given a sorted array of n integers that has been rotated an unknown number of times, 
        /// give an O(log n) algorithm that finds an element in the array   
        /// You may assume that the array was originally sorted in increasing order 
        /// </summary>
        /// <param name="input">The input array</param>
        /// <param name="element">Searched element/param>
        /// <returns></returns>
        public static int FindElementInSortedRotatedArray(int[] input, int element)
        {
            return FindElement(input, 0, input.Length - 1, element);
        }

        private static int FindElement(int[] input, int left, int right, int element)
        {
            while (left < right)
            {
                var middle = (left + right) / 2;
                if (element == input[middle])
                {
                    return middle;
                }
                else if (input[left] <= input[middle])
                {
                    if (element > input[middle])
                    {
                        left = middle + 1;
                    }
                    else if (element >= input[left])
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else if (element < input[middle])
                {
                    right = middle - 1;
                }
                else if (element <= input[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}
