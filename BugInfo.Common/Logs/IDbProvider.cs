using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Entity;

namespace BugInfo.Common.Logs
{
    public interface IDbProvider
    {
        IEnumerable<DbItem> Read(string userName);

        IEnumerable<string> ReadBugNums(DateTime start, DateTime end);

        IEnumerable<string> ReadBugLog(string bugNum);

        IEnumerable<ProgrammerPoint> ReadPoints(string bugNum);
    }
}
