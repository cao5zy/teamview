using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugInfo.Common.Dao;
using BugInfo.Common.Models;

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
        public void CheckState_New_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();
            repository.Setup(n => n.GetItem(Moq.It.IsAny<string>())).Returns(new BugInfo.Common.Entity.BugInfoEntity1 { });

            BugInfoViewModel model = new BugInfoViewModel(repository.Object);
            model.New();
            model.Current.bugNum = "1";
            model.Current.version = "1.0";


            Assert.AreEqual<string>(model.CheckState(), "处理人不能为空");

            
        }
    }
}
