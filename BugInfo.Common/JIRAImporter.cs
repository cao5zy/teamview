﻿using System;
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
using System.Xml.Linq;
using Dev3Lib.Algorithms;

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
        public void Import(string xmlFileName, string iniDealMan)
        {
            XDocument xDoc = XDocument.Load(xmlFileName);
            (from item in xDoc.Descendants("item")
             select new
             {
                 BugNum = item.Element(XName.Get("key")).Value,
                 Description = item.Element(XName.Get("summary")).Value,
                 Priority = short.Parse(item.Element(XName.Get("priority")).Value.Substring(0, 1)),
                 Version = GetVersionNumber(item.Element(XName.Get("fixVersion")).Value),
             })
                          .SafeForEach(
                          n =>
                          {
                              var item = _bugInfoModel.New();

                              item.bugNum = n.BugNum;
                              item.description = n.Description;
                              item.dealMan = iniDealMan;
                              item.priority = n.Priority;
                              item.size = 0;
                              item.bugStatus = States.Pending;
                              item.version = n.Version;
                              item.createdTime = DateTime.Now;
                              var saveResult = _bugInfoModel.Save();

                              if (saveResult.State)
                              {
                                  _repository.UpdateItem(saveResult.Object);
                                  mImportedList.Add(item.bugNum);
                              }
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

        #endregion

        #region IItemImporter Members


        public IEnumerable<string> ImportedList
        {
            get { return mImportedList; }
        }

        #endregion
    }
}
