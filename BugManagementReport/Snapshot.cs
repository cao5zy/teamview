using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxLib.Algorithms;
using BugInfo.Common.Logs;

namespace BugManagementReport
{
    class Snapshot
    {
        public IDbProvider DBProvider { get; set; }
        public IFileProvider FileProvider { get; set; }

        public void Take(IEnumerable<string> userNames, string outFileName)
        {
            FileProvider.WriteSnapShot(outFileName, 
                userNames.SafeConvertAllItems(n=>
                DBProvider.Read(n))
                .SafeSort(n=>n.Add(m=>m.dealMan).Add(m=>m.version).Add(m=>m.priority)));
        }
    }
}
