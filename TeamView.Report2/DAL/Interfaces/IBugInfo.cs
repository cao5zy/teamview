using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Report2.Entities;

namespace TeamView.Report2.DAL.Interfaces
{
    public interface IBugInfo
    {
        List<string> AllBugNums(string programmer);
        Entities.SimpleBugInfo GetSimpleBugInfo(string bugNum);
    }
}
