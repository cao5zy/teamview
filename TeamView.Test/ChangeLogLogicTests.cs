using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TeamView.Report2.DAL.Interfaces;
using TeamView.Report2.Entities;
using System.Collections.Generic;

namespace TeamView.Test
{
    [TestClass]
    public class ChangeLogLogicTests
    {
        [TestMethod]
        public void CalculateCurrentBurnedMins_CompleteRange_ReturnList()
        {
            string bugNum = "no";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(3);
            int logStartType = 1;
            int logEndType = 2;

            MockRepository mock = new MockRepository();
            var changeLogDal = mock.StrictMock<IChangeLog>();

            using (mock.Record())
            {
                changeLogDal.GetLogs(bugNum, startDate, endDate);
                LastCall.Return(new List<ChangeLogEntity>{ 
                    new ChangeLogEntity{
                        LogTypeID = logStartType,
                        CreateDate = startDate,
                    }
                });
            }
        }
    }
}
