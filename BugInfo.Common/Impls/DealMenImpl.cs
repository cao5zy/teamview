using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Entity;
using System.Configuration;
using FxLib.Algorithms;
using TeamView.Common.Abstracts;
using TeamView.Common.Entity;
using TeamView.Common.Configs;

namespace TeamView.Common.Impls
{
    public class DealMenImpl : IDealMen
    {
        private static List<Entity.ProgrammerBaseInfo> DEALMEN;
        private static string currentLogin;
        static DealMenImpl()
        {
            try
            {
                var config = (DealManConfig)ConfigurationManager.GetSection("DealManConfig");
                if (string.IsNullOrEmpty(config.DealMen))
                {
                    DEALMEN = new List<ProgrammerBaseInfo>();
                    currentLogin = string.Empty;
                }
                else
                {
                    DEALMEN = config.DealMen.Split(new char[] { ',' }).SafeConvertAll(
                    n => new ProgrammerBaseInfo
                    {
                        ID = 0,
                        Name = n,
                    }
                    );
                    currentLogin = config.CurrentLogin;
                }
            }
            catch (Exception ex)
            { 

            }
        }
        #region IDealMen Members

        public List<ProgrammerBaseInfo> DealMen
        {
            get { return DEALMEN; }
        }

        #endregion


        public string CurrentLogin
        {
            get { return currentLogin; }
        }
    }
}
