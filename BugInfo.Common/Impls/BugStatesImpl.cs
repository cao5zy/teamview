using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Entity;
using System.Configuration;
using FxLib.Algorithms;
using TeamView.Common.Abstracts;
using TeamView.Common.Entity;

namespace TeamView.Common.Impls
{
    public class BugStatesImpl : IBugStates
    {
        public static List<BugStateBaseInfo> STATES;
        static BugStatesImpl()
        {
            STATES = new List<BugStateBaseInfo> { 
                new BugStateBaseInfo{
                    ID = 0,
                    StateInfo = TeamView.Common.States.Pending,},
                    new BugStateBaseInfo{
                    ID = 0,
                    StateInfo = TeamView.Common.States.Start,},
                    new BugStateBaseInfo{
                    ID = 0,
                    StateInfo = TeamView.Common.States.Abort,},
                    new BugStateBaseInfo{
                    ID = 0,
                    StateInfo = TeamView.Common.States.Complete,},
            };
        }
        #region IBugStates Members

        public List<BugStateBaseInfo> States
        {
            get { return STATES; }
        }

        #endregion
    }
}
