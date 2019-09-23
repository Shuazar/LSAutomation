using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Common.BrowserFactory;
using Common.Models;
using Common.Proxy;
using Common.Report;
using DAL.Repositories;
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
        protected static List<ConfigurationInfo> ConfigurationInfo { get; private set; }
        private bool TestFail = false;
        protected LSAutomationRepository LSAutomationRepository;
        protected TestBase()
        {
            LSAutomationRepository = new LSAutomationRepository();
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {            
            ConfigInfoFaceBook = ConfigurationFactory.GetConfigurationFaceBook();
            ConfigInfoClickBank = ConfigurationFactory.GetConfigurationClickBank();
            ReportsFolder = ReportsPathFactory.CreateTestFolderForReport(testContext.TestName, ConfigInfoFaceBook.ReportFolder);
            ConfigurationInfo = new List<ConfigurationInfo>();
            ConfigurationInfo.Add(ConfigInfoFaceBook);
            ConfigurationInfo.Add(ConfigInfoClickBank);
           

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

        protected void ExecuteProxies(Action scenario)
        {
            try
            {
                Automation = new Automation(BrowserFactory.GetBrowser(""));
                scenario();
            }
            catch (Exception ex)
            {
                TestFail = true;
                ReportManager.Report.Fail(ex);
            }
        }
        protected void ExcuteScenario( Action scenario)
        {
            try
            {
                var dal =  new LSAutomationRepository();
                var proxyList = new List<Proxy>();
                proxyList = dal.GetProxies();
                
                Proxy proxyModel = new Proxy();

                foreach(var proxy in proxyList)
                {
                    if(proxy.ISO.Equals("RU"))                   
                    if (PingHost(proxy.IP,Convert.ToInt32(proxy.PORT)))
                    {
                        proxyModel = proxy;
                        break;
                    }
                }

          
                Automation = new Automation(ConfigurationInfo, BrowserFactory.GetBrowser(proxyModel.IP+": "+ proxyModel.PORT));
                scenario();
            }
            catch (Exception ex)
            {
                TestFail = true;
                ReportManager.Report.Fail(ex);
                
            }

        }
        //private List<TimeBoundProxy> CheckProxiesStatus(ConcurrentBag<string> _proxiesToCheck)
        //{
        //    Parallel.ForEach(_proxiesToCheck,
        //        proxytocheck =>
        //        {
        //            if (PingHost(proxytocheck))
        //            {
        //                _activeproxies.Add(new TimeBoundProxy(proxytocheck));
        //            }
        //        });
        //    return _activeproxies;
        //}

        private bool PingHost(string ip,int port)
        {                       
            bool isProxyActive;
            try
            {
                var client = new TcpClient(ip, port);
                isProxyActive = true;
            }
            catch (Exception)
            {
                isProxyActive = false;
            }
            return isProxyActive;
        }       
    }
}
