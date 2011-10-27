using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL1.Common;
using FxLib.Algorithms;

namespace BugInfo.Common.Logs
{
    class BugLogReader : ObjectBaseReader<LogRecord>
    {

        public BugLogReader() : base("select LogID, BugNum, CreateDate, Description from changelog ") { }
        protected override LogRecord ConvertObject(System.Data.SqlClient.SqlDataReader dataReader)
        {
            return new LogRecord { 
                LogID = Convert.ToInt64(dataReader[0]),
                Record = string.Format("BugNum:{0};Time:{1};{2}",dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString()),
            };
        }

        public IEnumerable<string> GetLogList(string bugNum)
        {
            base.AddParameter("BugNum", "BugNum", bugNum);

            return base.ToList().SafeSort(n => n.Add(m => m.LogID))
                .SafeConvertAll(n => n.Record);
        }
    }
}
