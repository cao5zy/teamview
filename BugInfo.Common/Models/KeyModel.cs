using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;
using System.Transactions;
using System.Text.RegularExpressions;

namespace TeamView.Common.Models
{
    public class KeyModel
    {
        private IBugInfoRepository _repository;
        private static Regex mItemIdReg = new Regex(@"^(\w+)\-([1-9]\d*|\*)(\:\d+)?$");
        public KeyModel(IBugInfoRepository repository)
        {
            _repository = repository;
        }

        public string GenerateKey(string keyName)
        {
            string key = mItemIdReg.Match(keyName).Groups[1].Value.ToUpper();

            using (TransactionScope trans = new TransactionScope())
            {
                long? value = _repository.GetCurrentKeyValue(key);

                if (value.HasValue)
                {
                    long val = value.Value;
                    _repository.UpdateKeyValue(keyName, ++val);
                    trans.Complete();
                    return key + "-" + val.ToString();
                }
                else
                {
                    _repository.InsertKeyValue(key, 1);
                    trans.Complete();
                    return key + "-1";
                }
            }
        }

        public static bool IsKeyFormat(string keyName)
        {
            return mItemIdReg.Match(keyName).Success;
        }

        public static bool IsCompleteKey(string keyName)
        {
            var match = mItemIdReg.Match(keyName);
            if (!match.Success)
                return false;

            if (match.Groups[2].Value == "*")
                return false;
            else
                return true;
        }

        public static string GetKey(string keyValue)
        {
            var match = mItemIdReg.Match(keyValue);
            if (!match.Success)
                return string.Empty;

            if (!match.Groups[3].Success)
                return keyValue;
            else
                return keyValue.Substring(0, match.Groups[3].Index);
        }

        public static string ComposeKey(string key, int order)
        {
            return key + ":" + order.ToString();
        }

        public static int GetKeyOrder(string keyValue)
        {
            int defaultVal = 0;
            var match = mItemIdReg.Match(keyValue);
            if (!match.Success)
                return defaultVal;

            if (!match.Groups[3].Success)
                return defaultVal;
            else
                return Convert.ToInt32(keyValue.Substring(match.Groups[3].Index, match.Groups[3].Length - 1));
        }
    }
}
