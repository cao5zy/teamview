using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Models;

namespace BugInfo.Common.Controllers
{
    public class BugInfoController
    {
        public bool Save(BugInfoViewModel model)
        {
            return true;
        }

        public IEnumerable<BugInfoViewModel> GetBugInfos()
        {
            return null;
        }

        public BugInfoViewModel GetBugInfo(string bugNum)
        {
            return null;
        }
    }
}
