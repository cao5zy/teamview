using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Entity;

namespace BugInfo.Common.Dao
{
    public interface IBugInfoRepository
    {
        BugInfoEntity1 GetItem(string itemId, int moveSequence);

        void SaveChangedState(string itemId, int moveSequence, string bugStatus, string dealMan);

        void UpdateItem(BugInfoEntity1 item);

        DateTime GetLastestStartTime(string itemId, int sequence);

        long ? GetCurrentKeyValue(string keyName);

        void UpdateKeyValue(string keyName, long newVal);

        void InsertKeyValue(string keyName, long val);

        void SaveDoc(string itemId,byte[] stream);

        byte[] LoadDoc(string itemId);
    }
}
