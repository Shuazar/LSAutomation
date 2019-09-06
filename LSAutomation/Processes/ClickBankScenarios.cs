﻿using LSAutomation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Report;
using System.Linq;
using LSAutomation.Enums;

namespace LSAutomation.Processes
{
    [TestClass]
    public class ClickBankScenarios : TestBase
    {
        [TestMethod]
        public void GetPromotions()
        {
            ExcuteScenario(() =>
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

               /* Automation.MainMenuDomain.GoToSeenOnTvNiche();
                Automation.MainMenuDomain.GoToBettingNiche();
                Automation.MainMenuDomain.GoToInvestingNiche();
                Automation.MainMenuDomain.GoToInternetNiche();
                Automation.MainMenuDomain.GoToCookingNiche();
                Automation.MainMenuDomain.GoToEBusinessNiche();
                Automation.MainMenuDomain.GoToEducationNiche();
                Automation.MainMenuDomain.GoToJobsNiche();
                Automation.MainMenuDomain.GoToFictionNiche();
                Automation.MainMenuDomain.GoToGamesNiche();
                Automation.MainMenuDomain.GoToGreenProductsNiche();
                Automation.MainMenuDomain.GoToHealthNiche();
                Automation.MainMenuDomain.GoToHomeNiche();
                Automation.MainMenuDomain.GoToLanguagesNiche();
                Automation.MainMenuDomain.GoToMobileNiche();
                Automation.MainMenuDomain.GoToFamiliesNiche();
                Automation.MainMenuDomain.GoToPoliticsNiche();
                Automation.MainMenuDomain.GoToReferenceNish();
                Automation.MainMenuDomain.GoToSelfHelpNiche();
                Automation.MainMenuDomain.GoToSoftwareNiche();
                Automation.MainMenuDomain.GoToSpiritualityNiche();
                Automation.MainMenuDomain.GoToSportsNiche();
                Automation.MainMenuDomain.GoToTravelNiche();*/
                
                
            });

        }

    }
}
