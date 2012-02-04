using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;

namespace TeamView.Common.Logs
{
    public interface IDbProvider
    {
        IEnumerable<DbItem> Read(string userName);

        IEnumerable<string> ReadBugNums(DateTime start, DateTime end);

        IEnumerable<LogEntity> ReadBugLog(string bugNum);

        IEnumerable<ProgrammerPoint> ReadPoints(string bugNum);
    }
}
