using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;
using TeamView.Dao;
using TeamView.Common.Dao;
using TeamView;
using TeamView.Common;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace TeamView.Common.Models
{
    public class BugInfoViewModel
    {
        public const string versionErrorMessage = "版本号不能为空";
        public const string bugNoErrorMessage = "Bug编号不能为空";
        public const string dealManErrorMessage = "处理人不能为空";
        public const string statusErrorMessage = "状态不能为空";
        public const string statusChangeErrorMessage = "状态变化不允许";
        public const string dealManDuplicated = "流程处理人相同";
        public const string notLargestOrder = "只能在最大序号上对任务做转移处理";
        public const string hasStartedTask = "存在了已经开始的任务";
        private IBugInfoRepository _repository;
        private bool _state = false;
        public bool State
        {
            get
            {
                return _state;
            }
        }
        public BugInfoViewModel(IBugInfoRepository
            repository)
        {
            _repository = repository;
        }
        private BugInfoEntity1 _old;
        private BugInfoEntity1 _current;

        public BugInfoEntity1 Current
        {
            get
            {
                return _current;
            }
        }

        public BugInfoEntity1 New()
        {
            _current = new BugInfoEntity1();
            _state = true;
            return _current;
        }

        public BugInfoEntity1 Load(string bugNum, int moveSequence)
        {
            var item = _repository.GetItem(bugNum, moveSequence);
            _state = item != null;
            _old = item;
            _current = item.Clone();

            return _current;
        }

        public string SaveCheck()
        {
            if (string.IsNullOrEmpty(_current.version))
            {
                return versionErrorMessage;
            }

            if (string.IsNullOrEmpty(_current.bugNum))
            {
                return bugNoErrorMessage;
            }

            if (string.IsNullOrEmpty(_current.dealMan))
                return dealManErrorMessage;

            if (_old != null && string.IsNullOrEmpty(_current.bugStatus))
                return statusErrorMessage;

            if (_old != null)
            {
                if (_current.bugStatus != _old.bugStatus)
                {
                    StateSequence stateSequence = new StateSequence(_old.bugStatus);
                    if (!stateSequence.IsNextStateValid(_current.bugStatus))
                        return statusChangeErrorMessage;
                }
            }
            return null;
        }

        public string ChangeStatusCheck()
        {
            Trace.Assert(_old != null);

            var oldStatus = StatesConverter.ToStateEnum(_old.bugStatus);
            var currentStatus = StatesConverter.ToStateEnum(_current.bugStatus);


            if (oldStatus == currentStatus)
                return statusChangeErrorMessage;

            var stateSeq = new StateSequence(_old.bugStatus);
            if (!stateSeq.IsNextStateValid(_current.bugStatus))
                return statusChangeErrorMessage;

            if (_current.bugStatus == States.Start && _repository.CheckDealManStatus(_current.dealMan, _current.bugStatus))
                return hasStartedTask;

            return string.Empty;
        }

        public SaveResult Save()
        {

            if (!string.IsNullOrEmpty(SaveCheck()))
                return new SaveResult { State = false };

            if (_old == _current)
                return new SaveResult { State = true };

            var result = new SaveResult { State = true };
            if (_old == null)
            {
                _current.bugStatus = States.Pending;
            }
            

            return new SaveResult
            {
                State = true,
                Object = _current
            };
        }

        public class SaveResult
        {
            public bool State { get; set; }

            public BugInfoEntity1 Object { get; set; }
        }

        public class CommitStatusResult
        {
            public bool State { get; set; }

            public int LogTypeId { get; set; }
        }

        public CommitStatusResult CommitStatus()
        {
            CommitStatusResult result = new CommitStatusResult { State = false };

            if (!string.IsNullOrEmpty(ChangeStatusCheck()))
                return result;


            result.LogTypeId = ConvertToLogTypeId(StatesConverter.ToStateEnum(_current.bugStatus));

            if (_current.bugStatus ==States.Complete || _current.bugStatus == States.Abort)
            {
                _current.fired = _current.fired + (int)DateTime.Now.Subtract(_current.lastStateTime).TotalMinutes;
                _current.lastStateTime= DateTime.MinValue;
            }
            if (_current.bugStatus == States.Start)
                _current.lastStateTime = DateTime.Now;
            return result;
        }

        private int ConvertToLogTypeId(StatesEnum statesEnum)
        {
            if (statesEnum == StatesEnum.Start)
                return (int)LogTypeEnum.MissionStart;
            if (statesEnum == StatesEnum.Complete || statesEnum == StatesEnum.Abort)
                return (int)LogTypeEnum.MissionStop;
            else
                return (int)LogTypeEnum.None;
        }

        public void SaveDoc(byte[] stream)
        {
            MemoryStream zipTargetStream = new MemoryStream();

            using (GZipStream zipStream = new GZipStream(zipTargetStream, CompressionMode.Compress, true))
            {
                zipStream.Write(stream, 0, (int)stream.Length);
            }

            _repository.SaveDoc(_current.bugNum, zipTargetStream.ToArray());
        }

        public byte[] LoadDoc(string itemId)
        {
            byte[] stream = _repository.LoadDoc(itemId);

            MemoryStream s = new MemoryStream(stream);
            using (GZipStream zipStream = new GZipStream(s, CompressionMode.Decompress))
            {
                int readLen = 0;
                int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];

                readLen = zipStream.Read(buffer, 0, bufferLen);

                var unZipStream = new MemoryStream();

                while (readLen != 0)
                {
                    unZipStream.Write(buffer, 0, readLen);

                    readLen = zipStream.Read(buffer, 0, bufferLen);
                }

                unZipStream.Flush();

                return unZipStream.ToArray();
            }

        }

        public class MoveDealManResult
        {
            public MoveDealManResult(bool state)
            {
                State = state;
            }
            public bool State { get; private set; }

            public BugInfoEntity1 NewItem { get; set; }
        }
        public string CheckMoveDealMan(string dealMan)
        {
            var status = StatesConverter.ToStateEnum(_current.bugStatus);
            if (status == StatesEnum.Abort
                || status == StatesEnum.Start)
                return statusChangeErrorMessage;

            if (_current.dealMan == dealMan)
                return dealManDuplicated;

            if (!_repository.IsLargestOrder(_current.bugNum, _current.moveSequence))
                return notLargestOrder;

            return string.Empty;
        }

        public MoveDealManResult MoveDealMan(string dealMan)
        {
            return MoveDealMan(dealMan, _current.size, _current.priority);
        }

        public MoveDealManResult MoveDealMan(string newDealMan, int newSize, int newPriority)
        {
            if (!string.IsNullOrEmpty(CheckMoveDealMan(newDealMan)))
                return new MoveDealManResult(false);

            var newObj = new BugInfoEntity1
            {
                bugNum = _current.bugNum,
                bugStatus = States.Pending,
                createdTime = DateTime.Now,
                dealMan = newDealMan,
                description = _current.description,
                fired = 0,
                hardLevel = _current.hardLevel,
                lastStateTime = DateTime.MinValue,
                moveSequence = _current.moveSequence + 1,
                priority = newPriority,
                size = newSize,
                version = _current.version,
            };

            return new MoveDealManResult(true) { NewItem = newObj };
        }
    }
}
