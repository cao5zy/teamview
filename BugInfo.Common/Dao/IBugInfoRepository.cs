using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;

namespace TeamView.Common.Dao
{
    public interface IBugInfoRepository
    {
        BugInfoEntity1 GetItem(string itemId, int moveSequence);

        DateTime SaveChangedState(string itemId, int moveSequence, string bugStatus);

        void UpdateItem(BugInfoEntity1 item);

        DateTime GetLastestStartTime(string itemId, int sequence);

        long ? GetCurrentKeyValue(string keyName);

        void UpdateKeyValue(string keyName, long newVal);

        void InsertKeyValue(string keyName, long val);

        void SaveDoc(string itemId,byte[] stream);

        byte[] LoadDoc(string itemId);
    }
}
