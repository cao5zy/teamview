using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TeamView.Common.Entity;
using System.Data;
using System.Configuration;
using System.Transactions;

namespace TeamView.Common.Logs
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

        public IEnumerable<LogEntity> ReadBugLog(string bugNum)
        {
            var query = DAL.ChangeLog.CreateQuery()
                .AddWhere(DAL.ChangeLog.Columns.BugNum, bugNum);
            query.OrderBy = SubSonic.OrderBy.Asc(DAL.ChangeLog.Columns.CreateDate);

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new LogEntity { 
                        ItemId = reader[DAL.ChangeLog.Columns.BugNum].ToString(),
                        CreatedDate = Convert.ToDateTime(reader[DAL.ChangeLog.Columns.CreateDate]),
                        Description = reader[DAL.ChangeLog.Columns.Description].ToString(),
                        MoveSequence = Convert.ToInt32(reader[DAL.ChangeLog.Columns.MoveSequence]),
                        LogTypeId = Convert.ToInt32(reader[DAL.ChangeLog.Columns.LogID]),

                    };
                }
            }
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
