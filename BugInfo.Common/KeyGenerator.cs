using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FxLib
{
    public class KeyGenerator<EnumT>
    {

        class IDPair<TKey, TValue> {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        public KeyGenerator()
        {
            if (!typeof(EnumT).IsEnum)
                throw new ArgumentException("Inalid Enum type");


        }

        private readonly KeyGenerator<EnumT> mPreGenerator;
        public KeyGenerator(KeyGenerator<EnumT> generator)
        {
            mPreGenerator = generator;
        }

        private const string CODEFORMAT = "{0}:{1}";
        private string mValues = string.Empty;

        public KeyGenerator<EnumT> Add(EnumT type, string value)
        {
            mValues = string.Format(CODEFORMAT, global::System.Enum.GetName(typeof(EnumT), type), EncodeValue(value));
            return new KeyGenerator<EnumT>(this);
        }

        public string ToValues()
        {
            if (mPreGenerator == null)
                return mValues;
            else
            {
                if (string.IsNullOrEmpty(mValues))
                    return mPreGenerator.ToValues();
                else
                    return mValues + "," + mPreGenerator.ToValues();
            }
        }

        private const string DECODEFORMAT = @"(\w+):(\w+)";
        private const string DECODEFORMAT1 = @"(\w+):(\s*)";
        public IDictionary<EnumT, string> ToDictionary(string values)
        {
            var dic = new Dictionary<EnumT, string>();
            List<IDPair<EnumT, string>> list = new List<IDPair<EnumT, string>>();
            if (string.IsNullOrEmpty(values))
                return dic;

            foreach (EnumT val in global::System.Enum.GetValues(typeof(EnumT)))
            {
                dic.Add(val, string.Empty);
            }

            var spliters = new List<string>(Regex.Split(values, @"(?<!\\),"));
            spliters.ForEach(
               value =>
               {
                   var match = Regex.Match(value, DECODEFORMAT);
                   if (!match.Success)
                   {
                       match = Regex.Match(value, DECODEFORMAT1);
                       if (!match.Success)
                           throw new Exception(string.Format("Invalid format {0}", value));
                   }

                   dic[(EnumT)global::System.Enum.Parse(typeof(EnumT), match.Groups[1].Value)] = DecodeValue(match.Groups[2].Value);
               }
               );

            return dic;
        }

        private static string EncodeValue(string values)
        {
            values = values.Replace(":", @"\:");
            values = values.Replace(",", @"\,");
            return values;
        }

        private static string DecodeValue(string values)
        {
            values = values.Replace(@"\:", ":");
            values = values.Replace(@"\,", ",");
            return values;

        }
    }
}
