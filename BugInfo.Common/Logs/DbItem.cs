using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfo.Common.Logs
{
    public class DbItem
    {
        public string version { get; set; }
        public string bugNum { get; set; }
        public string bugStatus { get; set; }
        public string dealMan { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
    }
}
