using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Data.Abstract.Entities;

namespace TeamView.Data.Abstract
{
    public interface IQuery
    {
        IEnumerable<BugInfoEntity> QueryByParameters(
            IEnumerable<string> programmers,
            string bugNum,
            string version,
            string description,
            IEnumerable<int> selectedPriorities,
            IEnumerable<string> selectedStates);

        TaskLogEntity[] QueryTasks(string programmer, DateTime searchStart, DateTime searchEnd);

        int CountFeedbacks(string itemId);
    }
}
