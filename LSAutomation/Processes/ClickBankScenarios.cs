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
using Common.Utilities.HttpRequest;

namespace LSAutomation.Processes
{
    [TestClass]
    public class ClickBankScenarios : TestBase
    {
        List<TimeBoundProxy> _activeproxies = new List<TimeBoundProxy>();
        ConcurrentBag<string> _proxiesToCheck = new ConcurrentBag<string>();        

        [TestMethod]
        public void GetPromotions()
        {            
            ExcuteScenario(()=>
            {
                var user = UserFactory.GetClickBankUsers();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.HomeDomain.OpenHomePage(ConfigurationInfo.FirstOrDefault(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)));
                Automation.HomeDomain.Login(user, ConfigurationInfo.FirstOrDefault(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)));
                Automation.MainMenuDomain.GoToMarketPlace();
                Automation.MainMenuDomain.GoToArtNiche();
                Automation.MarketPlaceDomain.SortResultBy(SortResultBy.Gravity);
                var promotionLinks = Automation.MarketPlaceDomain.GetPromotions();
                LSAutomationRepository.SavePromoteList(promotionLinks);
            });


        }
        

    }

}
