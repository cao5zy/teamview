﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;

namespace TeamView.Report2.GeneralView
{
    sealed class GeneralViewReport
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

        private GeneralViewReportEntity[] GetList(string programmer, 
            DateTime startDate, 
            DateTime endDate)
        {

            return _query.QueryTasks(new QueryTaskParameter
            {
                _programmer = programmer,
                _searchStart = startDate,
                _searchEnd = endDate
            })
            .Select(n => new GeneralViewReportEntity { 
                BugNum = n.ItemId,
                Programmer = n.Dealman,
                _burnedMins = n.Burned,
                _sizeInMins = n.Estimate,
                Description = n.Description,
                
            })
            .ToArray();
        }
    }
}
