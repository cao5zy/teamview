using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfoManagement.Entity;

namespace BugInfoManagement.Test
{
    class DealMenTestImpl : IDealMen
    {
        #region IDealMen Members

        public virtual List<BugInfoManagement.Entity.ProgrammerBaseInfo> DealMen
        {
            get {
                return new List<BugInfoManagement.Entity.ProgrammerBaseInfo> { 
                    new ProgrammerBaseInfo{
                        ID = 0,
                        Name = string.Empty
                    },
                    new ProgrammerBaseInfo{
                        ID = 1,
                        Name = "programmer_name"
                    }
                };
            }
        }

        #endregion
    }
}
