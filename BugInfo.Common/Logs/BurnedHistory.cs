using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Dev3Lib.Algorithms;

namespace TeamView.Common.Logs
{
    public sealed class BurnedHistory
    {
        public readonly string _bugNum;
        public readonly DateTime _startTime;
        public readonly DateTime _endTime;
        public readonly LogEntity[] _burnedLogs;
        public readonly int _burnedTotalMinuts;
        public BurnedHistory(
            string bugNum,
            DateTime startTime,
            DateTime endTime)
        {
            _bugNum = bugNum;
            _startTime = startTime;
            _endTime = endTime;

            _burnedLogs = GetBurnedLogs(bugNum,
                startTime,
                endTime);
            _burnedTotalMinuts = CalculateTotalMins(_burnedLogs);

        }

        private static int CalculateTotalMins(LogEntity[] logEntities)
        {
            int total = 0;

            if (logEntities.IsNullOrEmpty())
                return total;
            DateTime lastStartTime = DateTime.MinValue;
            for (int i = 0; i < logEntities.Length; i++)
            {
                var current = logEntities[i];
                if (current.LogTypeId == (int)LogTypeEnum.MissionStart)
                {
                    lastStartTime = current.CreatedDate;
                }
                else if (current.LogTypeId == (int)LogTypeEnum.MissionStop
                    || current.LogTypeId == (int)LogTypeEnum.Submit)
                {
                    total += (int)current.CreatedDate.Subtract(lastStartTime).TotalMinutes;
                }
            }

            return total;
        }

        private static LogEntity[] GetBurnedLogs(
            string bugNum,
            DateTime startTime,
            DateTime endTime
            )
        {
            var logs = new ChangeLogCollection()
            .Where(ChangeLog.Columns.BugNum, bugNum)
            .Where(ChangeLog.Columns.CreateDate, SubSonic.Comparison.GreaterOrEquals, startTime)
            .Where(ChangeLog.Columns.CreateDate, SubSonic.Comparison.LessOrEquals, endTime)
            .OrderByAsc(ChangeLog.Columns.CreateDate)
            .Load()
            .Select(n => new LogEntity
            {
                ItemId = n.BugNum,
                CreatedDate = n.CreateDate,
                Description = n.Description,
                LogTypeId = n.LogTypeID
            })
            .ToArray();

            //remove the first item that is MissionStop or Submit
            var firstMissionStop = logs.SafeFind(n => n.LogTypeId == (int)LogTypeEnum.MissionStop
                || n.LogTypeId == (int)LogTypeEnum.Submit);

            var firstMissionStart = logs.SafeFind(n => n.LogTypeId == (int)LogTypeEnum.MissionStart);

            if (firstMissionStart == null || firstMissionStop == null)
                return null;

            try
            {
                if (logs.GetPosition(firstMissionStart) > logs.GetPosition(firstMissionStop))
                {
                    return logs.SafeFindAll(n => n != firstMissionStop).ToArray();
                }
                else
                    return logs.ToArray();
            }
            catch(PostionNotFoundException)
            {
                return null;
            }
        }
    }
}
