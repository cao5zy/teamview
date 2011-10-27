using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfoManagement.Dao
{
    public class QueryParameter
    {
        [BugInfoParameter("dealMan")]
        public string Programmer { get; set; }
        [BugInfoParameter("bugStatus")]
        public string Status { get; set; }
        [BugInfoParameter("version")]
        public string Version { get; set; }
        [BugInfoParameter("bugNum")]
        public string BugNum { get; set; }
        [BugInfoParameter("description")]
        public string Description { get; set; }
    }
}
