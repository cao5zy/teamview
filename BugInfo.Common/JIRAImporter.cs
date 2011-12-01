using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using BugInfoManagement.Entity;
using BugInfoManagement.Common;
using BugInfoManagement.Dao;

namespace BugInfo.Common
{
    public class JIRAImporter : IItemImporter
    {
        #region IItemImporter Members
        private IBugInfoManagement mBugInfoManagement;
        private List<string> mImportedList = new List<string>();
        public JIRAImporter(IBugInfoManagement bugInfoManagement)
        {
            mBugInfoManagement = bugInfoManagement;
        }
        public void Import(string xmlFileName, string version, string reporter, string iniDealMan)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFileName);

            List<BugInfoEntity> items = new List<BugInfoEntity>();
            foreach (var node in doc.SelectNodes("//item"))
            {
                XmlElement n = node as XmlElement;
                if (n == null) continue;
                items.Add(
                    new BugInfoEntity
                    {
                        BugNum = GetSubElementInnerText(n, "key"),
                        Description = GetSubElementInnerText(n, "summary"),
                        DealMan = iniDealMan,
                        CreatedBy = reporter,
                        Priority = short.Parse(GetSubElementInnerText(n,"priority").Substring(0,1)),
                        Size = 0,
                        TimeStamp = DateTime.Now,
                        BugStatus = States.Pending,
                        Version = version,
                    }
                    );
            }

            items.ForEach(
                n =>
                {
                    try
                    {
                        mBugInfoManagement.AddBugInfo(n);
                        mImportedList.Add(n.BugNum);
                    }
                    catch (Exception ex)
                    { }
                }
                );
        }

        private static string GetSubElementInnerText(XmlElement element, string subElementName)
        {
            return element.GetElementsByTagName(subElementName).Item(0).InnerText;
        }

        #endregion

        #region IItemImporter Members


        public IEnumerable<string> ImportedList
        {
            get { return mImportedList; }
        }

        #endregion
    }
}
