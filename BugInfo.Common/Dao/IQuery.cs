using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;
using TeamView.Common.Logs;

namespace TeamView.Common.Dao
{
    public interface IQuery
    {
        IEnumerable<BugInfoEntity1> QueryByParameters(IEnumerable<string> programmers, string bugNum, string version, string description, int ? priority, string bugState);
        IEnumerable<CompleteTaskLogEntity> QueryCompleteTasks(string dealMan, DateTime startDate, DateTime endDate, int completeTaskFlag);
    }
}
