using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Entity
{
    public sealed class TaskLogEntity
    {
        public string ItemId { get; set; }
        public string Dealman { get; set; }
        public int Estimate { get; set; }
        public int Burned { get; set; }
        public string Description { get; set; }
        public DateTime CompleteTime { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
    }
}
