using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TeamView.Common;
using TeamView.Common.Logs;
using TeamView.Report;

namespace TeamView.Test
{
    /// <summary>
    /// Summary description for LogReader_Test
    /// </summary>
    [TestClass]
    public class LogReader_Test
    {
        public LogReader_Test()
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
        public void ReaderTest()
        {
            List<string> list = new List<string> { 
"BugNum:A-56;Time:Apr 24 2011  9:57AM;Version:3.0;size:5;S:待处理;D:曹宗颖",
"BugNum:A-56;Time:Apr 24 2011  9:58AM;Deal:曹宗颖->陈鹏;Size:5->6",
"BugNum:A-56;Time:Apr 24 2011  9:58AM;Status:待处理->正在处理",
"BugNum:A-56;Time:Apr 24 2011  9:59AM;Status:正在处理->完成",
"BugNum:A-56;Time:Apr 24 2011  9:59AM;Status:完成->待处理",
"BugNum:A-56;Time:Apr 24 2011  9:59AM;Deal:陈鹏->叶伟",
"BugNum:A-56;Time:Apr 24 2011 10:13AM;Status:待处理->正在处理",
"BugNum:A-56;Time:Apr 24 2011 10:13AM;Status:正在处理->完成",
"BugNum:A-56;Time:Apr 24 2011 10:13AM;Status:完成->待处理",
"BugNum:A-56;Time:Apr 24 2011 10:13AM;Deal:叶伟->陈鹏",
"BugNum:A-56;Time:Apr 24 2011 10:14AM;Size:6->3",
"BugNum:A-56;Time:Apr 24 2011 10:15AM;Deal:陈鹏->方绍军",

};

            TaskRecordParser manager = new TaskRecordParser(null);
            new List<TaskRecord>(manager.Read(string.Empty))
            .ForEach(n => Debug.WriteLine(n.ToRecordString()));
        }
    }
}
