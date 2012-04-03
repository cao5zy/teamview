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
        IEnumerable<BugInfoEntity1> QueryByParameters(
            IEnumerable<string> programmers,
            string bugNum,
            string version,
            string description,
            IEnumerable<int> selectedPriorities,
            IEnumerable<string> selectedStates);
        IEnumerable<CompleteTaskLogEntity> QueryCompleteTasks(string dealMan, DateTime startDate, DateTime endDate, int completeTaskFlag);

        int CountFeedbacks(string itemId);
    }
}
