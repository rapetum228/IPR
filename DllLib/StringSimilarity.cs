namespace DllLib
{
    public class StringSimilarity
    {
        public static int CalculateSimilarity(string A, string B)
        {
            int res = 0;
            int lenA = A.Length;
            int lenB = B.Length;

            if (lenA == lenB)
                res = 10;

            for (int i = 0; i < lenA - 2; ++i)
            {
                int minlen = lenA - i;
                for (int j = 0; j < lenB - 2; ++j)
                {
                    if (lenA - i > lenB - j)
                        minlen = lenB - j;

                    int k = 0;
                    while (k < minlen && A[i + k] == B[j + k])
                    {
                        ++k;
                    }

                    if (k > 2)
                    {
                        res += k * k * k;
                        j += k;
                    }
                }
            }

            return res;
        }
    }
}