using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;

namespace TeamView.Common.Dao
{
    public interface IBugInfoRepository
    {
        BugInfoEntity1 GetItem(string itemId);

        void UpdateItem(BugInfoEntity1 item);

        long ? GetCurrentKeyValue(string keyName);

        void UpdateKeyValue(string keyName, long newVal);

        void InsertKeyValue(string keyName, long val);

        void SaveDoc(string itemId,byte[] stream);

        byte[] LoadDoc(string itemId);

        bool IsLargestOrder(string itemId);

        bool CheckDealManStatus(string dealMan, string bugStatus);

        void AddLog(string bugNum, string desc, int logTypeId);

        bool CheckTimeStamp(string itemId, DateTime timeStamp);
    }
}
