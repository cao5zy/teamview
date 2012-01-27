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
            config = (HardLevelConfig)ConfigurationManager.GetSection("HardLevel");
        }
        public List<int> HardLevels
        {
            get { return new List<int>(config.HardLevels); }
        }

        public int DefaultHardLevel
        {
            get { return config.DefaultHardLevel; }
        }
    }
}
