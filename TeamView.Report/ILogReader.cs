using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report
{
    public interface ILogReader
    {
        IEnumerable<string> Read();
    }
}
