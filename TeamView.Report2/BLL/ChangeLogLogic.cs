using Dev3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common;
using TeamView.Report2.DAL.Interfaces;

namespace TeamView.Report2.BLL
{
    public class ChangeLogLogic : IChangeLogLogic
    {
        public bool HasLogs(string bugNum, DateTime startDate, DateTime endDate)
        {
            var changeLogDal = DependencyFactory.Resolve<IChangeLog>();

            return changeLogDal.HasLogs(bugNum, startDate, endDate);
        }

        public int CalculateCurrentBurnedMins(string bugNum, DateTime startDate, DateTime endDate)
        {
            var changeLogDal = DependencyFactory.Resolve<IChangeLog>();


            var logList = changeLogDal.GetLogs(bugNum, startDate, endDate);

            if (logList.Count != 0 && 
                (logList[0].LogTypeID == (int)LogTypeEnum.MissionStop || logList[0].LogTypeID == (int)LogTypeEnum.Submit))
            {
                logList.RemoveAt(0);
            }

            DateTime startTime = DateTime.MinValue;
            int value = 0;

            foreach (var log in logList)
            {
                if (log.LogTypeID == (int)LogTypeEnum.MissionStart)
                    startTime = log.CreateDate;
                if(log.LogTypeID == (int)LogTypeEnum.MissionStop || log.LogTypeID == (int)LogTypeEnum.Submit)
                    value += (int)log.CreateDate.Subtract(startTime).TotalMinutes;
            }


            return value;
        }
    }
}
