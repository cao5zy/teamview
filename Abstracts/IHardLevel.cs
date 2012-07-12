using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Abstracts
{
    public interface IHardLevel
    {
        List<int> HardLevels { get; }
        int DefaultHardLevel { get; }
    }
}
