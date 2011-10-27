using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfoManagement.Entity
{
    public class BugInfoEntity
    {
        public BugInfoEntity() { }

        public string Version
        {
            get;
            set;// { mVersion = value; }
        }
        public string BugNum
        {
            get ;//{ return mBugNum; }
            set ;//{ mBugNum = value; }
        }
        public string BugStatus
        {
            get ;//{ return mBugStatus; }
            set ;//{ mBugStatus = value; }
        }
        public string DealMan
        {
            get;// { return mDealMan; }
            set;// { mDealMan = value; }
        }
        public string Description
        {
            get;// { return mDescription; }
            set;// { mDescription = value; }
        }
        public string DisposeResult
        {
            get;// { return mDisposeResult; }
            set;// { mDisposeResult = value; }
        }
        public string DetailDoc { get; set; }

        public string Comment { get; set; }

        public int Size { get; set; }

        public string CreatedBy { get; set; }

        public DateTime TimeStamp { get; set; }

        public short Priority { get; set; }

        public string EstimatedValue { get; set; }

        public decimal TotalHours { get; set; }

        public string LevelHistroy { get; set; }
    }
}
