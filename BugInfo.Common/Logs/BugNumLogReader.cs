using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfo.Common.Logs
{
    class BugNumLogReader
    {
        public IEnumerable<string> SearchBugNumByDateRange(DateTime start, DateTime end)
        {
            DAL.ChangeLogCollection coll = new DAL.ChangeLogCollection();
            SubSonic.Where w = new SubSonic.Where();
            w.ColumnName = "CreateDate";
            w.Comparison = SubSonic.Comparison.GreaterOrEquals;
            w.ParameterName = "CreateDate1";
            w.ParameterValue = start;
            w.Condition = SubSonic.Where.WhereCondition.AND;
            
            SubSonic.Where w1 = new SubSonic.Where{
                ColumnName = "CreateDate",
                Comparison = SubSonic.Comparison.LessOrEquals,
                ParameterName = "CreateDate2",
                ParameterValue = end
            };


            return coll.Where(w)
                .Where(w1)
                .Load()
                .Select(n => n.BugNum)
                .Distinct()
                .ToArray();
        }
    }
}
