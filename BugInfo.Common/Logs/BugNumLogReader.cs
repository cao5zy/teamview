using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL1.Common;

namespace BugInfo.Common.Logs
{
    class BugNumLogReader : ObjectBaseReader<string>
    {
        public BugNumLogReader() : base(@"select distinct bugnum
from ChangeLog") { }
        protected override string ConvertObject(System.Data.SqlClient.SqlDataReader sqlDataReader)
        {
            return sqlDataReader[0].ToString();
        }

        public IEnumerable<string> SearchBugNumByDateRange(DateTime start, DateTime end)
        {
            base.AddParameter("CreateDate", "CreateDate1", Parameter.Operators.GreatorThanAndEqualTo, start);
            base.AddParameter("CreateDate", "CreateDate12", Parameter.Operators.LessThanAndEqualTo, end);
            return base.ToList();
        }
    }
}
