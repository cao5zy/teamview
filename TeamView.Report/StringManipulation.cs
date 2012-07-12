using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report
{
    static class StringManipulation
    {
        public static string RemoveNewLine(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            else
                return str.Replace("\r\n", string.Empty);

        }
    }
}
