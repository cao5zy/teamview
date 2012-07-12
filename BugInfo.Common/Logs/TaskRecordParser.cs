using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using TeamView.Common;
using TeamView.Common.Dao;

namespace TeamView.Common.Logs
{
    public class TaskRecordParser
    {
        private static long TaskIndex = 0;

        private IBugInfoRepository _repository;

        private long GenerateTaskIndex()
        {
            return TaskIndex++;
        }

        public TaskRecordParser(IBugInfoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TaskRecord> Read(string itemId)
        {
            mTaskList.Clear();
            GenerateRecord(itemId);

            return mTaskList;
        }
        List<TaskRecord> mTaskList = new List<TaskRecord>();

        static readonly Regex SizeReg = new Regex(@"size:(\d+);?");
        static readonly Regex StatusReg = new Regex(@"S:(\w+);?");
        static readonly Regex TimeReg = new Regex(@"Time:([^;]+);?");
        static readonly Regex DealManReg = new Regex(@"D:(\w+);?");
        static readonly Regex BugNumReg = new Regex(@"BugNum:([^;]+);?");
        static readonly Regex SizeChangeReg = new Regex(@"Size:(\d+)\-\>(\d+);?");
        static readonly Regex DealChangeReg = new Regex(@"Deal:(\w+)\-\>(\w+);?");
        static readonly Regex StatusChangeReg = new Regex(@"Status:(\w+)-\>(\w+);?");
        private void GenerateRecord(string itemId)
        {
            TaskRecord recordObj = new TaskRecord();

            foreach (var log in new DBProvider().ReadBugLog(itemId))
            {
                if (log.LogTypeId == (int)LogTypeEnum.MissionStart)
                {
                    recordObj.StartTime = log.CreatedDate;
                }
                if (log.LogTypeId == (int)LogTypeEnum.MissionStop || log.LogTypeId == (int)LogTypeEnum.Submit)
                {
                    var entity = _repository.GetItem(log.ItemId);

                    recordObj.EndTime = log.CreatedDate;
                    recordObj.BugNum = log.ItemId;
                    recordObj.Programmer = entity.dealMan;
                    recordObj.Size = entity.size;
                    recordObj.Description = entity.description;
                    recordObj.EstimatePoints = entity.hardLevel;
                    mTaskList.Add(recordObj);
                    recordObj = new TaskRecord();
                }
            }
        }
    }
}
