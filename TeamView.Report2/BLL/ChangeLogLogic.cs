using Dev3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Report2.DAL.Interfaces;

namespace TeamView.Report2.BLL
{
    class ChangeLogLogic : IChangeLogLogic
    {
        public bool HasLogs(string bugNum, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public int CalculateCurrentBurnedMins(string bugNum, DateTime startDate, DateTime endDate)
        {
            var changeLogDal = DependencyFactory.Resolve<IChangeLog>();

            int value = 0;

            var logList = changeLogDal.GetLogs(bugNum, startDate, endDate);



            return value;
        }
    }
}
