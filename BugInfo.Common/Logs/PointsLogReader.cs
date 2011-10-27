using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL1.Common;
using BugInfo.Common.Entity;
using BugInfoManagement.Common;

namespace BugInfo.Common.Logs
{
    class PointsLogReader : ObjectBaseReader<ProgrammerPoint>
    {
        public PointsLogReader() : base("select [log], createdtime from pointslog") { }
        protected override ProgrammerPoint ConvertObject(System.Data.SqlClient.SqlDataReader sqlDataReader)
        {
            var p = PointsParser.ToPoint(sqlDataReader[0].ToString());
            p.EstimatedTime = Convert.ToDateTime(sqlDataReader[1]);
            return p;
        }

        public List<ProgrammerPoint> GetPointList(string bugNum)
        {
            base.AddParameter("bugnum", "bugnum", bugNum);

            return base.ToList();
        }
    }
}
