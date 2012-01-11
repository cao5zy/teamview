using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Dao;
using TeamView.DaoImpl;
using System.IO;
using TeamView.Common;

namespace TeamView
{
    public class CreateBugInfoManager : BugInfoManager
    {
        public delegate CreateBugInfoManager Factory();
        public CreateBugInfoManager(IBugInfoManagement bugInfomanagement):base(bugInfomanagement)
        {
            mBugInfo = new TeamView.Entity.BugInfoEntity { 
                Description = string.Empty,
                DisposeResult = string.Empty,
                DealMan = string.Empty,
                BugStatus =  States.Pending,
            };
        }


        protected override bool SaveCore(IBugInfoManagement bugInfoManagement)
        {
            bugInfoManagement.AddBugInfo(mBugInfo);

            return true;

        }

        protected override bool ValidateCore(IBugInfoManagement bugInfoManagement)
        {
            if (bugInfoManagement.QueryByBugNum(mBugInfo.BugNum) != null)
            {
                ShowMessage("Bug号已经存在");
                return false;
            }
            else
                return true;

        }

        protected override System.IO.Stream GetDetailStream()
        {
            return new MemoryStream();
        }

    }
}
