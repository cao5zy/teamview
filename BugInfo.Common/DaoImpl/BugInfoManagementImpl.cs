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
using System.IO;
using BugInfo.Common.Logs;
using BugInfoManagement.Common;
using System.Diagnostics;
using FxLib.Algorithms;

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
            return QueryByParameter(
               null,
               null,
               null,
               null,
               null,
               null
                );
        }

        public List<BugInfoEntity> QueryByDealMan(String dealMan)
        {
            return QueryByParameter(
                new string[] { dealMan },
                null,
                null,
                null,
                null,
                null);
        }

        private Database CreateDataBase()
        {
            return DatabaseFactory.CreateDatabase("bug_Db");
        }

        public BugInfoEntity QueryByBugNum(String bugNum)
        {
            BugInfoEntity bugInfoEntity = new BugInfoEntity();

            DAL.BugInfo bugInfo = new DAL.BugInfo();
            bugInfo.LoadByKey(bugNum);
            if (bugInfo.IsLoaded)
            {
                bugInfoEntity.BugNum = bugInfo.BugNum;
                bugInfoEntity.Version = bugInfo.Version;
                bugInfoEntity.DealMan = bugInfo.DealMan;
                bugInfoEntity.Description = bugInfo.Description;
                bugInfoEntity.CreatedBy = bugInfo.CreatedMan;
                bugInfoEntity.Size = bugInfo.Size;
                bugInfoEntity.Priority = bugInfo.Priority;
                bugInfoEntity.TimeStamp = bugInfo.TimeStamp;
                bugInfoEntity.BugStatus = bugInfo.BugStatus;
            }
            else
                return null;

            bugInfoEntity.TotalHours = GetTotalHous(bugNum);
            bugInfoEntity.LevelHistroy = GetLevelHistroy(bugNum);
            return bugInfoEntity;
        }

        private string GetLevelHistroy(string bugNum)
        {
            return string.Join("\r\n",
            new DAL.PointslogCollection().Where("bugnum", bugNum).Load()
                .Select(n => PointsParser.ToPoint(n.Log))
                 .Select(n => n.EstimatedLevel + " " + n.EstimatedBy)
                 .ToArray());
        }

        private decimal GetTotalHous(string bugNum)
        {
            return this.mTaskRecordParser.Read(
            new DAL.ChangeLogCollection()
            .Where("bugnum", bugNum).Load()
            .Select(n =>
                string.Format("BugNum:{0};Time:{1};{2}", n.BugNum, n.CreateDate, n.Description))
            )
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
                CreatedBy = reader["createdMan"].ToString(),
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
            DAL.BugInfo bugInfo1 = new DAL.BugInfo();

            bugInfo1.Version = bugInfo.Version;
            bugInfo1.BugNum = bugInfo.BugNum;
            bugInfo1.BugStatus = bugInfo.BugStatus;
            bugInfo1.DealMan = bugInfo.DealMan;
            bugInfo1.Description = bugInfo.Description;
            bugInfo1.CreatedMan = bugInfo.CreatedBy;
            bugInfo1.Size = bugInfo.Size;
            bugInfo1.Priority = bugInfo.Priority;
            bugInfo1.TimeStamp = DateTime.Now;

            bugInfo1.Save();
        }



        public bool UpdateBugInfoByBugNum(BugInfoEntity bugInfo)
        {
            DAL.BugInfo bugInfo1 = new DAL.BugInfo();

            bugInfo1.LoadByKey(bugInfo.BugNum);

            Trace.Assert(bugInfo1.IsLoaded);

            bugInfo1.Version = bugInfo.Version;
            bugInfo1.BugStatus = bugInfo.BugStatus;
            bugInfo1.DealMan = bugInfo.DealMan;
            bugInfo1.Description = bugInfo.Description;
            bugInfo1.Size = bugInfo.Size;
            bugInfo1.Priority = bugInfo.Priority;

            bugInfo1.Save();

            return bugInfo1.Errors.Count == 0;
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
            return QueryByParameter(
                new string[] { dealMan },
                null,
                null,
                null,
                null,
                state);
        }

        public List<BugInfoEntity> QueryByStates(string state)
        {
            return QueryByParameter(
                null,
                null,
                null,
                null,
                null,
                state);
        }


        public List<BugInfoEntity> QueryByParameter(IEnumerable<string> programmers, 
            string bugNum, 
            string version, 
            string description, 
            int ? priority, 
            string bugState)
        {
            SubSonic.Query query = DAL.BugInfo.CreateQuery();
            query.QueryType = SubSonic.QueryType.Select;
            
            if (programmers.SafeCount() != 0)
                query = query.WHERE(
                    DAL.BugInfo.Columns.DealMan, SubSonic.Comparison.In, programmers
                    );

            if (!string.IsNullOrEmpty(bugNum))
                query = query.WHERE(DAL.BugInfo.Columns.BugNum, SubSonic.Comparison.Like, bugNum + "%");

            if (!string.IsNullOrEmpty(version))
                query = query.WHERE(
                    DAL.BugInfo.Columns.Version, version);

            if (!string.IsNullOrEmpty(description))
                query = query.WHERE(
                    DAL.BugInfo.Columns.Description,
                     SubSonic.Comparison.Like,
                     "%"+
                     description+"%");
            if (priority != null)
            {
                query = query.WHERE(
                    DAL.BugInfo.Columns.Priority, 
                    SubSonic.Comparison.LessOrEquals,
                    priority.Value);
            }

            if (!string.IsNullOrEmpty(bugState))
            {
                query = query.WHERE(DAL.BugInfo.Columns.BugStatus, bugState);
            }

            return ToList(query.ExecuteReader());
        }

        private List<BugInfoEntity> ToList(IDataReader reader)
        {
            List<BugInfoEntity> list = new List<BugInfoEntity>();

            while (reader.Read())
            {
                list.Add(
                    new BugInfoEntity { 
                        BugNum = reader[DAL.BugInfo.Columns.BugNum].ToString(),
                        BugStatus = reader[DAL.BugInfo.Columns.BugStatus].ToString(),
                        CreatedBy = reader[DAL.BugInfo.Columns.CreatedMan].ToString(),
                        DealMan = reader[DAL.BugInfo.Columns.DealMan].ToString(),
                        Description = reader[DAL.BugInfo.Columns.Description].ToString(),
                        Priority = Convert.ToInt16(reader[DAL.BugInfo.Columns.Priority]),
                        Size = Convert.ToInt32(reader[DAL.BugInfo.Columns.Size]),
                        TimeStamp = Convert.ToDateTime(reader[DAL.BugInfo.Columns.TimeStamp]),
                        Version = reader[DAL.BugInfo.Columns.Version].ToString()
                    }
                    );
            }

            return list;
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
            DAL.ChangeLog changeLog = new DAL.ChangeLog();

            changeLog.BugNum = bugNum;
            changeLog.Description = Log;
            changeLog.CreateDate = DateTime.Now;

            changeLog.Save();
        }

        public void AssignPoints(string bugNum, string log)
        {
            DAL.Pointslog pointLog = new DAL.Pointslog();

            pointLog.Bugnum = bugNum;
            pointLog.Log = log;
            pointLog.Createdtime = DateTime.Now;

            pointLog.Save();

        }


        #region IBugInfoManagement Members


        public bool TryToUpdate(string bugNum, DateTime timeStamp, out DateTime newTimeStamp)
        {
            newTimeStamp = DateTime.MinValue;

            DAL.BugInfo bugInfo = new DAL.BugInfoCollection()
            .Where("bugnum", bugNum)
            .Where("timeStamp", timeStamp)
            .Load()
            .FirstOrDefault();



            Trace.Assert(bugInfo != null);

            bugInfo.TimeStamp = DateTime.Now;
            bugInfo.Save();

            newTimeStamp = bugInfo.TimeStamp;

            return bugInfo.Errors.Count == 0;

        }

        #endregion

        public List<BugInfoEntity> QueryByProgrammerStatus(string programmer, string status)
        {
            DAL.BugInfoCollection bugInfoCol = new DAL.BugInfoCollection();


            bugInfoCol = bugInfoCol.Where(
                DAL.BugInfo.Columns.DealMan, programmer
                )
                .Where(DAL.BugInfo.Columns.BugStatus, status);


            return bugInfoCol.Load().SafeConvertAll(
                n => ConvertToBugInfoEntity(n)
                );

        }

        private static BugInfoEntity ConvertToBugInfoEntity(DAL.BugInfo n)
        {
            return new BugInfoEntity
            {
                BugStatus = n.BugStatus,
                Description = n.Description,
                CreatedBy = n.CreatedMan,
                DealMan = n.DealMan,
                BugNum = n.BugNum,
                Version = n.Version,
                Size = n.Size,
                Priority = n.Priority,
                TimeStamp = n.TimeStamp,
            };
        }

    }
}
