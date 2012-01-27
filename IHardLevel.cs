using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView
{
    public interface IHardLevel
    {
        List<int> HardLevels { get; }
        int DefaultHardLevel { get; }
    }
}
