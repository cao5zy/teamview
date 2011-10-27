using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL1.Common;

namespace BugInfo.Common.Logs
{
    class DBItemReader : ObjectBaseReader<DbItem>
    {
        public DBItemReader() :
            base("select version,bugNum,bugStatus,dealMan,description,priority from bugInfo ") { }
        protected override DbItem ConvertObject(System.Data.SqlClient.SqlDataReader reader)
        {
            return new DbItem {
                version = Convert.ToString(reader[0]),
                bugNum = Convert.ToString(reader[1]),
                bugStatus = reader.IsDBNull(2) ? string.Empty : Convert.ToString(reader[2]),
                dealMan = reader.IsDBNull(3) ? string.Empty : Convert.ToString(reader[3]),
                description = reader.IsDBNull(4) ? string.Empty : Convert.ToString(reader[4]).Replace("\r\n",string.Empty),
                priority = reader.IsDBNull(5) ? 0 : Convert.ToInt32(reader[5])
            };
        }

        public IEnumerable<DbItem> Search(string dealMan)
        {
            AddParameter("dealMan", "dealMan", dealMan);
            return base.ToList();
        }
    }
}
