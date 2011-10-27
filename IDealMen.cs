using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfoManagement
{
    public interface IDealMen
    {
        List<Entity.ProgrammerBaseInfo> DealMen { get; }
    }
}
