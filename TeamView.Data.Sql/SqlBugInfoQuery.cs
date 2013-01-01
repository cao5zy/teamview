using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamView.Data.Sql
{
    class SqlBugInfoQuery : TeamView.Data.Abstract.IQuery
    {
        public IEnumerable<Abstract.Entities.BugInfoEntity> QueryByParameters(IEnumerable<string> programmers, string bugNum, string version, string description, IEnumerable<int> selectedPriorities, IEnumerable<string> selectedStates)
        {
            throw new NotImplementedException();
        }

        public Abstract.Entities.TaskLogEntity[] QueryTasks(string programmer, DateTime searchStart, DateTime searchEnd)
        {
            throw new NotImplementedException();
        }

        public int CountFeedbacks(string itemId)
        {
            throw new NotImplementedException();
        }
    }
}
