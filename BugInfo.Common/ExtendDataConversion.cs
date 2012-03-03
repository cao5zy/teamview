using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common
{
    public static class ExtendDataConversion
    {
        public static int ToInt32(this object value)
        {
            if (value == null || Convert.IsDBNull(value))
                return 0;
            else
                return Convert.ToInt32(value);
        }

        public static DateTime ToDateTime(this object value)
        {
            if (value == null || Convert.IsDBNull(value))
                return DateTime.MinValue;
            else
                return Convert.ToDateTime(value);
        }

        public static decimal ToDecimal(this object value)
        {
            if (value == null || Convert.IsDBNull(value))
                return 0;
            else
                return Convert.ToDecimal(value);
        }
    }
}
