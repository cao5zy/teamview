using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxLib.Algorithms;
using System.Diagnostics;
using TeamView.Dao;
using TeamView.Common;
using TeamView.Common.Logs;
using TeamView.Common.Dao;
using System.IO;

namespace TeamView.Report
{
    class TaskRecordManager
    {
        private TaskRecordParser _recordParser;
        private IQuery _bugInfoQuery;
        public TaskRecordManager(
            IDbProvider dbProvider,
            IFileProvider fileProvider,
            TaskRecordParser recordParser,
            IQuery query)
        {
            _recordParser = recordParser;
            DBProvider = dbProvider;
            FileProvider = fileProvider;
            _bugInfoQuery = query;
        }
        private IDbProvider DBProvider { get; set; }

        private IFileProvider FileProvider { get; set; }

        public void ParseTask(string outputFile,
            DateTime start,
            DateTime end,
            string[] programmers,
            bool sortByBugNum,
            bool includePast,
            bool onlyTask,
            bool reportSummary)
        {
            var bugNumList = DBProvider.ReadBugNums(start, end);

            List<TaskRecord> list = new List<TaskRecord>();

            foreach (var bugNum in bugNumList)
            {
                list.AddRange(_recordParser.Read(bugNum));
            }

            if (includePast)
            {
                list = list.SafeFindAll(n => n.StartTime >= start);
            }

            if (programmers.SafeCount() != 0)
                list = list.FindAll(n => programmers.SafeExists(m => m == n.Programmer));

            if (onlyTask)
            {
                list = list.SafeUniqueItems(n => n.Add(m => m.BugNum).Add(m => m.Order)).ToList();
            }

            if (sortByBugNum)
            {
                list = new List<TaskRecord>(list.SafeSort(n => n.Add(m => m.BugNum).Add(m => m.StartTime)));
                Console.WriteLine("by bugNum");
            }
            else
            {
                list = new List<TaskRecord>(list.SafeSort(n => n.Add(m => m.StartTime).Add(m => m.BugNum)));
                Console.WriteLine("by Time");
            }

            if (reportSummary)
                list = PopulateSummary(list);

            FileProvider.WriteLogs(outputFile, list);
        }

        private static List<TaskRecord> PopulateSummary(List<TaskRecord> list)
        {
            string workingTimeFile = "workingtime.txt";
            List<DateTime> extraWorkingDates = new List<DateTime>();
            if (File.Exists(workingTimeFile))
                extraWorkingDates.AddRange(File.ReadAllLines(workingTimeFile)
                    .SafeConvertAll(n => Convert.ToDateTime(n)));

            List<DateTime> legalHolidays = new List<DateTime>();
            legalHolidays.AddRange(list.SafeFindAll(
                n => n.StartTime.DayOfWeek == DayOfWeek.Saturday
                    || n.StartTime.DayOfWeek == DayOfWeek.Sunday)
                    .ConvertAll(n=>n.StartTime.Date));

            legalHolidays = legalHolidays.SafeFindAll(
                n => !extraWorkingDates.Contains(n));

            TimeSpan legalStart = new TimeSpan(9, 0, 0);
            TimeSpan legalEnd = new TimeSpan(18, 0, 0);

            List<TaskRecord> result = new List<TaskRecord>();

            //calculate the workload in legalHolidays
            result.AddRange((from n in list
                                  where legalHolidays.Contains(n.StartTime.Date)
                                  group n by new {n.BugNum, n.Description} into g
                                  select new TaskRecord {
                                        BugNum = g.Key.BugNum,
                                        Description = g.Key.Description,
                                        Duration = g.Sum(m=>m.Duration),
                                        IsOvertime = true,
                                  }));

            //calcuate the workload in legalWorkingTime
            result.AddRange((from n in list
                             where (!legalHolidays.Contains(n.StartTime.Date))
                                && n.StartTime.TimeOfDay > legalEnd
                             group n by new { n.BugNum, n.Description } into g
                             select new TaskRecord
                             {
                                 BugNum = g.Key.BugNum,
                                 Description = g.Key.Description,
                                 Duration = g.Sum(m => m.Duration),
                                 IsOvertime = true,
                             }));

            //calculate the workload in legalWorkingTime
            result.AddRange((from n in list
                             where (!legalHolidays.Contains(n.StartTime.Date)) &&
                                n.StartTime.TimeOfDay >= legalStart && n.StartTime.TimeOfDay <= legalEnd
                             group n by new { n.BugNum, n.Description } into g
                             select new TaskRecord
                             {
                                 BugNum = g.Key.BugNum,
                                 Description = g.Key.Description,
                                 Duration = g.Sum(m => m.Duration),
                                 IsOvertime = false,
                             }));

            return result;
        }

        private string GetPoint(string bugNum, string programmer)
        {
            var items = DBProvider.ReadPoints(bugNum)
                .SafeFindAll(n => n.Assignee == programmer && !string.IsNullOrEmpty(n.EstimatedLevel))
                .SafeSort(n => n.Add(m => m.EstimatedTime));

            if (items.SafeCount() == 0)
                return string.Empty;
            else
                return string.Join(",", items.SafeConvertAll(n =>
                    string.Format("{1}:{0};", n.EstimatedLevel, n.EstimatedBy))
                    .SafeToArray());
        }

        public void ParseCompleteTasksHistory(string fileName, string dealMan, DateTime start, DateTime end)
        {
            FileProvider.WriteCompleteTaskLogs(fileName, _bugInfoQuery.QueryCompleteTasks(dealMan, start, end, (int)LogTypeEnum.Submit));
        }
    }
}
