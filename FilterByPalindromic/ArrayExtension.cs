using System;

namespace FilterByPalindromicTask
{
    /// <summary>
    /// Provides static method for working with integers array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }.
        /// </example>
        public static int[] FilterByPalindromic(int[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source is null");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Source is empty", nameof(source));
            }

            int[] array = new int[source.Length];
            int k = 0;
            for (int i = 0; i < source.Length; i++)
            {
                array[i] = -1;
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] < 0)
                {
                    continue;
                }

                if (source[i] == 0)
                {
                    array[k++] = i;
                    continue;
                }

                int[] custom = new int[10];
                int j = 9;
                int a = source[i];
                while (a > 0)
                {
                    custom[j] = a % 10;
                    j--;
                    a /= 10;
                }

                j++;
                int b = 9;
                while (custom[j] == custom[b] && j < b)
                {
                    j++;
                    b--;
                }

                if (j >= b)
                {
                    array[k++] = i;
                }
            }

            int[] final = new int[k];
            for (int i = 0; i < k; i++)
            {
                final[i] = source[array[i]];
            }

            return final;
        }
    }
}
