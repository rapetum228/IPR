using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllLib
{
    using System;

    public class IndistinctMatchingHelper
    {
        public static int IndistinctMatching(int? maxLen, string stringMatching, string stringStandart)
        {
            int gretLngSubRows = 0;
            int gretLngCountLike = 0;
            int tretLngSubRows;
            int tretLngCountLike;
            int lngCurLen = 1;

            if (!maxLen.HasValue || string.IsNullOrEmpty(stringMatching) || string.IsNullOrEmpty(stringStandart))
                return 0;

            while (lngCurLen <= maxLen.Value)
            {
                (tretLngSubRows, tretLngCountLike) = MatchingStrings(stringMatching, stringStandart, lngCurLen);

                gretLngSubRows += tretLngSubRows;
                gretLngCountLike += tretLngCountLike;

                (tretLngSubRows, tretLngCountLike) = MatchingStrings(stringStandart, stringMatching, lngCurLen);

                gretLngSubRows += tretLngSubRows;
                gretLngCountLike += tretLngCountLike;

                lngCurLen++;
            }

            if (gretLngSubRows == 0)
                return 0;

            return (int)(1.0 * gretLngCountLike / gretLngSubRows * 100);
        }

        public static (int lngSubRows, int lngCountLike) MatchingStrings(string strA, string strB, int lngLen)
        {
            int tretLngSubRows = 0;
            int tretLngCountLike = 0;
            int y, z;
            string strTa, strTb;

            for (z = 0; z < (strA.Length - lngLen + 1); z++)
            {
                strTa = strA.Substring(z, lngLen);

                for (y = 0; y < (strB.Length - lngLen + 1); y++)
                {
                    strTb = strB.Substring(y, lngLen);


                    if (string.Equals(strTa, strTb, StringComparison.OrdinalIgnoreCase))
                    {
                        tretLngCountLike++;
                        break;
                    }
                }

                tretLngSubRows++;
            }

            return (tretLngSubRows, tretLngCountLike);
        }
    }
}
