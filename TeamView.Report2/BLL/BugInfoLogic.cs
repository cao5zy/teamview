using Dev3Lib;
using Dev3Lib.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Report2.DAL.Interfaces;

namespace TeamView.Report2.BLL
{
    class BugInfoLogic : IBugInfoLogic
    {
        public List<string> AllBugNums(string programmer)
        {
            var bugInfo = DependencyFactory.Resolve<IBugInfo>();

            return bugInfo.AllBugNums(programmer);
        }

        public Entities.SimpleBugInfo GetSimpleBugInfo(string bugNum)
        {
            var bugInfo = DependencyFactory.Resolve<IBugInfo>();

            return bugInfo.GetSimpleBugInfo(bugNum);

        }
    }
}
