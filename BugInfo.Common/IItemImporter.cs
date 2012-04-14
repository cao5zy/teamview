using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common
{
    public interface IItemImporter
    {
        void Import(string xmlFileName, string iniDealMan);

        IEnumerable<string> ImportedList { get; }
    }
}
