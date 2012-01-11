using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView
{
    public interface INotificationSetting
    {
        string ProgrammerName { get; }
        int FrequenceInMinutes { get; }
    }
}
