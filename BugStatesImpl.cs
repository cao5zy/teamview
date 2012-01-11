using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Entity;
using System.Configuration;
using FxLib.Algorithms;

namespace TeamView
{
    public class BugStatesImpl : IBugStates
    {
        public static List<BugStateBaseInfo> STATES;
        static BugStatesImpl()
        {
            var config = (Configs.BugStatesConfig)ConfigurationManager.GetSection("BugStatesConfig");
            if (string.IsNullOrEmpty(config.BugStates))
                STATES = new List<BugStateBaseInfo>();
            else
                STATES = config.BugStates.Split(new char[]{','}).SafeConvertAll(
                n => new BugStateBaseInfo { 
                    ID = 0,
                    StateInfo = n,
                }
                );
        }
        #region IBugStates Members

        public List<TeamView.Entity.BugStateBaseInfo> States
        {
            get { return STATES; }
        }

        #endregion
    }
}
