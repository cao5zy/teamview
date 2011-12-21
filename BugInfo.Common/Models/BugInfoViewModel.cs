using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common.Entity;
using BugInfoManagement.Dao;
using BugInfo.Common.Dao;
using BugInfoManagement;
using BugInfoManagement.Common;

namespace BugInfo.Common.Models
{
    public class BugInfoViewModel
    {
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

        public string CheckState()
        {
            if (string.IsNullOrEmpty(_current.version))
            {
                return "版本号不能为空!";
            }

            if (string.IsNullOrEmpty(_current.bugNum))
            {
                return "Bug编号不能为空!";
            }

            if (string.IsNullOrEmpty(_current.dealMan))
                return "处理人不能为空";

            if (string.IsNullOrEmpty(_current.bugStatus))
                return "状态不能为空";

            if (_old != null)
            {
                if (_current.bugStatus != _old.bugStatus)
                {
                    StateSequence stateSequence = new StateSequence(_old.bugStatus);
                    if (!stateSequence.IsNextStateValid(_current.bugStatus))
                        return "状态变化不允许";
                }
            }
            return null;
        }

        public bool Save()
        {
            if (!string.IsNullOrEmpty(CheckState()))
                return false;

            var oldStatus = StatesConverter.ToStateEnum(_old.bugStatus);
            var newStatus = StatesConverter.ToStateEnum(_current.bugStatus);
            if (oldStatus != StatesEnum.Start
                && newStatus == StatesEnum.Start)
            {
                _repository.SaveChangedState(_current.bugNum, newStatus.ToString(), _current.dealMan);
            }

            if (oldStatus == StatesEnum.Start
                && newStatus != oldStatus)
            {
                _repository.SaveChangedState(_current.bugNum, newStatus.ToString(), _current.dealMan);
            }
            return true;
        }
    }
}
