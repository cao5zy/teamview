﻿using BugInfoManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
namespace BugInfoManagement.Test
{
    
    
    /// <summary>
    ///This is a test class for NotificationManagerImplTest and is intended
    ///to contain all NotificationManagerImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NotificationManagerImplTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Refresh
        ///</summary>
        [TestMethod()]
        public void RefreshTest()
        {
            NotificationManagerImpl target = new NotificationManagerImpl();
            INotificationSetting setting = MockRepository.GenerateMock<INotificationSetting>();
            setting.Stub(n => n.ProgrammerName).Return("Hello");
            target.NotificationSetting = setting;
            target.Refresh();
        }
    }
}
