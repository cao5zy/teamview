using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Data.Abstract.Entities
{
    public class ProgrammerPoint
    {
        public string EstimatedBy { get; set; }

        public string Assignee { get; set; }

        public string EstimatedLevel { get; set; }

        public DateTime EstimatedTime { get; set; }
    }
}
