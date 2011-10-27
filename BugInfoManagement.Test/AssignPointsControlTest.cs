using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxLib.Controls.Test;
using Autofac;

namespace BugInfoManagement.Test
{
    /// <summary>
    /// Summary description for AssignPointsControlTest
    /// </summary>
    [TestClass]
    public class AssignPointsControlTest
    {
        public AssignPointsControlTest()
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

        class AssignPointsControlTestModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<DealMenTestImpl>().As<IDealMen>();
                builder.RegisterType<AssignPointsControl>();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestForm form = new TestForm();

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<AssignPointsControlTestModule>();

            var container = builder.Build();

            var ctrl = container.Resolve<AssignPointsControl>();

            form.AddControl(ctrl);

            form.AddClickEvent("assign", (s, e) => {
                Assert.IsTrue(ctrl.IsChanged);
            });

            form.AddClickEvent("can assign", (s, e) => {
                Assert.IsTrue(ctrl.CanAssign);
                var est = ctrl.GetProgrammerPoint();
                Assert.AreEqual(est.Assignee, "programmer_name");
                Assert.AreEqual(est.EstimatedBy, "programmer_name");
                Assert.AreEqual(est.EstimatedLevel, "BasicPlus");
            });
            form.ShowDialog();
        }
    }
}
