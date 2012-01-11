using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView
{
    public interface INotificationManager
    {
        bool HasIncommingList { get; }

        List<string> GetInCommingList();

        void Refresh();
    }
}
