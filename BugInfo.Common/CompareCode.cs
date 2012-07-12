using System;
using System.Collections.Generic;
using System.Text;

namespace FxLib.Algorithms
{
    public class CompareCode<T>
    {
        public CompareCode() { }
        private List<Func<T, T, int>> mCompareResultList = new List<Func<T, T, int>>();
        public CompareCode(CompareCode<T> compareCode)
        {
            mCompareResultList.AddRange(compareCode.mCompareResultList);
        }
        public CompareCode<T> Add<T1>(Converter<T, T1> selector) where T1 : IComparable
        {
            mCompareResultList.Add((n1, n2) => Comparer<T1>.Default.Compare(selector(n1), selector(n2)));
            return new CompareCode<T>(this);
        }
        public int Compare(T value1, T value2)
        {
            foreach (var fun in mCompareResultList)
            {
                int ret = fun(value1, value2);
                if (ret != 0)
                    return ret;
            }

            return 0;
        }
    }

}
