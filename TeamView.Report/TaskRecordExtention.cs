using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common;
using TeamView.Common.Logs;

namespace TeamView.Report
{
    public static class TaskRecordExtention
    {
        public static string ToRecordString(this TaskRecord record)
        { 
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", 
                new object[]{
                record.BugNum,
                record.Programmer,
                record.StartTime,
                record.EndTime,
                record.Size,
                record.Duration,
                record.Description.RemoveNewLine(),
                record.EstimatePoints,
                record.IsOvertime
                });
        }
    }
}
