using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamView.Common.Dao;
using TeamView.Common.Models;

namespace TeamView.Test
{
    /// <summary>
    /// Summary description for KeyModel_Test
    /// </summary>
    [TestClass]
    public class KeyModel_Test
    {
        public KeyModel_Test()
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
        public void GenerateKey_New_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            repository.Setup(n => n.GetCurrentKeyValue("A"))
                .Returns(new Nullable<long>());

            KeyModel model = new KeyModel(repository.Object);

            var key = model.GenerateKey("a-*");

            Assert.AreEqual("A-1", key);
        }

        [TestMethod]
        public void GenerateKey_Existing_Key_Test()
        {
            Moq.Mock<IBugInfoRepository> repository = new Moq.Mock<IBugInfoRepository>();

            repository.Setup(n => n.GetCurrentKeyValue("A"))
                .Returns(1);

            KeyModel model = new KeyModel(repository.Object);

            var key = model.GenerateKey("a-*");

            Assert.AreEqual("A-2", key);
        }
    }
}
