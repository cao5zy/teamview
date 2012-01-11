using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TeamView
{
    public class NotificationSettingImpl : INotificationSetting
    {
        static Configs.NotificationSection NotificationSection;
        static NotificationSettingImpl()
        {
            NotificationSection = (Configs.NotificationSection)ConfigurationManager.GetSection("NotificationSection");
        }
        #region INotificationSetting Members

        public string ProgrammerName
        {
            get { return NotificationSection.Programmer; }
        }

        public int FrequenceInMinutes
        {
            get
            {
                if (string.IsNullOrEmpty(NotificationSection.FrequeneceInMinutes))
                {
                    return 10;
                }
                else
                    return Convert.ToInt32(NotificationSection.FrequeneceInMinutes);
            }
        }

        #endregion
    }
}
