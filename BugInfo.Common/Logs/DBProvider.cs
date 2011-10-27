using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL1.Common;
using BugInfo.Common.Entity;
using System.Data;
using System.Configuration;
using System.Transactions;

namespace BugInfo.Common.Logs
{
    public class DBProvider : IDbProvider
    {
        private SqlConnection Connection { get; set; }

        public DBProvider(SqlConnection connection)
        {
            Connection = connection;
        }
        #region IDbProvider Members

        public IEnumerable<DbItem> Read(string userName)
        {
            Connection.Open();
            try
            {
                DBContext context = new DBContext(Connection, null);
                return context.CreateReader<DBItemReader>().Search(userName);
            }
            finally
            {
                Connection.Close();
            }
        }

        #endregion

        #region IDbProvider Members


        public IEnumerable<string> ReadBugNums(DateTime start, DateTime end)
        {
            Connection.Open();
            try
            {
                DBContext context = new DBContext(Connection, null);
                return context.CreateReader<BugNumLogReader>().SearchBugNumByDateRange(start, end);
            }
            finally
            {
                Connection.Close();
            }
        }

        public IEnumerable<string> ReadBugLog(string bugNum)
        {
            Connection.Open();
            try
            {
                DBContext context = new DBContext(Connection, null);
                return context.CreateReader<BugLogReader>().GetLogList(bugNum);
            }
            finally
            {
                Connection.Close();
            }
        }

        #endregion

        #region IDbProvider Members


        public IEnumerable<ProgrammerPoint> ReadPoints(string bugNum)
        {
            Connection.Open();
            try
            {
                DBContext context = new DBContext(Connection, null);
                return context.CreateReader<PointsLogReader>().GetPointList(bugNum);
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion
    }
}
