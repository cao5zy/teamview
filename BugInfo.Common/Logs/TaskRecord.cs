using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Logs
{
    public class TaskRecord
    {
        public bool IsOvertime { get; set; }

        public string Programmer { get; set; }

        public string BugNum { get; set; }

        public int Size { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Order { get; set; }

        private Nullable<decimal> _durartion;
        public decimal Duration
        {
            get
            {
                if (_durartion == null)
                    return Math.Round((decimal)EndTime.Subtract(StartTime).TotalMinutes / 60, 2);
                else
                    return _durartion.Value;
            }
            set
            {
                _durartion = value;
            }
        }

        public bool HasAllValueSet
        {
            get {
                return Programmer != null
                    && BugNum != null
                    && Size != 0
                    && StartTime != DateTime.MinValue
                    && EndTime != DateTime.MinValue;
            }
        }

        public string Description { get; set; }

        public int EstimatePoints { get; set; }
    }
}
