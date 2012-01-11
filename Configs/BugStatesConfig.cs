using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TeamView.Configs
{
    public class BugStatesConfig : ConfigurationSection
    {

        [ConfigurationProperty("BugStates", DefaultValue = "")]
        public string BugStates
        {
            get { return (string)this["BugStates"]; }
        }
    }
}
