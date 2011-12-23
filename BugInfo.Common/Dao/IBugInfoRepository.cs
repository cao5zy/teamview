using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Entity;

namespace BugInfo.Common.Dao
{
    public interface IBugInfoRepository
    {
        BugInfoEntity1 GetItem(string itemId);

        void SaveChangedState(string itemId, string bugStatus, string dealMan);

        void UpdateItem(BugInfoEntity1 item);
    }
}
