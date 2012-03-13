using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common;
using TeamView.Common.Logs;

namespace TeamView.Report
{
    interface IFileProvider
    {
        void WriteSnapShot(string fileName, IEnumerable<DbItem> items);
        void WriteLogs(string filename, IEnumerable<TaskRecord> items);
        void WriteCompleteTaskLogs(string fileName, IEnumerable<CompleteTaskLogEntity> items);
    }
}
