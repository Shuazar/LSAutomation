using System;
using Common.BrowserFactory;
using Common.Report;
using LSAutomation.Factories;
using LSAutomation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LSAutomation
{

    [TestClass]
    public abstract class TestBase
    {
        private static string ReportsFolder { get; set; }
        protected static ConfigurationInfo ConfigInfoFaceBook { get; set; }
        protected static ConfigurationInfo ConfigInfoClickBank { get; set; }
        public TestContext TestContext { get; set; }
        protected static Automation Automation { get; private set; }
        private bool TestFail = false;
        protected TestBase()
        {

        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            ConfigInfoFaceBook = ConfigurationFactory.GetConfigurationFaceBook();
            ConfigInfoClickBank = ConfigurationFactory.GetConfigurationClickBank();
            ReportsFolder = ReportsPathFactory.CreateTestFolderForReport(testContext.TestName, ConfigInfoFaceBook.ReportFolder);
        }

        [TestInitialize]
        public void TestInit()
        {
            ReportManager.Report.StartTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ReportManager.Report.Flush();
            ReportManager.Report.EndTest();
        }

        protected void ExcuteScenario(Action scenario)
        {
            try
            {
                Automation = new Automation(ConfigInfoFaceBook, BrowserFactory.GetBrowser());
                scenario();
            }
            catch (Exception ex)
            {
                TestFail = true;

            }

        }
    }
}
