using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Report2.Entities;

namespace TeamView.Report2.DAL.Interfaces
{
    public interface IBugInfo
    {
        List<SimpleBugInfo> ReturnSimpleBugInfo(
            string programmer,
            DateTime startDate,
            DateTime endDate);
    }
}
