using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TeamView.Report2.DAL.Interfaces;
using TeamView.Report2.Entities;
using System.Collections.Generic;
using Dev3Lib;
using Autofac;
using TeamView.Report2.BLL;
using Rhino.Mocks.Constraints;

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
            int logStartType = 2;
            int logEndType = 3;

            MockRepository mock = new MockRepository();
            var changeLogDal = mock.StrictMock<IChangeLog>();

            using (mock.Record())
            {
                changeLogDal.GetLogs(bugNum, startDate, endDate);
                LastCall.Constraints(Is.Anything(), Is.Anything(), Is.Anything());
                LastCall.Return(new List<ChangeLogEntity>{ 
                    new ChangeLogEntity{
                        LogTypeID = logStartType,
                        CreateDate = startDate,
                    },
                    new ChangeLogEntity{
                        LogTypeID = logEndType,
                        CreateDate = startDate.AddHours(1),
                    },
                    new ChangeLogEntity{
                        LogTypeID = logStartType,
                        CreateDate = startDate.AddHours(2),
                    },
                    new ChangeLogEntity{
                        LogTypeID = logEndType,
                        CreateDate = startDate.AddHours(3),
                    },
                });
            }

            DependencyFactory.SetContainer(() =>
            {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterType<ChangeLogLogic>();
                builder.RegisterInstance(changeLogDal).As<IChangeLog>();

                return builder.Build();
            });

            using (DependencyFactory.BeginScope())
            {
                var changeLogLogic = DependencyFactory.Resolve<ChangeLogLogic>();

                var duration = changeLogLogic.CalculateCurrentBurnedMins(bugNum, startDate, endDate);

                Assert.AreEqual(120, duration);
            }
        }

        [TestMethod]
        public void CalculateCurrentBurnedMins_TheFirstIsEndLogType_ReturnList()
        {
            string bugNum = "no";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(3);
            int logStartType = 2;
            int logEndType = 3;

            MockRepository mock = new MockRepository();
            var changeLogDal = mock.StrictMock<IChangeLog>();

            using (mock.Record())
            {
                changeLogDal.GetLogs(bugNum, startDate, endDate);
                LastCall.Constraints(Is.Anything(), Is.Anything(), Is.Anything());
                LastCall.Return(new List<ChangeLogEntity>{ 
                    new ChangeLogEntity{
                        LogTypeID = logEndType,
                        CreateDate = startDate,
                    },
                    new ChangeLogEntity{
                        LogTypeID = logStartType,
                        CreateDate = startDate.AddHours(1),
                    },
                    new ChangeLogEntity{
                        LogTypeID = logEndType,
                        CreateDate = startDate.AddHours(2),
                    },
                    new ChangeLogEntity{
                        LogTypeID = logStartType,
                        CreateDate = startDate.AddHours(3),
                    },
                });
            }

            DependencyFactory.SetContainer(() =>
            {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterType<ChangeLogLogic>();
                builder.RegisterInstance(changeLogDal).As<IChangeLog>();

                return builder.Build();
            });

            using (DependencyFactory.BeginScope())
            {
                var changeLogLogic = DependencyFactory.Resolve<ChangeLogLogic>();

                var duration = changeLogLogic.CalculateCurrentBurnedMins(bugNum, startDate, endDate);

                Assert.AreEqual(60, duration);
            }
        }
    }
}
