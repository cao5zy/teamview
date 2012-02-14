using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TeamView.Common.Models
{
    static class ItemIdHelper
    {
        static Regex mItemIdReg = new Regex(@"^([^_]+)_(\d+)$");

        public static bool IsValidItemNum(this string value)
        {
            return mItemIdReg.IsMatch(value);
        }

        public static string GetItemNum(this string value)
        {
            var match = mItemIdReg.Match(value);
            if (!match.Success)
                return string.Empty;

            return match.Groups[1].Value;
        }

        public static string GetItemOrder(this string value)
        {
            var match = mItemIdReg.Match(value);
            if (!match.Success)
                return string.Empty;

            return match.Groups[2].Value;
        }

        public static string ComposeItemId(string itemNum, int order)
        {
            if(order <= 0)
                return itemNum;
            else
                return itemNum + "_" + order.ToString();
        }
        }
    }
}
