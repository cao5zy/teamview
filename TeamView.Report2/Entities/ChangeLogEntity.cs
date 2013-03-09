using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.Entities
{
    public class ChangeLogEntity
    {
        public static readonly string _CreateDateColumn = "CreateDate";
        public System.DateTime CreateDate { get; set; }


        public static readonly string _LogTypeIDColumn = "LogTypeID";
        public int LogTypeID { get; set; }

    }
}
