using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllLib
{
    public class IndistinctMatcherClass
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
            MatchResult totalMatchResult = new MatchResult();

            int currentLenSubRowForMatching = 1;

            if (maxLen == 0 || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second))
                return 0;

            int lenFirst = first.Length;
            int lenSecond = second.Length;

            if (maxLen > lenFirst && maxLen > lenSecond)
                maxLen = lenFirst > lenSecond ? lenFirst : lenSecond;

            while (currentLenSubRowForMatching <= maxLen)
            {
                MatchResult matchResult;

                matchResult = MatchingStrings(first, second, currentLenSubRowForMatching);

                totalMatchResult += matchResult;

                matchResult = MatchingStrings(second, first, currentLenSubRowForMatching);

                totalMatchResult += matchResult;

                currentLenSubRowForMatching++;
            }

            if (totalMatchResult.TotalSubstrings == 0)
            {
                return 0;
            }

            return (int)((double)totalMatchResult.MatchingSubstrings / totalMatchResult.TotalSubstrings * 100 + 0.5);
        }

        public static MatchResult MatchingStrings(ReadOnlySpan<char> first, ReadOnlySpan<char> second, int substringLength)
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

            return new MatchResult { TotalSubstrings = totalSubstrings, MatchingSubstrings = matchingSubstrings };
        }

        public class MatchResult
        {
            public int TotalSubstrings { get; set; }
            public int MatchingSubstrings { get; set; }

            public static MatchResult operator +(MatchResult first, MatchResult second)
            {
                first.MatchingSubstrings += second.MatchingSubstrings;
                first.TotalSubstrings += second.TotalSubstrings;
                return first;
            }
        }
    }
}