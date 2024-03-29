using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllLib
{
    public class IndistinctMatcherTuple
    {
        /// <summary>
        /// Функция возвращает процент совпадения двух строк, основанным на нечетком сравнении.
        /// </summary>
        /// <param name="maxLen">Максимальная длина для сравнения</param>
        /// <param name="first">Первая строка</param>
        /// <param name="second">Вторая строка</param>
        /// <returns></returns>
        public static int FindIndistinctMatching(int maxLen, string first, string second)
        {
            int TotalSubstrings = 0;
            int MatchingSubstrings = 0;


            int currentLenSubRowForMatching = 1;

            if (maxLen == 0 || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second))
                return 0;

            int lenFirst = first.Length;
            int lenSecond = second.Length;

            if (maxLen > lenFirst && maxLen > lenSecond)
                maxLen = lenFirst > lenSecond ? lenFirst : lenSecond;

            while (currentLenSubRowForMatching <= maxLen)
            {
                int localSubstrings;
                int localMatching;

                (localSubstrings, localMatching) = MatchingStrings(first, second, currentLenSubRowForMatching);

                TotalSubstrings += localSubstrings;
                MatchingSubstrings += localMatching;

                (localSubstrings, localMatching) = MatchingStrings(second, first, currentLenSubRowForMatching);

                TotalSubstrings += localSubstrings;
                MatchingSubstrings += localMatching;

                currentLenSubRowForMatching++;
            }

            if (TotalSubstrings == 0)
            {
                return 0;
            }

            return (int)((double)MatchingSubstrings / TotalSubstrings * 100 + 0.5);
        }

        public static (int, int) MatchingStrings(ReadOnlySpan<char> first, ReadOnlySpan<char> second, int substringLength)
        {
            int totalSubstrings = 0;
            int matchingSubstrings = 0;
            ReadOnlySpan<char> substringOfFirst;
            ReadOnlySpan<char> substringOfSecond;

            int indexOfFirst = 1;
            while (indexOfFirst <= (first.Length - substringLength + 1))
            {
                substringOfFirst = first.Slice(indexOfFirst - 1, substringLength);
                int indexOfSecond = 1;

                while (indexOfSecond <= (second.Length - substringLength + 1))
                {
                    substringOfSecond = second.Slice(indexOfSecond - 1, substringLength);

                    if (substringOfFirst.SequenceEqual(substringOfSecond))
                    {
                        matchingSubstrings++;
                        break;
                    }

                    indexOfSecond++;
                }

                totalSubstrings++;
                indexOfFirst++;
            }

            return (totalSubstrings, matchingSubstrings);
        }

    }
}
