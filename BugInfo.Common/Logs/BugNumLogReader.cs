using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Logs
{
    class BugNumLogReader
    {
        public IEnumerable<string> SearchBugNumByDateRange(DateTime start, DateTime end)
        {
            var query = DAL.ChangeLog.CreateQuery();
            query.SelectList = "bugnum";
            query = query.DISTINCT();
            
            SubSonic.Where w = new SubSonic.Where();
            w.ColumnName = "createdTime";
            w.Comparison = SubSonic.Comparison.GreaterOrEquals;
            w.ParameterName = "CreateDate1";
            w.ParameterValue = start;
            w.Condition = SubSonic.Where.WhereCondition.AND;
            
            SubSonic.Where w1 = new SubSonic.Where{
                ColumnName = "createdTime",
                Comparison = SubSonic.Comparison.LessOrEquals,
                ParameterName = "CreateDate2",
                ParameterValue = end
            };

            using (var reader = query.AddWhere(w).AddWhere(w1).ExecuteReader())
            {

                List<string> bugNumList = new List<string>();
                while (reader.Read())
                {
                    bugNumList.Add(reader[0].ToString());
                }

                return bugNumList;
            }
        }
    }
}
