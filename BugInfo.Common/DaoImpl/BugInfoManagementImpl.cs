using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BugInfoManagement.Dao;
using BugInfoManagement.Entity;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FxLib.Algorithms;
using System.IO;
using BugInfo.Common.Logs;

namespace BugInfoManagement.DaoImpl
{
    public class BugInfoManagementImpl : IBugInfoManagement
    {
        private IDbProvider mDbProvider;
        private TaskRecordParser mTaskRecordParser;
        public BugInfoManagementImpl(
            IDbProvider dbProvider,
            TaskRecordParser taskRecordParser
            )
        {
            mDbProvider = dbProvider;
            mTaskRecordParser = taskRecordParser;
        }
        public List<BugInfoEntity> QueryAll()
        {
            return QueryByParameter(new QueryParameter { });
        }

        public List<BugInfoEntity> QueryByDealMan(String dealMan)
        {
            return QueryByParameter(new QueryParameter
            {
                Programmer = dealMan
            });
        }

        private Database CreateDataBase()
        {
            return DatabaseFactory.CreateDatabase("bug_Db");
        }

        public BugInfoEntity QueryByBugNum(String bugNum)
        {
            var database = CreateDataBase();

            var cmd = database.GetSqlStringCommand(@"select version,bugNum,bugStatus,dealMan,description,dbo.MergeLog(bugNum) as disposeResult,createdBy,size,timeStamp,priority
                from bugInfo where bugNum=@bugnum");

            database.AddInParameter(cmd, "@bugnum", DbType.String, bugNum);

            BugInfoEntity bugInfoEntity = null;
            using (var reader = database.ExecuteReader(cmd))
            {
                var func = BuildRead(reader);
                if (reader.Read())
                {
                    bugInfoEntity = func();
                }
                else
                    return null;
            }

            bugInfoEntity.TotalHours = GetTotalHous(bugNum);
            bugInfoEntity.LevelHistroy = GetLevelHistroy(bugNum);
            return bugInfoEntity;
        }

        private string GetLevelHistroy(string bugNum)
        {
            return string.Join("\r\n",
            this.mDbProvider.ReadPoints(bugNum)
                .SafeConvertAll(n => n.EstimatedLevel + " " + n.EstimatedBy)
                .ToArray());
        }

        private decimal GetTotalHous(string bugNum)
        {
            return this.mTaskRecordParser.Read(
            this.mDbProvider.ReadBugLog(bugNum))
            .Sum(n => n.Duration);
        }

        private Func<BugInfoEntity> BuildRead(IDataReader reader)
        {
            return new Func<BugInfoEntity>(() => new BugInfoEntity
            {
                BugNum = reader["bugNum"].ToString(),
                Version = reader["version"].ToString(),
                DealMan = reader["dealMan"].ToString(),
                Description = reader["description"].ToString(),
                DisposeResult = reader["disposeResult"].ToString(),
                CreatedBy = reader["createdBy"].ToString(),
                Size = Convert.ToInt32(reader["size"]),
                Priority = Convert.ToInt16(reader["priority"]),
                TimeStamp = Convert.ToDateTime(reader["timeStamp"]),
                BugStatus = reader["bugStatus"].ToString()

            });
        }

        public void DeleteByBugNum(String bugNum)
        {
            CreateDataBase().GetSqlStringCommand("delete from bugInfo where bugNum ='" + bugNum + "'")
                .ExecuteNonQuery();
        }

        public void AddBugInfo(BugInfoEntity bugInfo)
        {
            var db = CreateDataBase();
            String addBugInfoString = @"insert into bugInfo (version,bugNum,bugStatus,dealMan,description,createdBy,size,priority) 
                                                            VALUES (@version,@bugnum,@bugstatus,@dealman,
                                                                @description,@createdBy,
                                                                @size,
                                                                @priority)";
            var cmd = db.GetSqlStringCommand(addBugInfoString);

            db.AddInParameter(cmd, "@version", DbType.String, bugInfo.Version);
            db.AddInParameter(cmd, "@bugnum", DbType.String, bugInfo.BugNum);
            db.AddInParameter(cmd, "@bugstatus", DbType.String, bugInfo.BugStatus);
            db.AddInParameter(cmd, "@dealman", DbType.String, bugInfo.DealMan);
            db.AddInParameter(cmd, "@description", DbType.String, bugInfo.Description);
            db.AddInParameter(cmd, "@createdBy", DbType.String, bugInfo.CreatedBy);
            db.AddInParameter(cmd, "@size", DbType.Int16, bugInfo.Size);
            db.AddInParameter(cmd, "@priority", DbType.Int16, bugInfo.Priority);

            db.ExecuteNonQuery(cmd);
        }



        public bool UpdateBugInfoByBugNum(BugInfoEntity bugInfo)
        {
            var db = CreateDataBase();

            String updateBugInfoString = @"update bugInfo set version = @version
                ,bugStatus = @bugstatus
                ,dealMan = @dealMan
                ,description = @description
                ,size = @size
                ,priority = @priority
                where bugNum = @bugNum";

            var cmd = db.GetSqlStringCommand(updateBugInfoString);

            db.AddInParameter(cmd, "@version", DbType.String, bugInfo.Version);
            db.AddInParameter(cmd, "@bugstatus", DbType.String, bugInfo.BugStatus);
            db.AddInParameter(cmd, "@dealMan", DbType.String, bugInfo.DealMan);
            db.AddInParameter(cmd, "@description", DbType.String, bugInfo.Description);
            db.AddInParameter(cmd, "@size", DbType.Int16, bugInfo.Size);
            db.AddInParameter(cmd, "@priority", DbType.Int16, bugInfo.Priority);
            db.AddInParameter(cmd, "@bugNum", DbType.String, bugInfo.BugNum);


            return db.ExecuteNonQuery(cmd) != 0;
        }

        public void UpdateBugDetail(string bugNum, byte[] detailsBuffer)
        {

            UpdateImageColumn("bugInfo", "detailDoc", "bugNum", bugNum, detailsBuffer);
        }

        private void UpdateImageColumn(string tableName, string columnName, string keyName,
            string keyValue, byte[] buffer)
        {
            var db = CreateDataBase();
            string sqlFormat = "Update {0} set {1}=@buffer where {2}=@keyValue";

            var cmd = db.GetSqlStringCommand(string.Format(sqlFormat, tableName, columnName, keyName));

            db.AddInParameter(cmd, "@buffer", DbType.Binary, buffer);
            db.AddInParameter(cmd, "@keyValue", DbType.String, keyValue);

            db.ExecuteNonQuery(cmd);

        }


        public void GetBugDetail(string bugNum, System.IO.MemoryStream memo)
        {

            GetImageColumn("bugInfo", "detailDoc", "bugNum", bugNum, memo);
        }

        private void GetImageColumn(string tableName, string columnName, string keyName, string keyValue, MemoryStream memo)
        {
            var db = CreateDataBase();

            string sqlFormat = "select {0} from {1} where {2}=@keyValue";

            var cmd = db.GetSqlStringCommand(string.Format(sqlFormat, columnName, tableName, keyName));

            db.AddInParameter(cmd, "@keyValue", DbType.String, keyValue);

            byte[] bts = (byte[])db.ExecuteScalar(cmd);

            try
            {

                if (bts != null)
                    memo.Write(bts, 0, bts.Length);
            }
            finally
            {
                Array.Resize(ref bts, 0);
            }
        }

        public List<BugInfoEntity> Query(string dealMan, string state)
        {
            return QueryByParameter(new QueryParameter
            {
                Programmer = dealMan,
                Status = state
            });
        }

        public List<BugInfoEntity> QueryByStates(string state)
        {
            return QueryByParameter(new QueryParameter { Status = state });
        }


        public List<BugInfoEntity> QueryByParameter(QueryParameter parameter)
        {
            WhereGenerator g = new WhereGenerator(parameter);


            List<BugInfoEntity> list = new List<BugInfoEntity>();
            String queryByDealManString = @"select version,bugNum,bugStatus,dealMan,description,dbo.MergeLog(bugNum) as disposeResult,createdBy,size,timeStamp,priority
                from bugInfo where " + ((string.IsNullOrEmpty(g.WhereClause) ? "1=1" : g.WhereClause)
                                     + " order by priority, timeStamp desc");

            var db = CreateDataBase();

            var cmd = db.GetSqlStringCommand(queryByDealManString);

            using (var reader = db.ExecuteReader(cmd))
            {

                var func = BuildRead(reader);

                while (reader.Read())
                    list.Add(func());
                return list;
            }
        }

