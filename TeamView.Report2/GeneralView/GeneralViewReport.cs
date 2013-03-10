using Dev3Lib;
using Dev3Lib.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;
using TeamView.Report2.BLL;
using TeamView.Report2.DAL.Interfaces;
using TeamView.Report2.Entities;

namespace TeamView.Report2.GeneralView
{
    public sealed class GeneralViewReport
    {
        public readonly string _programmer;
        public readonly DateTime _startDate;
        public readonly DateTime _endDate;
        public readonly GeneralViewReportEntity[] _list;
        private IQuery _query;

        public delegate GeneralViewReport Factory(string programmer,
            DateTime startDate,
            DateTime endDate);
        public GeneralViewReport(string programmer,
            DateTime startDate,
            DateTime endDate,
            IQuery query
            )
        {
            _programmer = programmer;
            _startDate = startDate;
            _endDate = endDate;
            _query = query;

            _list = GetList(programmer, startDate, endDate);
        }

        public static GeneralViewReportEntity[] GetList(string programmer, 
            DateTime startDate, 
            DateTime endDate)
        {
            using (DependencyFactory.BeginScope())
            {
                DependencyFactory.Resolve<IDbContext>().BeginTransaction();
                var bugInfo = DependencyFactory.Resolve<IBugInfoLogic>();
                var changeLog = DependencyFactory.Resolve<IChangeLogLogic>();

                var allBugNumbs = bugInfo.AllBugNums(programmer);

                var resultList = new List<GeneralViewReportEntity>();

                foreach (var bugNum in allBugNumbs)
                {
                    if (!changeLog.HasLogs(bugNum, startDate, endDate))
                        continue;

                    SimpleBugInfo item = bugInfo.GetSimpleBugInfo(bugNum);

                    int currentFired = changeLog.CalculateCurrentBurnedMins(bugNum, startDate, endDate);

                    resultList.Add(new GeneralViewReportEntity { 
                        BugNum = item.bugNum,
                        Description = item.description,
                        Programmer = programmer,
                        _sizeInMins = item.size,
                        _burnedMins = item.fired,
                        _currentBurnedMins = currentFired,
                    });
                }

                return resultList.ToArray();
            }
        }
    }
}
