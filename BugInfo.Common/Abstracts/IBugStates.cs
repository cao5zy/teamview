using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common.Abstracts
{
    public interface IBugStates
    {
        List<Entity.BugStateBaseInfo> States { get; }
    }
}
