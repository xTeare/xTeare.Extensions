using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xTeare.Extensions.BaseTypes
{
    public static class Strings
    {
        /// <summary>
        /// Takes a string and returns the value between two other strings
        /// </summary>
        /// <param name="Original">The original string</param>
        /// <param name="Start">Start string</param>
        /// <param name="End">End string</param>
        /// <param name="RemoveWhiteSpaces">Whitespaces at the start and end will be removed if true</param>
        /// <param name="IgnoreCase">Cases will be ignored if true</param>
        /// <returns></returns>
        public static string Between(this string Original, string Start, string End, bool RemoveWhiteSpaces = true, bool IgnoreCase = false)
        {
            int num1 = Original.IndexOf(Start, (IgnoreCase)?StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
            int num2 = Original.LastIndexOf(End, (IgnoreCase) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

            if (num1 == -1)
                return "";

            if (num2 == -1)
                return "";

            int adjustedPosA = num1 + Start.Length;

            if (adjustedPosA >= num2)
                return "";

            string ret = Original.Substring(adjustedPosA, num2 - adjustedPosA);



            if (ret.Length > 0 && RemoveWhiteSpaces && char.IsWhiteSpace(ret[0]))
                ret = ret.Substring(1);

            if (ret.Length > 1 && RemoveWhiteSpaces && char.IsWhiteSpace(ret[ret.Length - 1]))
                ret = ret.Substring(0, ret.Length - 1);

            return ret;
        }
    }
}
