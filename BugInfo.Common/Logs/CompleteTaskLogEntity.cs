using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Logs
{
    public class CompleteTaskLogEntity
    {
        public string ItemId { get; set; }
        public int Order { get; set; }
        public string Dealman { get; set; }
        public int Estimate { get; set; }
        public decimal Burned { get; set; }
        public string Description { get; set; }
        public DateTime CompleteTime { get; set; }
        public string Version { get; set; }
    }
}
