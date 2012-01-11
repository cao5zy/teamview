using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Entity
{
    public class BugInfoEntity1 : IEquatable<BugInfoEntity1>
    {
        public string version { get; set; }
        public string bugNum { get; set; }
        public int moveSequence { get; set; }
        public string bugStatus { get; set; }
        public string dealMan { get; set; }
        public DateTime createdTime { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public DateTime lastStateTime { get; set; }
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
                moveSequence = this.moveSequence,
                bugStatus = this.bugStatus,
                dealMan = this.dealMan,
                createdTime = this.createdTime,
                description = this.description,
                size = this.size,
                lastStateTime = this.lastStateTime,
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
        this.moveSequence == other.moveSequence && 
        this.bugStatus == other.bugStatus && 
        this.dealMan == other.dealMan && 
        this.createdTime == other.createdTime && 
        this.description == other.description && 
        this.size == other.size && 
        this.lastStateTime == other.lastStateTime && 
        this.fired == other.fired && 
        this.timeStamp == other.timeStamp && 
        this.priority == other.priority && 
        this.hardLevel == other.hardLevel;

        }

        #endregion
    }
}
