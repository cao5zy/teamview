using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfoManagement.Common;

namespace BugInfoManagement
{
    class StateSequence
    {
        class Sequence
        {
            public string Current { get; set; }
            public string Next { get; set; }
        }
        private string mCurrentState = string.Empty;
        private static readonly List<Sequence> StatesList = new List<Sequence> { 
            new Sequence{Current = States.Pending,Next = States.Start},
            new Sequence{Current =States.Start, Next = States.Abort},
            new Sequence{Current = States.Abort, Next =States.Start},
            new Sequence{Current =States.Start, Next = States.Complete},
            new Sequence{Current = States.Complete,Next = States.Pending},
            new Sequence{Current = States.Complete, Next =States.Start}
        };

        public StateSequence(string currentState)
        {
            mCurrentState = currentState;
        }

        public bool IsNextStateValid(string state)
        {
            return StatesList.FindAll(n => n.Current == mCurrentState)
                .Exists(n => n.Next == state);
        }
    }
}
