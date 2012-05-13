using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.GeneralView
{
    sealed class ReportEntity
    {
        public string Programmer { get; set; }
        public string BugNum { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int _sizeInMins;
        public int _burnedMins;
        public string SizeInHours
        {
            get
            {
                return Math.Round((decimal)_sizeInMins / 60, 2).ToString();
            }
        }
        public string BurnedHours
        {
            get
            {
                return Math.Round((decimal)_burnedMins / 60, 2).ToString();
            }
        }
    }
}
