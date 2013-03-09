using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.BLL
{
    public interface IBugInfoLogic
    {
        List<string> AllBugNums(string programmer);

        Entities.SimpleBugInfo GetSimpleBugInfo(string bugNum);
    }
}
