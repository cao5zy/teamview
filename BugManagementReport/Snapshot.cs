using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxLib.Algorithms;
using BugInfo.Common.Logs;
using System.IO;

namespace BugManagementReport
{
    class Snapshot
    {
        public IDbProvider DBProvider { get; set; }
        public IFileProvider FileProvider { get; set; }

        public void Take(IEnumerable<string> userNames, string outFileName)
        {
            FileProvider.WriteSnapShot(outFileName,
                userNames.SafeConvertAllItems(n =>
                DBProvider.Read(n))
                .SafeToEnumerable()
                .OrderBy(n=>new {n.dealMan, n.version,n.priority}));
        }

        public static void TakeBugNumList(IEnumerable<string> usernames, string versionnumber, string outFileName)
        {
            using (var stream = new FileStream(outFileName, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    foreach (var username in usernames)
                    {
                        DAL.BugInfoCollection bugs = new DAL.BugInfoCollection()
                            .Where("dealman", username)
                            .Where("version", versionnumber)
                            .Load();

                        bugs.SafeForEach(n =>
                            streamWriter.WriteLine(n.BugNum));
                    }
                }
            }
        }
    }
}
