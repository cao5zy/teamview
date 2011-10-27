using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugInfoManagement.Dao
{
    public class BugInfoParameterAttribute : Attribute
    {
        public string SqlColumnName { get; private set; }
        public BugInfoParameterAttribute(string sqlColumnName)
        {
            SqlColumnName = sqlColumnName;
        }
    }
}
