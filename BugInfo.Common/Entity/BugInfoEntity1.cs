using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dev3Lib.Algorithms;

namespace TeamView.Common.Entity
{
    public class BugInfoEntity1 : IEquatable<BugInfoEntity1>
    {
        public string version { get; set; }
        public string bugNum { get; set; }
        public string bugStatus { get; set; }
        public string dealMan { get; set; }
        public DateTime createdTime { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public DateTime latestStartTime { get; set; }
        public int fired { get; set; }
        public DateTime timeStamp { get; set; }
        public int priority { get; set; }
        public int hardLevel { get; set; }

        public BugInfoEntity1 Clone()
        {
            return new BugInfoEntity1
            {
                version = this.version,
                bugNum = this.bugNum,
                bugStatus = this.bugStatus,
                dealMan = this.dealMan,
                createdTime = this.createdTime,
                description = this.description,
                size = this.size,
                latestStartTime = this.latestStartTime,
                fired = this.fired,
                timeStamp = this.timeStamp,
                priority = this.priority,
                hardLevel = this.hardLevel,
            };
        }

        #region IEquatable<BugInfoEntity1> Members

        public bool Equals(BugInfoEntity1 other)
        {
            if (other == null)
                return false;

            return         this.version == other.version && 
        this.bugNum == other.bugNum && 
        this.bugStatus == other.bugStatus && 
        this.dealMan == other.dealMan && 
        this.createdTime == other.createdTime && 
        this.description == other.description && 
        this.size == other.size && 
        this.latestStartTime == other.latestStartTime && 
        this.fired == other.fired && 
        this.timeStamp == other.timeStamp && 
        this.priority == other.priority && 
        this.hardLevel == other.hardLevel;

        }

        #endregion

        public static DataTable ToDataTable(IEnumerable<BugInfoEntity1> items)
        {
            //code format:tb.Columns.Add("{1}",typeof({2}));
            DataTable tb = new DataTable();
            tb.Columns.Add("version", typeof(string));
            tb.Columns.Add("bugNum", typeof(string));
            tb.Columns.Add("bugStatus", typeof(string));
            tb.Columns.Add("dealMan", typeof(string));
            tb.Columns.Add("createdTime", typeof(DateTime));
            tb.Columns.Add("description", typeof(string));
            tb.Columns.Add("size", typeof(int));
            tb.Columns.Add("latestStartTime", typeof(DateTime));
            tb.Columns.Add("fired", typeof(int));
            tb.Columns.Add("timeStamp", typeof(DateTime));
            tb.Columns.Add("priority", typeof(int));
            tb.Columns.Add("hardLevel", typeof(int));

            items.SafeForEach(n => {
                var row = tb.NewRow();

                //code format:row["{1}"] = n.{1};
                row["version"] = n.version;
                row["bugNum"] = n.bugNum;
                row["bugStatus"] = n.bugStatus;
                row["dealMan"] = n.dealMan;
                row["createdTime"] = n.createdTime;
                row["description"] = n.description;
                row["size"] = n.size;
                row["latestStartTime"] = n.latestStartTime;
                row["fired"] = n.fired;
                row["timeStamp"] = n.timeStamp;
                row["priority"] = n.priority;
                row["hardLevel"] = n.hardLevel;

                tb.Rows.Add(row);
            });


            return tb;
        }
    }
}
