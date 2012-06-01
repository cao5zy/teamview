using TeamView.Report2.GeneralView;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TeamView.Test
{
    
    
    /// <summary>
    ///This is a test class for ReportEntityTest and is intended
    ///to contain all ReportEntityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReportEntityTest
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
        ///A test for Cal
        ///</summary>
        [TestMethod()]
        public void Cal_Normal_Test()
        {
            GeneralViewReportEntity target = new GeneralViewReportEntity();
            target._sizeInMins = 120;
            target._burnedMins = 90;
            target.Points = 1;
            target.Cal();

            Assert.AreEqual(1.5, target.ResultPoint);
        }

        [TestMethod()]
        public void Cal_Overtime1_Test()
        {
            GeneralViewReportEntity target = new GeneralViewReportEntity();
            target._sizeInMins = 120;
            target._burnedMins = 150;
            target.Points = 1;
            target.Cal();

            Assert.AreEqual(2.3, target.ResultPoint);
        }

        [TestMethod()]
        public void Cal_Overtime2_Test()
        {
            GeneralViewReportEntity target = new GeneralViewReportEntity();
            target._sizeInMins = 120;
            target._burnedMins = 240;
            target.Points = 1;
            target.Cal();

            Assert.AreEqual(3.2, target.ResultPoint);
        }

        [TestMethod()]
        public void Cal_Overtime3_Test()
        {
            GeneralViewReportEntity target = new GeneralViewReportEntity();
            target._sizeInMins = 120;
            target._burnedMins = 360;
            target.Points = 1;
            target.Cal();

            Assert.AreEqual(3.6, target.ResultPoint);
        }

        [TestMethod()]
        public void Cal_Overtime4_Test()
        {
            GeneralViewReportEntity target = new GeneralViewReportEntity();
            target._sizeInMins = 120;
            target._burnedMins = 480;
            target.Points = 1;
            target.Cal();

            Assert.AreEqual(3.7, target.ResultPoint);
        }

        [TestMethod()]
        public void Cal_Overtime5_Test()
        {
            GeneralViewReportEntity target = new GeneralViewReportEntity();
            target._sizeInMins = 120;
            target._burnedMins = 540;
            target.Points = 1;
            target.Cal();

            Assert.AreEqual(3.75, target.ResultPoint);
        }
    }
}
