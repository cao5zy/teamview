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
            throw new NotImplementedException();
        }
    }
}
