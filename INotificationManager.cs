using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfoManagement
{
    public interface INotificationManager
    {
        bool HasIncommingList { get; }

        List<string> GetInCommingList();

        void Refresh();
    }
}
