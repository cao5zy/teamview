using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.BLL
{
    public interface IChangeLogLogic
    {

        bool HasLogs(string bugNum, DateTime startDate, DateTime endDate);

        int CalculateCurrentBurnedMins(string bugNum, DateTime startDate, DateTime endDate);
    }
}
