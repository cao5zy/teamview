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
        private IBugInfoRepository _bugInfoRepository;

        public delegate Report Factory(string programmer,
            DateTime startDate,
            DateTime endDate);
        public Report(string programmer,
            DateTime startDate,
            DateTime endDate,
            IBugInfoRepository bugInfoRepository
            )
        {
            _programmer = programmer;
            _startDate = startDate;
            _endDate = endDate;

            _list = GetList(programmer, startDate, endDate);
        }

        private ReportEntity[] GetList(string programmer, 
            DateTime startDate, 
            DateTime endDate)
        {
            return null;
        }
    }
}
