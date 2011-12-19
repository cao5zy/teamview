using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfo.Common.Models
{
    public class BugInfoViewModel
    {
        private bool _isNew;

        public bool Validate()
        {
            return false;
        }

        private HardLevelModel HardLevel { get; set; }

        public StateViewModel State { get; set; }

        public string Version { get; set; }

        public string BugNum { get; set; }

        public int MoveSequence { get; set; }

        public string BugStatus { get; set; }

        public string DealMan { get; set; }

        public string Description { get; set; }

        public string CreatedMan { get; set; }

        public int Size { get; set; }

        public DateTime LastStateTime { get; set; }

        public int Fired { get; set; }

        public DateTime TimeStamp { get; set; }

        public short Priority { get; set; }

        public short HardLevel { get; set; }

    }
}
