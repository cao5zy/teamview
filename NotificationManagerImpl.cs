using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using FxLib.Algorithms;

namespace TeamView
{
    public class NotificationManagerImpl : INotificationManager
    {
        public Dao.IBugInfoManagement BugInfoManagement { get; set; }

        public INotificationSetting NotificationSetting { get; set; }

        private bool mHasIncommingList = false;

        private const string LocalStoreFileName = "LocalBugList.xml";
        #region INotificationManager Members
        public bool HasIncommingList
        {
            get { return mHasIncommingList; }
        }

        public List<string> GetInCommingList()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            List<string> bugNumsInDB = LoadBugsInDB(NotificationSetting.ProgrammerName);
            List<string> bugNumsInLocal = LoadBugsInLocal();

            mHasIncommingList = bugNumsInDB.SafeExists(
                n => !bugNumsInLocal.SafeExists(m => m == n));

            if(mHasIncommingList)
                WriteToLocal(bugNumsInDB);
        }

        private void WriteToLocal(List<string> bugNumsInDB)
        {
            XmlDocument doc = new XmlDocument();
            var root = doc.CreateElement("BugList");
            doc.AppendChild(root);
            bugNumsInDB.SafeForEach(
                n => {
                    var element = doc.CreateElement("BugNum");
                    element.SetAttribute("Value", n);
                    root.AppendChild(element);
                }
                );
            string fileName = GetLocalStorageFileName();
            doc.Save(fileName);

        }

        private static string GetLocalStorageFileName()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), LocalStoreFileName);
        }

        private List<string> LoadBugsInLocal()
        {
            List<string> bugList = new List<string>();
            string fileName = GetLocalStorageFileName();

            if (!File.Exists(fileName))
                return new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            var nodeList = doc.GetElementsByTagName("BugNum");
            foreach (var node in nodeList)
            {
                bugList.Add(((XmlElement)node).GetAttribute("Value"));
            }

            return bugList;
        }

        private List<string> LoadBugsInDB(string programmerName)
        {
            return this.BugInfoManagement.QueryByDealMan(programmerName).ConvertAll(n => n.BugNum);
        }

        #endregion
    }
}
