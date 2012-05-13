using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Entity;
using TeamView.Common.Abstracts;
using TeamView.Common.Entity;

namespace TeamView.Test
{
    class DealMenTestImpl : IDealMen
    {
        #region IDealMen Members

        public virtual List<ProgrammerBaseInfo> DealMen
        {
            get {
                return new List<ProgrammerBaseInfo> { 
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


        public string CurrentLogin
        {
            get { return "曹宗颖"; }
        }
    }
}
