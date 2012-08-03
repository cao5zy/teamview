using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;
using TeamView.Common.Dao;

namespace TeamView.Controllers
{
    public class TaskController
    {

        private IQuery _query;

        public TaskController(IQuery query)
        {
            _query = query;
        }
        public List<BugInfoEntity1> LoadCurrentTask(string userName)
        {
            return _query.QueryByParameters(new string[] { userName },
                null,
                null,
                null,
                null,
                null).ToList();
        }
    }
}