        public IEnumerable<string> SearchBugNumByDateRange(DateTime start, DateTime end)
        {
            var database = CreateDataBase();
            var command = database.GetSqlStringCommand(@"select distinct bugnum
from ChangeLog
where CreateDate >= @start and CreateDate <= @end");
            database.AddInParameter(command,
                "@start", DbType.DateTime, start);
            database.AddInParameter(command,
                "@end", DbType.DateTime, end);

            List<string> bugNumList = new List<string>();

            using (var reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                    bugNumList.Add(reader[0].ToString());
            }

            return bugNumList;
        }

        public void AddLog(string bugNum, string Log)
        {
            var db = CreateDataBase();

            String addBugInfoString = @"insert into changelog (bugNum,Description) 
                values(@bugnum,@description)";

            var cmd = db.GetSqlStringCommand(addBugInfoString);

            db.AddInParameter(cmd, "@bugnum", DbType.String, bugNum);
            db.AddInParameter(cmd, "@description", DbType.String, Log);

            db.ExecuteNonQuery(cmd);
        }

        public void AssignPoints(string bugNum, string log)
        {
            var db = CreateDataBase();

            var cmd = db.GetSqlStringCommand(@"insert into pointslog (bugnum, log, createdtime)
                        values(@bugnum, @log, @createdtime)");

            db.AddInParameter(cmd, "@bugnum", DbType.String, bugNum);
            db.AddInParameter(cmd, "@log", DbType.String, log);
            db.AddInParameter(cmd, "@createdtime", DbType.DateTime, DateTime.Now);

            db.ExecuteNonQuery(cmd);
        }


        #region IBugInfoManagement Members


        public bool TryToUpdate(string bugNum, DateTime timeStamp, out DateTime newTimeStamp)
        {
            var db = CreateDataBase();

            newTimeStamp = DateTime.MinValue;

            var cmd = db.GetSqlStringCommand(@"update buginfo set timeStamp = getdate()
                                where bugnum = @bugnum and timeStamp = @timeStamp
                                if(@@ROWCOUNT = 1)
                                begin
                                    select @newtimestamp = timeStamp from buginfo where bugnum = @bugnum
                                    select 1
                                end
                                else
                                    select 0");

            db.AddInParameter(cmd, "@bugnum", DbType.String, bugNum);
            db.AddInParameter(cmd, "@timeStamp", DbType.DateTime, timeStamp);
            db.AddOutParameter(cmd, "@newtimestamp", DbType.DateTime, 64);


            if (db.ExecuteNonQuery(cmd) == 1)
            {
                newTimeStamp = Convert.ToDateTime(db.GetParameterValue(cmd, "@newtimestamp"));
                return true;
            }
            else
                return false;
        }

        #endregion
    }
}
