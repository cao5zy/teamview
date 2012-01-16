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

        public DateTime SaveChangedState(string itemId, int moveSequence, string bugStatus)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(TeamView.Common.Entity.BugInfoEntity1 item)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastestStartTime(string itemId, int sequence)
        {
            throw new NotImplementedException();
        }

        public long? GetCurrentKeyValue(string keyName)
        {
            throw new NotImplementedException();
        }

        public void UpdateKeyValue(string keyName, long newVal)
        {
            throw new NotImplementedException();
        }

        public void InsertKeyValue(string keyName, long val)
        {
            throw new NotImplementedException();
        }

        public void SaveDoc(string itemId, byte[] stream)
        {
            throw new NotImplementedException();
        }

        public byte[] LoadDoc(string itemId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
