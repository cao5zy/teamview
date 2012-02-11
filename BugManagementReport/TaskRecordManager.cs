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

namespace BugManagementReport
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
            bool onlyTask)
        {
            var bugNumList = DBProvider.ReadBugNums(start, end);

            List<TaskRecord> list = new List<TaskRecord>();

            foreach (var bugNum in bugNumList)
            {
                list.AddRange(_recordParser.Read(bugNum));
            }

            if (!includePast)
            {
                list = list.SafeFindAll(n => n.StartTime >= start);
            }

            if (programmers.SafeCount() != 0)
                list = list.FindAll(n => programmers.SafeExists(m => m == n.Programmer));

            if (onlyTask)
            {
                list = list.SafeUniqueItems(n =>  n.Add(m => m.BugNum).Add(m => m.Order)).ToList();
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

        public void ParseCompleteTasksHistory(string fileName, string dealMan, DateTime start, DateTime end)
        {
            FileProvider.WriteCompleteTaskLogs(fileName, _bugInfoQuery.QueryCompleteTasks(dealMan, start, end, (int)LogTypeEnum.Submit));
        }
    }
}
