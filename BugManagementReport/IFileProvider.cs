using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common;
using TeamView.Common.Logs;

namespace BugManagementReport
{
    interface IFileProvider
    {
        void WriteSnapShot(string fileName, IEnumerable<DbItem> items);
        void WriteLogs(string filename, IEnumerable<TaskRecord> items);
    }
}
