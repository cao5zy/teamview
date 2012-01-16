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
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0)).Returns(new TeamView.Common.Entity.BugInfoEntity1 { });

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
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
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
                });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load(string.Empty, 0);

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

            Assert.IsFalse(result.State);
        }

        [TestMethod]
        public void Save_Calculate_Fired_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime t1 = DateTime.Now.AddHours(-1);
            repository.Setup(n => n.GetItem("1", 0)).Returns(new TeamView.Common.Entity.BugInfoEntity1
            {
                bugNum = "1",
                moveSequence = 0,
                lastStateTime = t1,
                bugStatus = StatesConverter.ToStateString(StatesEnum.Start),
                fired = 0,
                version = "1",
                dealMan = "a",

            });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            model.Current.bugStatus = StatesConverter.ToStateString(StatesEnum.Complete);

            var result = model.Save();

            Assert.IsTrue(result.State);

            Assert.AreEqual(60, result.Object.fired);
            Assert.AreEqual(t1, result.Object.lastStateTime);
        }

        [TestMethod]
        public void Save_Calculate_NotChanged_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            DateTime t1 = DateTime.Now.AddHours(-1);
            repository.Setup(n => n.GetItem("1", 0)).Returns(new TeamView.Common.Entity.BugInfoEntity1
            {
                bugNum = "1",
                moveSequence = 0,
                lastStateTime = t1,
                bugStatus = StatesConverter.ToStateString(StatesEnum.Complete),
                fired = 1,
                version = "1",
                dealMan = "a",

            });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            model.Current.bugStatus = StatesConverter.ToStateString(StatesEnum.Start);

            var result = model.Save();

            Assert.IsTrue(result.State);

            Assert.AreEqual(1, result.Object.fired);
            Assert.AreNotEqual(t1, result.Object.lastStateTime);

        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Pending_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Start_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Start_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Start_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Complete_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Complete_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Abort;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Complete_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Abort_To_Pending_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Pending;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void ChangeStatusCheck_Abort_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Start;

            Assert.AreEqual(model.ChangeStatusCheck(), string.Empty);
        }

        [TestMethod]
        public void ChangeStatusCheck_Abort_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>(), 0))
                .Returns(
                new TeamView.Common.Entity.BugInfoEntity1
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

            model.Load(string.Empty, 0);

            model.Current.bugStatus = States.Complete;

            Assert.AreEqual(model.ChangeStatusCheck(), BugInfoViewModel.statusChangeErrorMessage);
        }

        [TestMethod]
        public void CommitStatus_Pending_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(
                CreateEntity("1", 0, States.Pending)
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("1", 0);

            model.Current.bugStatus = States.Start;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsFalse(result.UpdateDuration);
            Assert.AreEqual(StatesEnum.Start, result.NewStatus);
        }

        private TeamView.Common.Entity.BugInfoEntity1 CreateEntity(string itemId,
            int sequence,
            string status)
        {
            return new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = itemId,
                    bugStatus = status,
                    dealMan = "a",
                    description = "hello",
                    fired = 1,
                    hardLevel = 1,
                    moveSequence = sequence,
                    size = 1,
                    version = "1.0"
                };
        }

        [TestMethod]
        public void CommitStatus_Start_To_Abort_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(
                CreateEntity("1", 0, States.Start)
                );

            repository.Setup(n => n.GetLastestStartTime("1", 0))
                .Returns(
                DateTime.Now.AddMinutes(-2)
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("1", 0);

            model.Current.bugStatus = States.Abort;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsTrue(result.UpdateDuration);
            Assert.IsTrue(result.NewFired > 1);
            Assert.AreEqual(StatesEnum.Abort, result.NewStatus);
        }

        [TestMethod]
        public void CommitStatus_Start_To_Complete_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(
                CreateEntity("1", 0, States.Start)
                );

            repository.Setup(n => n.GetLastestStartTime("1", 0))
                .Returns(
                DateTime.Now.AddMinutes(-2)
                );

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("1", 0);

            model.Current.bugStatus = States.Complete;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsTrue(result.UpdateDuration);
            Assert.IsTrue(result.NewFired > 1);
            Assert.AreEqual(StatesEnum.Complete, result.NewStatus);
        }

        [TestMethod]
        public void CommitStatus_Complete_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(
                CreateEntity("1", 0, States.Complete)
                );

            repository.Setup(n => n.GetLastestStartTime("1", 0))
                .Verifiable();

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("1", 0);

            model.Current.bugStatus = States.Start;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsFalse(result.UpdateDuration);
            Assert.AreEqual(StatesEnum.Start, result.NewStatus);
        }

        [TestMethod]
        public void CommitStatus_Abort_To_Start_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(
                CreateEntity("1", 0, States.Abort)
                );

            repository.Setup(n => n.GetLastestStartTime("1", 0))
                .Verifiable();

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.Load("1", 0);

            model.Current.bugStatus = States.Start;

            var result = model.CommitStatus();

            Assert.IsTrue(result.State);
            Assert.IsFalse(result.UpdateDuration);
            Assert.AreEqual(StatesEnum.Start, result.NewStatus);
        }

        [TestMethod]
        public void SaveDoc_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.SaveDoc("1", Moq.It.IsAny<byte[]>()));

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.New();

            model.Current.bugNum = "1";

            byte[] stream = new byte[] { };
            model.SaveDoc(stream);

            repository.Verify(n => n.SaveDoc("1", Moq.It.IsAny<byte[]>()), Moq.Times.Once());

        }

        [TestMethod]
        public void LoadDoc_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            repository.Setup(n => n.LoadDoc("1")).Returns(new byte[] { });
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(CreateEntity("1", 0, States.Pending));
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            byte[] result = model.LoadDoc("1");

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void CheckMoveDealMan_Success_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    moveSequence = 0,
                    dealMan = "a",
                    bugStatus = States.Complete
                }
                );
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            var checkResult = model.CheckMoveDealMan("b");

            Assert.IsTrue(string.IsNullOrEmpty(checkResult));
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_SameDealMan_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    moveSequence = 0,
                    dealMan = "a",
                    bugStatus = States.Complete
                }
                );
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            var checkResult = model.CheckMoveDealMan("a");

            Assert.AreEqual(BugInfoViewModel.dealManDuplicated, checkResult);
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_AbortStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    moveSequence = 0,
                    dealMan = "a",
                    bugStatus = States.Abort
                }
                );
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            var checkResult = model.CheckMoveDealMan("b");

            Assert.AreEqual(BugInfoViewModel.statusChangeErrorMessage, checkResult);
        }

        [TestMethod]
        public void CheckMoveDealMan_Fail_Due_to_StartStatus_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(new TeamView.Common.Entity.BugInfoEntity1
                {
                    bugNum = "1",
                    moveSequence = 0,
                    dealMan = "a",
                    bugStatus = States.Start
                }
                );
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            model.Load("1", 0);

            var checkResult = model.CheckMoveDealMan("b");

            Assert.AreEqual(BugInfoViewModel.statusChangeErrorMessage, checkResult);
        }

        [TestMethod]
        public void MoveDealMan_OnlyMove_Test()
        {
            DateTime t1 = DateTime.Now.AddHours(-1);
            DateTime t2 = DateTime.Now.AddHours(-2);
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            var oldItem = new Common.Entity.BugInfoEntity1
            {
                bugNum = "1",
                bugStatus = States.Complete,
                moveSequence = 0,
                createdTime = t1,
                dealMan = "a",
                description = "description",
                fired = 20,
                hardLevel = 1,
                lastStateTime = t2,
                priority = 1,
                size = 3,
                timeStamp = DateTime.Now,
                version = "4"
            };
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(oldItem);
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            string newDealMan = "b";
            var moveResult = model.MoveDealMan(newDealMan);

            Assert.IsTrue(moveResult.State);
            var newItem = moveResult.NewItem;

            Assert.AreEqual(oldItem.bugNum, newItem.bugNum);
            Assert.AreEqual(States.Pending, newItem.bugStatus);
            Assert.AreEqual(1, newItem.moveSequence);
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
            var oldItem = new Common.Entity.BugInfoEntity1
            {
                bugNum = "1",
                bugStatus = States.Complete,
                moveSequence = 0,
                createdTime = t1,
                dealMan = "b",
                description = "description",
                fired = 20,
                hardLevel = 1,
                lastStateTime = t2,
                priority = 1,
                size = 3,
                timeStamp = DateTime.Now,
                version = "4"
            };
            repository.Setup(n => n.GetItem("1", 0))
                .Returns(oldItem);
            BugInfoViewModel model = new BugInfoViewModel(repository.Object);

            string newDealMan = "b";
            int newSize = 5;
            int newPriority = 4;
            var moveResult = model.MoveDealMan(newDealMan, newSize, newPriority);

            Assert.IsTrue(moveResult.State);
            var newItem = moveResult.NewItem;

            Assert.AreEqual(oldItem.bugNum, newItem.bugNum);
            Assert.AreEqual(States.Pending, newItem.bugStatus);
            Assert.AreEqual(1, newItem.moveSequence);
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
