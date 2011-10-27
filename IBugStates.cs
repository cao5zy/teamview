using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfoManagement
{
    public interface IBugStates
    {
        List<Entity.BugStateBaseInfo> States { get; }
    }
}
