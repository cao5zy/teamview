using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using TeamView.Common;

namespace TeamView.Common.Logs
{
    public class TaskRecordParser
    {
        private static long TaskIndex = 0;

        private long GenerateTaskIndex()
        {
            return TaskIndex++;
        }
        public IEnumerable<TaskRecord> Read(IEnumerable<string> logs)
        {
            mTaskList.Clear();
            var record = logs.GetEnumerator();
            GenerateRecord(record);

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
        private void GenerateRecord(IEnumerator<string> record)
        {
            TaskRecord recordObj = new TaskRecord();

            while (record.MoveNext())
            {
                string line = record.Current;

                DateTime time = DateTime.MinValue;

                if (!ReadTime(ref line, out time))
                {
                    throw new FormatException("time");
                }

                int size;
                if (ReadSize(ref line, out size))
                {
                    recordObj.Size = size;
                }

                string dealMan;
                if (ReadDealMan(ref line, out dealMan))
                {
                    recordObj.Programmer = dealMan;
                }

                string bunNum;
                if (!ReadBugNum(ref line, out bunNum))
                {
                    throw new FormatException("bugNum");
                }
                else
                    recordObj.BugNum = bunNum;

                string initStatus;
                if (ReadIniStatus(ref line, out initStatus))
                {
                    if (initStatus == States.Start)
                        recordObj.StartTime = time;
                }

                int oldSize, newSize;
                if (IsSizeChanged(ref line, out oldSize, out newSize))
                {
                    //update the size
                    recordObj.Size = newSize;
                    mTaskList.FindAll(n => n.TaskIndex == recordObj.TaskIndex)
                        .ForEach(n => n.Size = newSize);
                }

                string oldDealMan, newDealMan;
                if (IsDealManChanged(ref line, out oldDealMan, out newDealMan))
                {
                    recordObj.Programmer = newDealMan;
                }

                string oldStatus, newStatus;
                if (IsStatusChanged(ref line, out oldStatus, out newStatus))
                {
                    if (oldStatus == States.Pending && newStatus == States.Start)
                    {
                        recordObj.TaskIndex = GenerateTaskIndex();
                        recordObj.StartTime = time;
                    }
                    else if (oldStatus == States.Start && newStatus == States.Complete)
                    {
                        recordObj.EndTime = time;
                        mTaskList.Add(recordObj);
                        recordObj = new TaskRecord
                        {
                            Programmer = recordObj.Programmer,
                            Size = recordObj.Size,
                        };
                    }
                    else if (oldStatus == States.Start && newStatus == States.Abort)
                    {
                        recordObj.EndTime = time;
                        mTaskList.Add(recordObj);

                        recordObj = new TaskRecord
                        {
                            Programmer = recordObj.Programmer,
                            Size = recordObj.Size,
                            TaskIndex = recordObj.TaskIndex,
                        };
                    }
                    else if (oldStatus == States.Abort && newStatus == States.Start)
                    {
                        if (!mTaskList.Exists(n => n.BugNum == recordObj.BugNum))
                            recordObj.TaskIndex = GenerateTaskIndex();
                        recordObj.StartTime = time;
                    }
                    else if (oldStatus == States.Complete && newStatus == States.Pending)
                    {
                        //do nothing
                    }
                    else if (oldStatus == States.Complete && newStatus == States.Start)
                    {
                        recordObj.StartTime = time;
                        recordObj.TaskIndex = GenerateTaskIndex();
                    }
                    //else
                        //throw new FormatException("Status changed");
                }
            }

        }

        private bool IsStatusChanged(ref string line, out string oldStatus, out string newStatus)
        {
            oldStatus = string.Empty;
            newStatus = string.Empty;

            var match = StatusChangeReg.Match(line);
            if (match.Success)
            {
                oldStatus = match.Groups[1].Value;
                newStatus = match.Groups[2].Value;
                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }

            return false;
        }

        private bool IsDealManChanged(ref string line, out string oldDealMan, out string newDealMan)
        {
            oldDealMan = string.Empty;
            newDealMan = string.Empty;

            var match = DealChangeReg.Match(line);
            if (match.Success)
            {
                oldDealMan = match.Groups[1].Value;
                newDealMan = match.Groups[2].Value;

                line = line.Replace(match.Groups[0].Value, "");

                return true;
            }

            return false;
        }

        private bool IsSizeChanged(ref string line, out int oldSize, out int newSize)
        {
            oldSize = 0;
            newSize = 0;

            var match = SizeChangeReg.Match(line);
            if (match.Success)
            {
                oldSize = int.Parse(match.Groups[1].Value);
                newSize = int.Parse(match.Groups[2].Value);

                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }
            return false;
        }

        private bool ReadIniStatus(ref string line, out string initStatus)
        {
            initStatus = string.Empty;

            var match = StatusReg.Match(line);
            if (match.Success)
            {
                initStatus = match.Groups[1].Value;
                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }

            return false;
        }

        private bool ReadBugNum(ref string line, out string bugNum)
        {
            bugNum = string.Empty;

            var match = BugNumReg.Match(line);
            if (match.Success)
            {
                bugNum = match.Groups[1].Value;
                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }

            return false;
        }

        private bool ReadDealMan(ref string line, out string dealMan)
        {
            dealMan = string.Empty;

            var match = DealManReg.Match(line);
            if (match.Success)
            {
                dealMan = match.Groups[1].Value;
                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }

            return false;
        }

        private bool ReadSize(ref string line, out int size)
        {
            size = 0;
            var match = SizeReg.Match(line);
            if (match.Success)
            {
                size = int.Parse(match.Groups[1].Value);
                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }
            return false;
        }

        private bool ReadTime(ref string line, out DateTime time)
        {
            time = DateTime.MinValue;
            var match = TimeReg.Match(line);
            if (match.Success)
            {
                time = Convert.ToDateTime(match.Groups[1].Value);
                line = line.Replace(match.Groups[0].Value, "");
                return true;
            }
            return false;
        }
    }
}
