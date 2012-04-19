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
using System.Xml.Linq;
using Dev3Lib.Algorithms;
using System.Configuration;
using TeamView.Common.Entity;
using System.Transactions;
using System.IO;

namespace JIRAImporter
{
    public sealed class JIRAImporter : IItemImporter
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
        public void Import(string xmlFileName)
        {
            Regex mapRegex = new Regex(@"([\w\s]+)\:([\w\s]+)");
            var assigneeMap = ConfigurationManager.AppSettings["AssigneeMap"]
                .Split(new char[] { ',' })
                .SafeFindAll(n => mapRegex.IsMatch(n))
                .SafeConvertAll(n =>
                {
                    Match match = mapRegex.Match(n);
                    return new
                    {
                        TeamViewDealMan = match.Groups[1].Value,
                        JIRAAssignee = match.Groups[2].Value,
                    };
                });

            XDocument xDoc = XDocument.Load(xmlFileName);
            (from item in xDoc.Descendants("item")
             where assigneeMap.SafeExists(n => n.JIRAAssignee == item.Element(XName.Get("assignee")).Value)
             select new
             {
                 BugNum = item.Element(XName.Get("key")).Value,
                 Description = item.Element(XName.Get("summary")).Value,
                 Priority = short.Parse(item.Element(XName.Get("priority")).Value.Substring(0, 1)),
                 Version = GetVersionNumber(item.Element(XName.Get("fixVersion")).Value),
                 JIRAAssignee = item.Element(XName.Get("assignee")).Value,
                 SizeInHours = (from customField in item.Element(XName.Get("customfields")).Descendants("customfield")
                                where customField.Element(XName.Get("customfieldname")).Value == "Size"
                                select customField)
                                .Single()
                                .Descendants("customfieldvalue")
                                .Single()
                                .Value
                                .ToDecimal()
                                .ToInt32()

             })
            .SafeForEach(
            n =>
            {
                var existingItem = _bugInfoModel.Load(n.BugNum);
                if (existingItem == null)
                {
                    var item = _bugInfoModel.New();

                    item.bugNum = n.BugNum;
                    item.description = n.Description;
                    item.dealMan = assigneeMap.SafeFind(m => m.JIRAAssignee == n.JIRAAssignee).TeamViewDealMan;
                    item.priority = n.Priority;
                    item.size = n.SizeInHours * 60;
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
                else
                {
                    if (existingItem.dealMan != assigneeMap.SafeFind(m => m.JIRAAssignee == n.JIRAAssignee).TeamViewDealMan)
                    {
                        //dealMan changed
                        Console.WriteLine(string.Format("Deal Man changed from {0} to {1}", existingItem.dealMan, assigneeMap.SafeFind(m => m.JIRAAssignee == n.JIRAAssignee).TeamViewDealMan));
                    }
                    else
                    {
                        if (existingItem.bugStatus == States.Complete)
                        {
                            //assume that the issues fixed in 
                            existingItem.bugStatus = States.Pending;
                            RecordBugFeedBack(existingItem.bugNum);
                        }


                        if (existingItem.size != n.SizeInHours * 60)
                        {
                            //size changed
                            existingItem.size = n.SizeInHours * 60;
                            RecordSizeChanged(existingItem.size, n.SizeInHours * 60);
                        }

                        string error = SaveFlow(existingItem);
                        if (!string.IsNullOrEmpty(error))
                        {
                            Console.WriteLine(string.Format("Fail to change {0}", existingItem.bugStatus));
                        }
                        else
                            mImportedList.Add(string.Format("{0} status changed", existingItem.bugNum));
                    }
                }
            }
            );
        }

        private static void RecordSizeChanged(int originalSize, int newSize)
        {
            string fileName = "ImportSizeChanged.xml";
            if (!File.Exists(fileName))
            {
                File.AppendAllText(fileName, @"<SizeChanges/>");
            }
            XDocument xDoc = XDocument.Load(fileName);
            xDoc.Element("SizeChanges")
                .AddFirst(new XElement("Change",
                    new XElement[] {
                        new XElement("Time",DateTime.Now),
                        new XElement("Old", originalSize),
                        new XElement("New", newSize),
                    }));
            xDoc.Save(fileName);
        }

        private static void RecordBugFeedBack(string bugNum)
        {
            string fileName = "ImportBugFeedback.xml";
            if (!File.Exists(fileName))
            {
                File.AppendAllText(fileName, @"<BugFeedBacks/>");
            }
            XDocument xDoc = XDocument.Load(fileName);
            xDoc.Element("BugFeedBacks")
                .AddFirst(new XElement("BugFeedBack",
                    new XElement[] {
                        new XElement("Time",DateTime.Now),
                        new XElement("BugNum", bugNum)
                    }));
            xDoc.Save(fileName);
        }

        private string SaveFlow(BugInfoEntity1 item)
        {
            var checkResult = _bugInfoModel.ChangeStatusCheck();
            if (!string.IsNullOrEmpty(checkResult))
            {
                return checkResult;
            }

            var result = _bugInfoModel.CommitStatus();

            using (TransactionScope trans = new TransactionScope())
            {
                _repository.UpdateItem(item);
                _repository.AddLog(item.bugNum, string.Empty, result.LogTypeId);
                trans.Complete();
            }

            return string.Empty;
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
