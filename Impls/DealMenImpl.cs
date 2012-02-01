using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Entity;
using System.Configuration;
using FxLib.Algorithms;
using TeamView.Abstracts;

namespace TeamView.Impls
{
    public class DealMenImpl : IDealMen
    {
        private static List<Entity.ProgrammerBaseInfo> DEALMEN;
        private static string currentLogin;
        static DealMenImpl()
        {
            try
            {
                var config = (Configs.DealManConfig)ConfigurationManager.GetSection("DealManConfig");
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

        public List<TeamView.Entity.ProgrammerBaseInfo> DealMen
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
