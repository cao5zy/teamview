using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfo.Common.Logs
{
    class BugLogReader 
    {

        public IEnumerable<string> GetLogList(string bugNum)
        {
            return new DAL.ChangeLogCollection()
                .Where("bugnum", bugNum).Load()
                .Select(n => string.Format("BugNum:{0};Time:{1};{2}", n.BugNum, n.CreateDate, n.Description))
                .ToArray();
        }
    }
}
