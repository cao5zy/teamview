using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BugInfoManagement.Configs
{
    public class NotificationSection : ConfigurationSection
    {
        [ConfigurationProperty("Programmer", DefaultValue = "")]
        public string Programmer
        {
            get
            {
                return (string)this["Programmer"];
            }
        }

        [ConfigurationProperty("FrequenceInMinutes", DefaultValue = "10")]
        public string FrequeneceInMinutes
        {
            get
            {
                return (string)this["FrequenceInMinutes"];
            }
        }
    }
}
