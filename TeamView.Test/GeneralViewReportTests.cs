using Autofac;
using Dev3Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Report2.BLL;
using TeamView.Report2.DAL.Interfaces;
using TeamView.Report2.Entities;
using TeamView.Report2.GeneralView;

namespace TeamView.Test
{
    [TestClass]
    public class GeneralViewReportTests
    {
        [TestMethod]
        [TestCategory("must")]
        public void GetList_ReturnList()
        {
            string programmer = "cao";
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(1);

            string bugNum = "no1";
            string dealMan = "cao";
            string description = "desc";
            int size = 5;
            int fired = 2;
            int currentBurned = 1;

            MockRepository mock = new MockRepository();

            var bugInfo = mock.StrictMock<IBugInfoLogic>();
            var changeLog = mock.StrictMock<IChangeLogLogic>();
            var conn = mock.DynamicMock<IDbContext>();

            using (mock.Record())
            {
                bugInfo.AllBugNums(programmer);
                LastCall.Return<List<string>>(new List<string> { 
                    bugNum
                });

                changeLog.HasLogs(bugNum, startDate, endDate);
                LastCall.Return(true);

                bugInfo.GetSimpleBugInfo(bugNum);
                LastCall.Return(new SimpleBugInfo { 
                    bugNum = bugNum,
                    dealMan = dealMan,
                    description = description,
                    fired = fired,
                    size = size,
                });

                changeLog.CalculateCurrentBurnedMins(bugNum, startDate, endDate);
                LastCall.Return(currentBurned);
            }
            DependencyFactory.SetContainer(() =>
            {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterInstance(bugInfo).As<IBugInfoLogic>();
                builder.RegisterInstance(changeLog).As<IChangeLogLogic>();
                builder.RegisterInstance(conn).As<IDbContext>();
                return builder.Build();
            });

            var list = GeneralViewReport.GetList(programmer, startDate, endDate);

            Assert.IsTrue(list.Length == 1);
            Assert.AreEqual(bugNum, list[0].BugNum);
            Assert.AreEqual(description, list[0].Description);
            Assert.AreEqual(size, list[0]._sizeInMins);
            Assert.AreEqual(fired, list[0]._burnedMins);
            Assert.AreEqual(currentBurned, list[0]._currentBurnedMins);
        }
    }
}
