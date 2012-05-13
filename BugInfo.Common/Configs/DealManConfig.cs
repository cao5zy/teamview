using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TeamView.Common.Configs
{
    public class DealManConfig : ConfigurationSection
    {

        [ConfigurationProperty("DealMen", DefaultValue = "")]
        public string DealMen
        {
            get { return (string)this["DealMen"]; }
        }

        [ConfigurationProperty("CurrentLogin", DefaultValue = "")]
        public string CurrentLogin
        {
            get
            {
                return (string)this["CurrentLogin"];
            }
        }

    }
}
