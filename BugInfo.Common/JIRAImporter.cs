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
        public JIRAImporter(IBugInfoManagement bugInfoManagement)
        {
            mBugInfoManagement = bugInfoManagement;
        }
        public void Import(string xmlFileName, string version, string reporter, string iniDealMan, int priority)
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
                        Priority = (short)priority,
                        Size = 0,
                        TimeStamp = DateTime.Now,
                        BugStatus = States.Pending
                    }
                    );
            }

            items.ForEach(
                n =>
                {
                    try
                    {
                        mBugInfoManagement.AddBugInfo(n);
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
    }
}
