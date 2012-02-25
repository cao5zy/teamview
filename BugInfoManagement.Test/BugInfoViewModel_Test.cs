using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamView.Common;
using TeamView.Common.Dao;
using TeamView.Common.Models;

namespace TeamView.Test
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
            repository.Setup(n => n.GetItem("a-2")).Returns(new TeamView.Common.Entity.BugInfoEntity1 { });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.New();
            model.Current.bugNum = "a-1";
            model.Current.version = "1.0";


            Assert.AreEqual<string>(model.SaveCheck(), BugInfoViewModel.dealManErrorMessage);
        }

        [TestMethod]
        public void CheckState_ChangeStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                });

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

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

            model.Current.bugNum = "a-1";
            model.Current.dealMan = "a";
            model.Current.version = "1.1";
            model.Current.size = 1;
            model.Current.priority = 0;

            var result = model.Save();

            Assert.IsTrue(result.State);
            Assert.AreEqual(States.Pending, result.Object.bugStatus);
        }

        [TestMethod]
        public void Save_New_Check_ItemId_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("a-1")).Returns(new Common.Entity.BugInfoEntity1 { 
                bugNum = "a-1",
            });
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.New();

            model.Current.bugNum = "a-1";
            model.Current.dealMan = "a";
            model.Current.version = "1.1";
            model.Current.size = 1;
            model.Current.priority = 0;

            var result = model.SaveCheck();

            Assert.AreEqual(BugInfoViewModel.theNewItemIdExisting, result);
        }

        [TestMethod]
        public void Save_New_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.New();

            var result = model.Save();

            Assert.IsFalse(result.State);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckDealManStatus("a-1", States.Start)).Returns(false);
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Pending,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Start_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Start_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Start_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Complete_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Complete,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Complete_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Complete,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Complete_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Complete,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Abort_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Abort_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Abort_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            DateTime dtStamp = DateTime.Now;
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>()))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void CommitStatus_Pending_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(
                CreateEntity("a-1", 0, States.Pending, dtStamp)
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("a-1");

            model.Current.bugStatus = States.Start;

            var checkTime = DateTime.Now;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsTrue(result.State);
            Assert.AreEqual(States.Start, model.Current.bugStatus);
            Assert.IsTrue(model.Current.lastStateTime >= checkTime && model.Current.lastStateTime <= DateTime.Now);
        }

        private TeamView.Common.Entity.BugInfoEntity1 CreateEntity(string itemId,
            int sequence,
            string status,
            DateTime timeStamp)
        {
            return new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = itemId,
                    bugStatus = status,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    size = 1,
                    version = "1.0",
                    timeStamp = timeStamp,
                };
        }

        [TestMethod]
        public void CommitStatus_Start_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    lastStateTime = DateTime.Now.AddHours(-1),
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("a-1");

            model.Current.bugStatus = States.Abort;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsTrue(model.Current.fired > 1);
            Assert.AreEqual(States.Abort, model.Current.bugStatus);
            Assert.IsTrue(model.Current.lastStateTime == DateTime.MinValue);
            Assert.AreEqual(61, model.Current.fired);
        }

        [TestMethod]
        public void CommitStatus_Start_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Start,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("a-1");

            model.Current.bugStatus = States.Complete;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsTrue(model.Current.fired > 1);
            Assert.AreEqual(States.Complete, model.Current.bugStatus);
            Assert.IsTrue(model.Current.lastStateTime == DateTime.MinValue);
        }


        [TestMethod]
        public void CommitStatus_Abort_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    bugStatus = States.Abort,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    
                    size = 1,
                    version = "1.0",
                    timeStamp = dtStamp,
                }
                );
            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("a-1");

            model.Current.bugStatus = States.Start;

            DateTime checkTime = DateTime.Now;

            var result = model.CommitStatus();


            Assert.IsTrue(result.State);
            Assert.AreEqual(States.Start, model.Current.bugStatus);
            Assert.IsTrue(model.Current.lastStateTime >= checkTime && model.Current.lastStateTime <= DateTime.Now);
        }

        [TestMethod]
        public void CommitStatus_Complete_To_Pending()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(
                CreateEntity("a-1", 0, States.Complete, dtStamp)
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            model.Current.bugStatus = States.Pending;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.AreEqual(States.Pending, model.Current.bugStatus);
            Assert.IsTrue(model.Current.lastStateTime == DateTime.MinValue);

        }

        [TestMethod]
        public void SaveDoc_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.SaveDoc("a-1", Moq.It.IsAny<byte[]>()));

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.New();

            model.Current.bugNum = "a-1";

            byte[] stream = new byte[] { };
            model.SaveDoc(stream);

            repository.Verify(n => n.SaveDoc("a-1", Moq.It.IsAny<byte[]>()), Moq.Times.Once());

        }

        [TestMethod]
        public void LoadDoc_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            repository.Setup(n => n.LoadDoc("a-1")).Returns(new byte[] { });
            repository.Setup(n => n.GetItem("a-1"))
                .Returns(CreateEntity("a-1", 0, States.Pending, DateTime.Now));
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            byte[] result = model.LoadDoc("a-1");

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void CheckMoveDealMan_Success_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    dealMan = "a",
                    bugStatus = States.Complete,
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);
            repository.Setup(n => n.IsLargestOrder("a-1:1")).Returns(true);
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            var checkResult = model.CheckMoveDealMan("b");

            Assert.IsTrue(string.IsNullOrEmpty(checkResult));
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_SameDealMan_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    dealMan = "a",
                    bugStatus = States.Complete,
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            var checkResult = model.CheckMoveDealMan("a");

            Assert.AreEqual(BugInfoViewModel.dealManDuplicated, checkResult);
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_AbortStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    
                    dealMan = "a",
                    bugStatus = States.Abort,
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            var checkResult = model.CheckMoveDealMan("b");

            Assert.AreEqual(BugInfoViewModel.statusChangeErrorMessage, checkResult);
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_StartStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    
                    dealMan = "a",
                    bugStatus = States.Start,
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            var checkResult = model.CheckMoveDealMan("b");

            Assert.AreEqual(BugInfoViewModel.statusChangeErrorMessage, checkResult);
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_MoveSequence_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            repository.Setup(n => n.GetItem("a-1"))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "a-1",
                    
                    dealMan = "a",
                    bugStatus = States.Complete,
                    timeStamp = dtStamp,
                }
                );

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            repository.Setup(n => n.IsLargestOrder("a-1"))
                .Returns(false);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("a-1");

            var checkResult = model.CheckMoveDealMan("b");

            Assert.AreEqual(BugInfoViewModel.notLargestOrder, checkResult);
        }

        [TestMethod]
        public void MoveDealMan_OnlyMove_Test()
        {
            DateTime t1 = DateTime.Now.AddHours(-1);
            DateTime t2 = DateTime.Now.AddHours(-2);
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            var oldItem = new Common.Entity.BugInfoEntity1
            {
                bugNum = "a-1",
                bugStatus = States.Complete,
                createdTime = t1,
                dealMan = "a",
                description = "description",
                fired = 20,
                hardLevel = 1,
                lastStateTime = t2,
                priority = 1,
                size = 3,
                timeStamp = dtStamp,
                version = "4"
            };
            repository.Setup(n => n.GetItem("a-1"))
                .Returns(oldItem);

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);


            repository.Setup(n => n.IsLargestOrder("a-1:1")).Returns(true);
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            string newDealMan = "b";
            model.Load("a-1");
            var moveResult = model.MoveDealMan(newDealMan);

            Assert.IsTrue(moveResult.State);
            var newItem = moveResult.NewItem;

            Assert.AreEqual("a-1:1", newItem.bugNum);
            Assert.AreEqual(States.Pending, newItem.bugStatus);
            Assert.AreNotEqual(t1, newItem.createdTime);
            Assert.AreEqual("b", newItem.dealMan);
            Assert.AreEqual("description", newItem.description);
            Assert.AreEqual(0, newItem.fired);
            Assert.AreEqual(oldItem.hardLevel, newItem.hardLevel);
            Assert.AreEqual(DateTime.MinValue, newItem.lastStateTime);
            Assert.AreEqual(oldItem.priority, newItem.priority);
            Assert.AreEqual(oldItem.size, newItem.size);
            Assert.AreEqual(DateTime.MinValue, newItem.timeStamp);
            Assert.AreEqual(oldItem.version, newItem.version);
        }

        [TestMethod]
        public void MoveDealMan_Move_Priority_Size_Test()
        {
            DateTime t1 = DateTime.Now.AddHours(-1);
            DateTime t2 = DateTime.Now.AddHours(-2);
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime dtStamp = DateTime.Now;

            var oldItem = new Common.Entity.BugInfoEntity1
            {
                bugNum = "a-1",
                bugStatus = States.Complete,
                
                createdTime = t1,
                dealMan = "a",
                description = "description",
                fired = 20,
                hardLevel = 1,
                lastStateTime = t2,
                priority = 1,
                size = 3,
                timeStamp = dtStamp,
                version = "4"
            };
            repository.Setup(n => n.GetItem("a-1"))
                .Returns(oldItem);

            repository.Setup(n => n.CheckTimeStamp("a-1", dtStamp)).Returns(true);

            repository.Setup(n => n.IsLargestOrder("a-1:1")).Returns(true);

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("a-1");
            string newDealMan = "b";
            int newSize = 5;
            int newPriority = 4;
            var moveResult = model.MoveDealMan(newDealMan, newSize, newPriority);

            Assert.IsTrue(moveResult.State);
            var newItem = moveResult.NewItem;

            Assert.AreEqual("a-1:1", newItem.bugNum);
            Assert.AreEqual(States.Pending, newItem.bugStatus);
            Assert.AreNotEqual(t1, newItem.createdTime);
            Assert.AreEqual(newDealMan, newItem.dealMan);
            Assert.AreEqual("description", newItem.description);
            Assert.AreEqual(0, newItem.fired);
            Assert.AreEqual(oldItem.hardLevel, newItem.hardLevel);
            Assert.AreEqual(DateTime.MinValue, newItem.lastStateTime);
            Assert.AreEqual(newPriority, newItem.priority);
            Assert.AreEqual(newSize, newItem.size);
            Assert.AreEqual(DateTime.MinValue, newItem.timeStamp);
            Assert.AreEqual(oldItem.version, newItem.version);
        }
    }
}
