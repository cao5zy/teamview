using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfo.Common.Logs
{
    class DBItemReader
    {
        public IEnumerable<DbItem> Search(string dealMan)
        {
            return new DAL.BugInfoCollection()
                .Where("dealman", dealMan).Load()
                .Select(n => new DbItem
                {
                    version = n.Version,
                    bugNum = n.BugNum,
                    bugStatus = string.IsNullOrEmpty(n.BugStatus) ? string.Empty : n.BugStatus,
                    dealMan = string.IsNullOrEmpty(n.DealMan) ? string.Empty : n.DealMan,
                    description = string.IsNullOrEmpty(n.Description) ? string.Empty : n.Description,
                    priority = n.Priority,
                }).ToArray();
        }
    }
}
