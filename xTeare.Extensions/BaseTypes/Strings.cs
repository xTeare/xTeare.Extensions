using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xTeare.Extensions.BaseTypes
{
    public static class Strings
    {
        public static string Between(this string Original, string A, string B, bool RemoveWhiteSpaces = true, bool IgnoreCase = false)
        {
            int num1 = Original.IndexOf(A, (IgnoreCase)?StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
            int num2 = Original.LastIndexOf(B, (IgnoreCase) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

            if (num1 == -1)
                return "";

            if (num2 == -1)
                return "";

            int adjustedPosA = num1 + A.Length;

            if (adjustedPosA >= num2)
                return "";

            string ret = Original.Substring(adjustedPosA, num2 - adjustedPosA);

            if (RemoveWhiteSpaces &&char.IsWhiteSpace(ret[0]))
                ret = ret.Substring(1);

            if (RemoveWhiteSpaces && char.IsWhiteSpace(ret[ret.Length - 1]))
                ret = ret.Substring(0, ret.Length - 1);

            return ret;
        }
    }
}
