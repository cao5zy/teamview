using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfo.Common
{
    public interface IItemImporter
    {
        void Import(string xmlFileName, string version, string reporter, string iniDealMan);

        IEnumerable<string> ImportedList { get; }
    }
}
