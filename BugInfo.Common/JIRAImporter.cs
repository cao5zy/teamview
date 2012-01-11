using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TeamView.Entity;
using TeamView.Common;
using TeamView.Dao;
using System.Text.RegularExpressions;

namespace TeamView.Common
{
    public class JIRAImporter : IItemImporter
    {
        #region IItemImporter Members
        private IBugInfoManagement mBugInfoManagement;
        private List<string> mImportedList = new List<string>();
        private static Regex versionRegex = new Regex(@"\((\d(.\d)?)\)");
        public JIRAImporter(IBugInfoManagement bugInfoManagement)
        {
            mBugInfoManagement = bugInfoManagement;
        }
        public void Import(string xmlFileName,string reporter, string iniDealMan)
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
                        Version = GetVersionNumber(GetSubElementInnerText(n, "fixVersion")),
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


        private string GetVersionNumber(string versionStr)
        {
            var match = versionRegex.Match(versionStr);
            if (match.Success)
                return match.Groups[1].Value;
            else
                return versionStr;
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
