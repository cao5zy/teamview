using Dev3Lib;
using Dev3Lib.Sql;
using Dev3Lib.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.DAL
{
    public class BugInfo : Interfaces.IBugInfo
    {

        public List<string> AllBugNums(string programmer)
        {
            var selector = DependencyFactory.Resolve<ISelector>();

            return selector.Return<string>(n => n[0].ToString(),
                "select bugNum from bugInfo",
                new WhereClause(programmer, "dealMan"));
        }

        public Entities.SimpleBugInfo GetSimpleBugInfo(string bugNum)
        {

            var selector = DependencyFactory.Resolve<ISelector>();

            var list = selector.Return<Entities.SimpleBugInfo>(
                reader => new Entities.SimpleBugInfo
                {
                    bugNum = reader["bugNum"].ToString(),
                    dealMan = reader["dealMan"].ToString(),
                    description = reader["description"].ToString(),
                    size = Convert.ToInt32(reader["size"]),
                    fired = Convert.ToInt32(reader["fired"]),
                },
                "select * from bugInfo",
                new WhereClause(bugNum, "bugNum"));

            if (list.Count == 0)
                return null;
            else
                return list[0];

        }
    }
}
