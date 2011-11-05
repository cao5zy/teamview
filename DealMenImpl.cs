using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfoManagement.Entity;
using System.Configuration;
using FxLib.Algorithms;

namespace BugInfoManagement
{
    public class DealMenImpl : IDealMen
    {
        public static List<Entity.ProgrammerBaseInfo> DEALMEN;
        static DealMenImpl()
        {
            try
            {
                var config = (Configs.DealManConfig)ConfigurationManager.GetSection("DealManConfig");
                if (string.IsNullOrEmpty(config.DealMen))
                    DEALMEN = new List<ProgrammerBaseInfo>();
                else
                    DEALMEN = config.DealMen.Split(new char[]{','}).SafeConvertAll(
                    n => new ProgrammerBaseInfo
                    {
                        ID = 0,
                        Name = n,
                    }
                    );
            }
            catch (Exception ex)
            { 

            }
        }
        #region IDealMen Members

        public List<BugInfoManagement.Entity.ProgrammerBaseInfo> DealMen
        {
            get { return DEALMEN; }
        }

        #endregion
    }
}
