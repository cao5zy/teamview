using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugInfo.Common.Dao;
using BugInfo.Common.Models;
using BugInfoManagement.Common;

namespace BugInfoManagement.Test
{
    /// <summary>
    /// Summary description for BugInfoViewModel_Test
    /// </summary>
    [TestClass]
    public class BugInfoViewModel_Test
    {
        public BugInfoViewModel_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CheckState_CheckNew_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>())).Returns(new BugInfo.Common.Entity.BugInfoEntity1 { });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.New();
            model.Current.bugNum = "1";
            model.Current.version = "1.0";


            Assert.AreEqual<string>(model.SaveCheck(), BugInfoViewModel.dealManErrorMessage);
        }

        [TestMethod]
        public void CheckState_ChangeStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(new BugInfo.Common.Entity.BugInfoEntity1 { 
                    bugNum = "1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.SaveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void Save_NewStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.New();

            model.Current.bugNum = "1";
            model.Current.dealMan = "a";
            model.Current.version = "1.1";
            model.Current.size = 1;
            model.Current.priority = 0;

            var result = model.Save();

            Assert.IsTrue(result.State);
            Assert.AreEqual(States.Pending, result.Object.bugStatus);
        }

        [TestMethod]
        public void Save_New_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.New();

            var result = model.Save();

            Assert.IsTrue(result.State);
        }

        [TestMethod]
        public void MoveState_Pending_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.MoveCheck(),string.Empty);
        }

        [TestMethod]
        public void MoveState_Pending_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void MoveState_Pending_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void MoveState_Pending_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void MoveState_Start_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void MoveState_Start_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.MoveCheck(), string.Empty);
        }

        [TestMethod]
        public void MoveState_Start_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.MoveCheck(), string.Empty);
        }

        [TestMethod]
        public void MoveState_Complete_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Complete,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.MoveCheck(), string.Empty);
        }

        [TestMethod]
        public void MoveState_Complete_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Complete,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void MoveState_Complete_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Complete,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.MoveCheck(), string.Empty);
        }

        [TestMethod]
        public void MoveState_Abort_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void MoveState_Abort_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.MoveCheck(), string.Empty);
        }

        [TestMethod]
        public void MoveState_Abort_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new BugInfo.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = 0,
                    size = 1,
                    version = "1.0"
                }
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.MoveCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }
    }
}
