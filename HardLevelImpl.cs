using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Configs;
using System.Configuration;

namespace TeamView
{
    class HardLevelImpl : IHardLevel
    {
        private static HardLevelConfig config;
        static HardLevelImpl()
        {
            config = (HardLevelConfig)ConfigurationManager.GetSection("HardLevelConfig");
        }
        public List<int> HardLevels
        {
            get { return new List<int>(config.HardLevelList); }
        }

        public int DefaultHardLevel
        {
            get { return config.DefaultHardLevel; }
        }
    }
}
