using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TeamView.Entity;
using TeamView.Common;
using TeamView.Dao;
using System.Text.RegularExpressions;
using TeamView.Common.Models;
using TeamView.Common.Dao;

namespace TeamView.Common
{
    public class JIRAImporter : IItemImporter
    {
        #region IItemImporter Members
        private List<string> mImportedList = new List<string>();
        private static Regex versionRegex = new Regex(@"\((\d(.\d)?)\)");
        private BugInfoViewModel _bugInfoModel;
        private IBugInfoRepository _repository;
        public JIRAImporter(BugInfoViewModel bugInfoModel,
            IBugInfoRepository repository)
        {
            _bugInfoModel = bugInfoModel;
            _repository = repository;
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
                var item = _bugInfoModel.New();

                item.bugNum = GetSubElementInnerText(n, "key");
                item.description= GetSubElementInnerText(n, "summary");
                item.dealMan = reporter;
                item.priority = short.Parse(GetSubElementInnerText(n,"priority").Substring(0,1));
                item.size = 0;
                item.bugStatus = States.Pending;
                item.version = GetVersionNumber(GetSubElementInnerText(n, "fixVersion"));

                var saveResult = _bugInfoModel.Save();

                if(saveResult.State)
                {
                    _repository.UpdateItem(saveResult.Object);
                    mImportedList.Add(item.bugNum);
                }
                else
                {
                    mImportedList.Add(item.bugNum + " save failed");
                }
            }
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
