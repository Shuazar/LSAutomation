using LSAutomation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Report;
using System.Linq;
using LSAutomation.Enums;
using System.Collections.Concurrent;
using OpenQA.Selenium;
using System.Windows;
using System;
using System.Threading.Tasks;
using Common.Proxy;
using System.Net.Sockets;
using System.Collections.Generic;

namespace LSAutomation.Processes
{
    [TestClass]
    public class ClickBankScenarios : TestBase
    {
        List<TimeBoundProxy> _activeproxies = new List<TimeBoundProxy>();
        ConcurrentBag<string> _proxiesToCheck = new ConcurrentBag<string>();

        string ProxyIp= "85.238.167.170:51904";

        [TestMethod]
        public void GetPromotions()
        {          
            //ExecuteProxies(() =>
            //{
            //    Automation.Browser.NavigateToUrl("https://www.proxy-list.download/HTTPS");
            //    Automation.Browser.WaitForElement(By.Id("btn3"), "", 20).Click();
            //    var result = Clipboard.GetText();
            //    _proxiesToCheck = new ConcurrentBag<string>(Clipboard.GetText().Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToList());
            //    _activeproxies = CheckProxiesStatus(_proxiesToCheck);
            //    ProxyIp = GetProxyIp();
            //});

            ExcuteScenario( ProxyIp ,()=>
            {
                var user = UserFactory.GetClickBankUsers();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.HomeDomain.OpenHomePage(ConfigurationInfo.FirstOrDefault(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)));
                Automation.HomeDomain.Login(user, ConfigurationInfo.FirstOrDefault(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)));
                Automation.MainMenuDomain.GoToMarketPlace();
                Automation.MainMenuDomain.GoToArtNiche();
                Automation.MarketPlaceDomain.SortResultBy(SortResultBy.Gravity);
                var promotionLinks = Automation.MarketPlaceDomain.GetPromotions();
                ClickBankRepository.SavePromoteList(promotionLinks);
            });
        }
        private List<TimeBoundProxy> CheckProxiesStatus(ConcurrentBag<string> _proxiesToCheck)
        {            
            Parallel.ForEach (_proxiesToCheck,
                proxytocheck =>
                {
                    if (PingHost(proxytocheck))
                    {
                        _activeproxies.Add(new TimeBoundProxy(proxytocheck));
                    }
                });
            return _activeproxies;
        }

        private bool PingHost(string nameOrAddress)
        {
            var ip = nameOrAddress.Split(':').First();
            var port = int.Parse(nameOrAddress.Split(':').Last());
            Console.WriteLine($"Ping address {nameOrAddress}");
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

        private string GetProxyIp()
        {
            var newProxy = _activeproxies.ToList().OrderByDescending(x => x.LastTimeOfUse).First();
            newProxy.LastTimeOfUse = DateTime.Now;
            return newProxy.IpProxy;
        }

    }

}
