using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugInfo.Common;
using BugInfoManagement.Dao;
using BugInfoManagement.Entity;
using Autofac;
using Moq;

namespace BugInfoManagement.Test
{
    /// <summary>
    /// Summary description for JIRAImporterTest
    /// </summary>
    [TestClass]
    public class JIRAImporterTest
    {
        public JIRAImporterTest()
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
        public void TestImport()
        {
            Moq.Mock<IBugInfoManagement> bugInfoManagement = new Moq.Mock<IBugInfoManagement>();
            bugInfoManagement.Setup(n => n.AddBugInfo(Moq.It.IsAny<BugInfoEntity>()));

            JIRAImporter importer = new JIRAImporter(bugInfoManagement.Object);
            importer.Import(@"z:\temp\SearchRequest-27118.xml",
                "3.1",
                "客户",
                "导入中心",
                1);
        }
    }
}
