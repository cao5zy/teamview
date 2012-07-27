using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;
using System.Configuration;
using System.Data.SqlClient;
using Dev3Lib.Sql;

namespace TeamView.Common.DaoImpl
{
    class BugInfoRepository : IBugInfoRepository
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["bug_Db"].ConnectionString;

        #region IBugInfoRepository Members

        public TeamView.Common.Entity.BugInfoEntity1 GetItem(string itemId)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();

                SqlTableSelectCmd cmd = new SqlTableSelectCmd(conn, "bugInfo");
                cmd.AddParameterWithValue("bugnum", itemId);

                return cmd.ExecuteList<TeamView.Common.Entity.BugInfoEntity1>(reader => new TeamView.Common.Entity.BugInfoEntity1
                {
                    version = Convert.IsDBNull(reader["version"]) ? string.Empty : Convert.ToString(reader["version"]),
                    bugNum = Convert.IsDBNull(reader["bugNum"]) ? string.Empty : Convert.ToString(reader["bugNum"]),
                    bugStatus = Convert.IsDBNull(reader["bugStatus"]) ? string.Empty : Convert.ToString(reader["bugStatus"]),
                    dealMan = Convert.IsDBNull(reader["dealMan"]) ? string.Empty : Convert.ToString(reader["dealMan"]),
                    createdTime = Convert.IsDBNull(reader["createdTime"]) ? System.DateTime.Now : Convert.ToDateTime(reader["createdTime"]),
                    description = Convert.IsDBNull(reader["description"]) ? string.Empty : Convert.ToString(reader["description"]),
                    size = Convert.IsDBNull(reader["size"]) ? 0 : Convert.ToInt32(reader["size"]),
                    fired = Convert.IsDBNull(reader["fired"]) ? 0 : Convert.ToInt32(reader["fired"]),
                    timeStamp = Convert.IsDBNull(reader["timeStamp"]) ? System.DateTime.Now : Convert.ToDateTime(reader["timeStamp"]),
                    priority = Convert.IsDBNull(reader["priority"]) ? 0 : Convert.ToInt16(reader["priority"]),
                    hardLevel = Convert.IsDBNull(reader["hardLevel"]) ? 0 : Convert.ToInt16(reader["hardLevel"]),
                    latestStartTime = Convert.IsDBNull(reader["latestStartTime"]) ? System.DateTime.Now : Convert.ToDateTime(reader["latestStartTime"]),
                })
                    .SingleOrDefault();
            }
        }

        public void UpdateItem(TeamView.Common.Entity.BugInfoEntity1 item)
        {
            DAL.BugInfoCollection coll = new DAL.BugInfoCollection();
            var dbItem = coll.Where(DAL.BugInfo.Columns.BugNum, item.bugNum)
                .Load()
                .FirstOrDefault();
            DateTime timeStamp = DateTime.Now;

            if (dbItem == null)
            {
                DAL.BugInfo bugInfo = new DAL.BugInfo();
                bugInfo.BugNum = item.bugNum;
                bugInfo.BugStatus = item.bugStatus;
                bugInfo.CreatedTime = item.createdTime;
                bugInfo.DealMan = item.dealMan;
                bugInfo.Description = item.description;
                bugInfo.Fired = item.fired;
                bugInfo.HardLevel = (short)item.hardLevel;
                bugInfo.Priority = (short)item.priority;
                bugInfo.Size = item.size;
                bugInfo.Version = item.version;
                if (item.latestStartTime == DateTime.MinValue)
                    bugInfo.LatestStartTime = null;
                else
                    bugInfo.LatestStartTime = item.latestStartTime;
                bugInfo.TimeStamp = timeStamp;
                bugInfo.Save();
            }
            else
            {
                dbItem.BugStatus = item.bugStatus;
                dbItem.CreatedTime = item.createdTime;
                dbItem.DealMan = item.dealMan;
                dbItem.Description = item.description;
                dbItem.Fired = item.fired;
                dbItem.HardLevel = (short)item.hardLevel;
                dbItem.Priority = (short)item.priority;
                dbItem.Size = item.size;
                dbItem.Version = item.version;
                if (item.latestStartTime == DateTime.MinValue)
                    dbItem.LatestStartTime = null;
                else
                    dbItem.LatestStartTime = item.latestStartTime;
                dbItem.TimeStamp = timeStamp;
                dbItem.Save();
            }


            item.timeStamp = timeStamp;

        }

        public long? GetCurrentKeyValue(string keyName)
        {
            DAL.KeyInfo keyInfo = new DAL.KeyInfo();
            keyInfo.LoadByKey(keyName);
            if (!keyInfo.IsLoaded)
                return null;
            else
                return keyInfo.Num;
        }

        public void UpdateKeyValue(string keyName, long newVal)
        {
            DAL.KeyInfo keyInfo = new DAL.KeyInfo();

            keyInfo.LoadByKey(keyName);

            if (!keyInfo.IsLoaded)
                throw new ArgumentException(string.Format("{0} is not existing in the db", keyName));

            keyInfo.Num = newVal;

            keyInfo.Save();

        }

        public void InsertKeyValue(string keyName, long val)
        {
            DAL.KeyInfo keyInfo = new DAL.KeyInfo();
            keyInfo.KeyName = keyName;
            keyInfo.Num = val;

            keyInfo.Save();
        }

        public void SaveDoc(string itemId, byte[] stream)
        {
            DAL.BugInfo bugInfo = new DAL.BugInfo();
            bugInfo.LoadByKey(itemId);
            if (bugInfo.IsLoaded)
            {
                bugInfo.Doc = stream;
            }

            bugInfo.Save();
        }

        public byte[] LoadDoc(string itemId)
        {
            DAL.BugInfo bugInfo = new DAL.BugInfo();
            bugInfo.LoadByKey(itemId);
            if (!bugInfo.IsLoaded || bugInfo.Doc == null)
                return new byte[] { };
            else
                return bugInfo.Doc;
        }

        #endregion
        public bool IsLargestOrder(string itemId)
        {
            return new DAL.BugInfoCollection()
            .Where(DAL.BugInfo.Columns.BugNum, itemId)
            .Load()
            .Count == 0;
        }


        public bool CheckDealManStatus(string dealMan, string bugStatus)
        {
            DAL.BugInfoCollection coll = new DAL.BugInfoCollection();
            return coll.Where(DAL.BugInfo.Columns.DealMan, dealMan)
                .Where(DAL.BugInfo.Columns.BugStatus, bugStatus).Load().Count != 0;
        }


        public void AddLog(string bugNum, string desc, int logTypeId)
        {
            DAL.ChangeLog changeLog = new DAL.ChangeLog();
            changeLog.BugNum = bugNum;
            changeLog.Description = desc;
            changeLog.LogTypeID = logTypeId;
            changeLog.CreateDate = DateTime.Now;

            changeLog.Save();
        }


        public bool CheckTimeStamp(string itemId, DateTime timeStamp)
        {
            DAL.BugInfoCollection coll = new DAL.BugInfoCollection();
            return coll.Where(DAL.BugInfo.Columns.BugNum, itemId)
                .Where(DAL.BugInfo.Columns.TimeStamp, timeStamp)
                .Load()
                .FirstOrDefault() != null;
        }


        public bool HasLog(string bugNum)
        {
            return new DAL.ChangeLogCollection()
                .Where(DAL.ChangeLog.Columns.BugNum, bugNum)
                .Load()
                .Count != 0;
        }
    }
}
