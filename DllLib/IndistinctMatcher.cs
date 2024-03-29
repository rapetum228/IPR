namespace DllLib;

public class IndistinctMatcher
{
    public static int FindIndistinctMatching(int maxLen, string first, string second)
    {
        MatchResult totalMatchResult = new MatchResult();
        ReadOnlySpan<char> firstSpan = first.AsSpan();
        ReadOnlySpan<char> secondSpan = second.AsSpan();

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

            matchResult = MatchingStrings(firstSpan, secondSpan, currentLenSubRowForMatching);

            totalMatchResult += matchResult;

            matchResult = MatchingStrings(secondSpan, firstSpan, currentLenSubRowForMatching);

            totalMatchResult += matchResult;

            currentLenSubRowForMatching++;
        }

        if (totalMatchResult.TotalSubstrings == 0)
            return 0;

        return (int)((decimal)totalMatchResult.MatchingSubstrings / totalMatchResult.TotalSubstrings * 100);
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

                if (substringOfFirst.Equals(substringOfSecond, StringComparison.OrdinalIgnoreCase))
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
}

public struct MatchResult
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