using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;

namespace TeamView.Report2.GeneralView
{
    sealed class Report
    {
        public readonly string _programmer;
        public readonly DateTime _startDate;
        public readonly DateTime _endDate;
        public readonly ReportEntity[] _list;
        public readonly int _advancedHours;
        private IQuery _query;

        public delegate Report Factory(string programmer,
            DateTime startDate,
            DateTime endDate);
        public Report(string programmer,
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

        private ReportEntity[] GetList(string programmer, 
            DateTime startDate, 
            DateTime endDate)
        {

            return _query.QueryTasks(new QueryTaskParameter
            {
                _programmer = programmer,
                _searchStart = startDate,
                _searchEnd = endDate
            })
            .Select(n => new ReportEntity { 
                BugNum = n.ItemId,
                Programmer = n.Dealman,
                _burnedMins = n.Burned,
                _sizeInMins = n.Estimate
                
            })
            .ToArray();
        }
    }
}
