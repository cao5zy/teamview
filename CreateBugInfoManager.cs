using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugInfoManagement.Dao;
using BugInfoManagement.DaoImpl;
using System.IO;
using BugInfoManagement.Common;

namespace BugInfoManagement
{
    public class CreateBugInfoManager : BugInfoManager
    {
        public delegate CreateBugInfoManager Factory();
        public CreateBugInfoManager(IBugInfoManagement bugInfomanagement):base(bugInfomanagement)
        {
            mBugInfo = new BugInfoManagement.Entity.BugInfoEntity { 
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
