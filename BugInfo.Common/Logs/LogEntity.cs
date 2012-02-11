using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Logs
{
    public class LogEntity
    {
        public string ItemId { get; set; }
        public int MoveSequence{get;set;}
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int LogTypeId { get; set; }
    }
}
