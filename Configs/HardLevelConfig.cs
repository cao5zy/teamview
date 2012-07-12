using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TeamView.Configs
{
    class HardLevelConfig : ConfigurationSection
    {
        [ConfigurationProperty("HardLevels", DefaultValue = "0")]
        private string HardLevels
        {
            get
            {
                return this["HardLevels"].ToString();
            }
        }

        public IEnumerable<int> HardLevelList
        {
            get
            {
                return HardLevels.Split(new char[] { ',' }).Select(n => Convert.ToInt32(n));
            }
        }

        [ConfigurationProperty("DefaultHardLevel", DefaultValue = 0)]
        public int DefaultHardLevel
        {
            get
            {
                return Convert.ToInt32(this["DefaultHardLevel"]);
            }
        }

    }
}
