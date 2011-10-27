using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BugInfoManagement.Configs
{
    public class DealManConfig : ConfigurationSection
    {

        [ConfigurationProperty("DealMen", DefaultValue = "")]
        public string DealMen
        {
            get { return (string)this["DealMen"]; }
        }
    }
}
