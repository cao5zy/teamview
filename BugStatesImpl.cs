using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfoManagement.Entity;
using System.Configuration;
using OpenCourse.CommonLibrary.Algorithms;
namespace BugInfoManagement
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
                STATES = config.BugStates.Split(new char[]{','}).SafeConvetAll(
                n => new BugStateBaseInfo { 
                    ID = 0,
                    StateInfo = n,
                }
                );
        }
        #region IBugStates Members

        public List<BugInfoManagement.Entity.BugStateBaseInfo> States
        {
            get { return STATES; }
        }

        #endregion
    }
}
