using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common
{
    static class TimeHelper
    {
        public static TimeRange ThisWeek
        {
            get
            {
                DateTime now = DateTime.Now.Date;
                return new TimeRange
                {
                    Start = now.AddDays(-((int)now.DayOfWeek - (int)DayOfWeek.Sunday)),
                    End = now.AddDays((int)DayOfWeek.Saturday - (int)now.DayOfWeek + 1)
                };
            }
        }
        public static TimeRange PreviousWeek { get {
            TimeRange thisWeek = ThisWeek;
            return new TimeRange { 
                Start = thisWeek.Start.AddDays(-7),
                End = thisWeek.Start
            };
        } }

    }
}
