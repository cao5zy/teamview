using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;

namespace TeamView.Common.DaoImpl
{
    class BugInfoRepository : IBugInfoRepository
    {
        #region IBugInfoRepository Members

        public TeamView.Common.Entity.BugInfoEntity1 GetItem(string itemId, int moveSequence)
        {
            DAL.BugInfoCollection coll = new DAL.BugInfoCollection();
            var obj = coll.Where(DAL.BugInfo.Columns.BugNum, itemId)
                .Where(DAL.BugInfo.Columns.MoveSequence, moveSequence)
                .Load()
                .FirstOrDefault();

            if (obj == null)
                return null;
            else
                return new TeamView.Common.Entity.BugInfoEntity1 { 
                    bugNum = obj.BugNum,
                    bugStatus = obj.BugStatus,
                    createdTime = obj.CreatedTime,
                    dealMan = obj.DealMan,
                    description = obj.Description,
                    fired = obj.Fired,
                    hardLevel = obj.HardLevel,
                    moveSequence =obj.MoveSequence,
                    priority = obj.Priority,
                    size = obj.Size,
                    timeStamp = obj.TimeStamp,
                    version = obj.Version
                };
            
        }

        public DateTime SaveChangedState(string itemId, int moveSequence, string bugStatus, DateTime timeStamp)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(TeamView.Common.Entity.BugInfoEntity1 item)
        {
            DAL.BugInfoCollection coll = new DAL.BugInfoCollection();
            var dbItem = coll.Where(DAL.BugInfo.Columns.BugNum, item.bugNum)
                .Where(DAL.BugInfo.Columns.MoveSequence, item.moveSequence)
                .Load()
                .FirstOrDefault();
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
                bugInfo.MoveSequence = item.moveSequence;
                bugInfo.Priority = (short)item.priority;
                bugInfo.Size = item.size;
                bugInfo.Version = item.version;

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

                dbItem.Save();
            }
        }

        public DateTime GetLastestStartTime(string itemId, int sequence)
        {
            throw new NotImplementedException();
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
            DAL.BugDoc doc = new DAL.BugDoc();
            doc.LoadByKey(itemId);
            if (!doc.IsLoaded)
            {
                doc.BugNum = itemId;
                doc.Save();
                doc.LoadByKey(itemId);
            }

            doc.Doc = stream;

            doc.Save();
        }

        public byte[] LoadDoc(string itemId)
        {
            DAL.BugDoc doc = new DAL.BugDoc();
            doc.LoadByKey(itemId);
            if (!doc.IsLoaded)
                return new byte[] { };
            else
                return doc.Doc;
        }

        #endregion
        public bool IsLargestOrder(string itemId, int moveSequence)
        {
            throw new NotImplementedException();
        }
    }
}
