using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Entity;
using BugInfoManagement.Dao;
using BugInfo.Common.Dao;
using BugInfoManagement;
using BugInfoManagement.Common;
using System.Diagnostics;

namespace BugInfo.Common.Models
{
    public class BugInfoViewModel
    {
        public const string versionErrorMessage = "版本号不能为空";
        public const string bugNoErrorMessage = "Bug编号不能为空";
        public const string dealManErrorMessage = "处理人不能为空";
        public const string statusErrorMessage = "状态不能为空";
        public const string statusChangeErrorMessage = "状态变化不允许";
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

        public BugInfoEntity1 Load(string bugNum)
        {
            var item = _repository.GetItem(bugNum);
            _state = item != null;
            _old = item;
            _current = item.Clone();

            return _current;
        }

        public string SaveCheck()
        {
            if (string.IsNullOrEmpty(_current.version))
            {
                return versionErrorMessage ;
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

        public string MoveCheck()
        {
            Trace.Assert(_old != null);

            var oldStatus = StatesConverter.ToStateEnum(_old.bugStatus);
            var currentStatus = StatesConverter.ToStateEnum(_current.bugStatus);


            if (oldStatus == currentStatus)
                return statusChangeErrorMessage;

            var stateSeq = new StateSequence(_old.bugStatus);
            if (!stateSeq.IsNextStateValid(_current.bugStatus))
                return statusChangeErrorMessage;

            return string.Empty;
        }

        public SaveResult Save()
        {

            if (!string.IsNullOrEmpty(SaveCheck()))
                return new SaveResult { State = false};

            if (_old == _current)
                return new SaveResult { State = true };

            var result = new SaveResult { State = true };
            if (_old == null)
            {
                _current.bugStatus = States.Pending;
            }


            return new SaveResult { State = true,
                Object = _current
            };
        }

        public class SaveResult
        {
            public bool State { get; set; }

            public BugInfoEntity1 Object { get; set; }
        }

        public class MoveResult
        { }
    }
}
