using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugManagementReport
{
    public interface ILogReader
    {
        IEnumerable<string> Read();
    }
}
