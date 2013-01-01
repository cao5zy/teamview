using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Data.Abstract.Entities;

namespace TeamView.Data.Abstract
{
    public interface IBugInfoRepository
    {
        BugInfoEntity GetItem(string itemId);

        void UpdateItem(BugInfoEntity item);

        long ? GetCurrentKeyValue(string keyName);

        void UpdateKeyValue(string keyName, long newVal);

        void InsertKeyValue(string keyName, long val);

        void SaveDoc(string itemId,byte[] stream);

        byte[] LoadDoc(string itemId);

        bool IsLargestOrder(string itemId);

        bool CheckDealManStatus(string dealMan, string bugStatus);

        void AddLog(string bugNum, string desc, int logTypeId);

        bool CheckTimeStamp(string itemId, DateTime timeStamp);

        bool HasLog(string bugNum);
    }
}
