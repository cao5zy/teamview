using Dev3Lib;
using Dev3Lib.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.DAL
{
    class ChangeLog : Interfaces.IChangeLog
    {
        public List<Entities.ChangeLogEntity> GetLogs(string bugNum, DateTime startDate, DateTime endDate)
        {
            var selector = DependencyFactory.Resolve<ISelector>();

            return selector.Return(reader => new Entities.ChangeLogEntity
            {
                CreateDate = Convert.IsDBNull(reader["CreateDate"]) ? System.DateTime.MinValue : Convert.ToDateTime(reader["CreateDate"]),
                LogTypeID = Convert.IsDBNull(reader["LogTypeID"]) ? 0 : Convert.ToInt32(reader["LogTypeID"]),
                    },
                "select CreateDate,LogTypeID from ChangeLog",
                new WhereClause(bugNum,"bugNum")
                .And(new WhereClause(startDate, "CreateDate", Comparison.GreatorThanEqualTo)
                .And(new WhereClause(endDate, "CreateDate", Comparison.LessTanEqualTo))));
        }


        public bool HasLogs(string bugNum, DateTime startDate, DateTime endDate)
        {
            var selector = DependencyFactory.Resolve<ISelector>();

            return selector.Count("select count(*) from ChangeLog",
                new WhereClause(bugNum, "bugNum")
                .And(new WhereClause(startDate, "CreateDate", Comparison.GreatorThanEqualTo)
                .And(new WhereClause(endDate, "CreateDate", Comparison.LessTanEqualTo)))) != 0;
        }
    }
}
