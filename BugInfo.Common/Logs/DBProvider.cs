using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BugInfo.Common.Entity;
using System.Data;
using System.Configuration;
using System.Transactions;

namespace BugInfo.Common.Logs
{
    public class DBProvider : IDbProvider
    {
        #region IDbProvider Members

        public IEnumerable<DbItem> Read(string userName)
        {
            return new DBItemReader().Search(userName);
        }

        #endregion

        #region IDbProvider Members


        public IEnumerable<string> ReadBugNums(DateTime start, DateTime end)
        {
            return new BugNumLogReader().SearchBugNumByDateRange(start, end);
        }

        public IEnumerable<string> ReadBugLog(string bugNum)
        {
            return new BugLogReader().GetLogList(bugNum);
        }

        #endregion

        #region IDbProvider Members


        public IEnumerable<ProgrammerPoint> ReadPoints(string bugNum)
        {
            return new PointsLogReader().GetPointList(bugNum);
        }
        #endregion
    }
}
