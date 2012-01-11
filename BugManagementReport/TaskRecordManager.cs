using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxLib.Algorithms;
using System.Diagnostics;
using TeamView.Dao;
using TeamView.Common;
using TeamView.Common;
using TeamView.Common.Logs;

namespace BugManagementReport
{
    class TaskRecordManager
    {
        private IBugInfoManagement BugInfoManagement { get; set; }

        public TaskRecordManager(IBugInfoManagement bugInfoManagement,
            IDbProvider dbProvider,
            IFileProvider fileProvider)
        {
            BugInfoManagement = bugInfoManagement;

            DBProvider = dbProvider;
            FileProvider = fileProvider;
        }
        private IDbProvider DBProvider { get; set; }

        private IFileProvider FileProvider { get; set; }

        public void ParseTask(string outputFile,
            DateTime start,
            DateTime end,
            string[] programmers,
            bool sortByBugNum,
            bool includePast,
            bool onlyTask)
        {
            var bugNumList = DBProvider.ReadBugNums(start, end);

            TaskRecordParser recordParser = new TaskRecordParser();

            List<TaskRecord> list = new List<TaskRecord>();

            foreach (var bugNum in bugNumList)
            {
                var logList = DBProvider.ReadBugLog(bugNum);

                list.AddRange(recordParser.Read(logList));
            }


            if (!includePast)
            {
                list = list.SafeFindAll(n => n.StartTime >= start);
            }

            if (programmers.SafeCount() != 0)
                list = list.FindAll(n => programmers.SafeExists(m => m == n.Programmer));

            if (!onlyTask)
            {
                list.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
                var uniqueIndexes = list
                    .SafeToEnumerable()
                    .Select(n=>n.TaskIndex)
                    .Distinct()
                    .ToList();


                List<TaskRecord> taskRecords = new List<TaskRecord>();
                foreach (var index in uniqueIndexes)
                {
                    var obj = list.Find(n => n.TaskIndex == index && list.SafeCount(m => m.TaskIndex == index) > 1);
                    if (obj != null)
                        taskRecords.Add(obj);
                }

                var groupItems = uniqueIndexes.FindAll(n => list.SafeCount(m => m.TaskIndex == n) > 1);

                list.FindAll(n => !taskRecords.Contains(n) && groupItems.Contains(n.TaskIndex))
                    .ForEach(n => n.Size = 0);
            }
            else
            {
                list = list.SafeUniqueItems(n =>  n.Add(m => m.BugNum).Add(m => m.Programmer)).ToList();
            }

            if (sortByBugNum)
            {
                list = new List<TaskRecord>(list.SafeSort(n=>n.Add(m=>m.BugNum).Add(m=>m.StartTime)));
                Console.WriteLine("by bugNum");
            }
            else
            {
                list = new List<TaskRecord>(list.SafeSort(n=>n.Add(m=>m.StartTime).Add(m=>m.BugNum)));
                Console.WriteLine("by Time");
            }

            list.ForEach(n =>
                {
                    try
                    {
                        n.Description = BugInfoManagement.QueryByBugNum(n.BugNum).Description;
                    }
                    catch (Exception ex)
                    {
                        n.Description = ex.Message;
                    }
                });

            foreach (var p in programmers)
            {
                list.SafeFindAll(n => n.Programmer == p)
                    .ForEach(
                    l =>
                    {
                        l.EstimatePoints = GetPoint(l.BugNum, p);
                    }
                    );
            }

            FileProvider.WriteLogs(outputFile, list);
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
    }
}
