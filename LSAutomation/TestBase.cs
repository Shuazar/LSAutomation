using System;
using System.Runtime.InteropServices;
using LSAutomation.Browsers;
using LSAutomation.Factories;
using LSAutomation.Models;
using LSAutomation.Report;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace LSAutomation
{

    [TestClass]
    public abstract class TestBase
    {
        private static string ReportsFolder { get; set; }
        protected static ConfigurationInfo ConfigInfo { get; set; }
        public TestContext TestContext { get; set; }
        protected static Automation Automation { get; private set; }
        private bool TestFail = false;
        protected TestBase()
        {

        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            ConfigInfo = ConfigurationFactory.GetConfiguration();
            ReportsFolder = ReportsPathFactory.CreateTestFolderForReport(testContext.TestName, ConfigInfo.ReportFolder);
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
                Automation = new Automation(ConfigInfo, BrowserFactory.GetBrowser());
                scenario();
            }
            catch (Exception ex)
            {
                TestFail = true;

            }

        }
    }
}
