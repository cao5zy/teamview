using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common
{
    class TimeRange
    {
        public TimeRange() {
            Start = DateTime.Now;
            End = Start;
        }
        public TimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
