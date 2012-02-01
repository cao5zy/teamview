using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Abstracts
{
    public interface IDealMen
    {
        List<Entity.ProgrammerBaseInfo> DealMen { get; }

        string CurrentLogin { get; }
    }
}
