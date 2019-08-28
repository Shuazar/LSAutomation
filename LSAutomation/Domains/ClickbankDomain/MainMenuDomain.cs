using Common;
using LSAutomation.Models;
using LSAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Domains.ClickbankDomain
{
    public class MainMenuDomain : DomainBase
    {

        public MainMenuDomain(Automation automation) : base(automation)
        {

        }
        public void GoToMarketPlace()
        {
            var mainMenuPage = new MainMenuPage(Automation.Browser);
            mainMenuPage.GoToMarketPlace();
        }

        public void GoToArtNiche()
        {
            var artNiche = new MainMenuPage(Automation.Browser);
            artNiche.GoToArtNiche();
        }

        public void GoToSeenOnTvNiche()
        {
            var tvNiche = new MainMenuPage(Automation.Browser);
            tvNiche.GoToSeenOnTvNiche();
        }

        public void GoToBettingNiche()
        {
            var bettingNiche = new MainMenuPage(Automation.Browser);
            bettingNiche.GoToBettingNiche();
        }

        public void GoToInvestingNiche()
        {
            var investingNiche = new MainMenuPage(Automation.Browser);
            investingNiche.GoToInvestingNiche();
        }

        public void GoToInternetNiche()
        {
            var internetNiche = new MainMenuPage(Automation.Browser);
            internetNiche.GoToInternetNiche();
        }

        public void GoToCookingNiche()
        {
            var cookingNiche = new MainMenuPage(Automation.Browser);
            cookingNiche.GoToCookingNiche();
        }

        public void GoToEBusinessNiche()
        {
            var eBusinessNiche = new MainMenuPage(Automation.Browser);
            eBusinessNiche.GoToEBusinessNiche();
        }

        public void GoToEducationNiche()
        {
            var educationNiche = new MainMenuPage(Automation.Browser);
            educationNiche.GoToEducationNiche();
        }

        public void GoToJobsNiche()
        {
            var jobNiche = new MainMenuPage(Automation.Browser);
            jobNiche.GoToJobsNiche();
        }

        public void GoToFictionNiche()
        {
            var fictionNiche = new MainMenuPage(Automation.Browser);
            fictionNiche.GoToFictionNiche();
        }

        public void GoToGamesNiche()
        {
            var gamesNiche = new MainMenuPage(Automation.Browser);
            gamesNiche.GoToGamesNiche();
        }

        public void GoToGreenProductsNiche()
        {
            var greenProductsNiche = new MainMenuPage(Automation.Browser);
            greenProductsNiche.GoToGreenProductsNiche();
        }

        public void GoToHealthNiche()
        {
            var healthNiche = new MainMenuPage(Automation.Browser);
            healthNiche.GoToHealthNiche();
        }

        public void GoToHomeNiche()
        {
            var homeNiche = new MainMenuPage(Automation.Browser);
            homeNiche.GoToHomeNiche();
        }

        public void GoToLanguagesNiche()
        {
            var languagesNiche = new MainMenuPage(Automation.Browser);
            languagesNiche.GoToLanguagesNiche();
        }

        public void GoToMobileNiche()
        {
            var mobileNiche = new MainMenuPage(Automation.Browser);
            mobileNiche.GoToMobileNiche();
        }

        public void GoToFamiliesNiche()
        {
            var familiesNiche = new MainMenuPage(Automation.Browser);
            familiesNiche.GoToFamiliesNiche();
        }

        public void GoToPoliticsNiche()
        {
            var politicsNiche = new MainMenuPage(Automation.Browser);
            politicsNiche.GoToPoliticsNiche();
        }

        public void GoToReferenceNish()
        {
            var referenceNiche = new MainMenuPage(Automation.Browser);
            referenceNiche.GoToReferenceNiche();
        }

        public void GoToSelfHelpNiche()
        {
            var selfHelpNiche = new MainMenuPage(Automation.Browser);
            selfHelpNiche.GoToSelfHelpNiche();
        }

        public void GoToSoftwareNiche()
        {
            var softwareNiche = new MainMenuPage(Automation.Browser);
            softwareNiche.GoToSoftwareNiche();
        }

        public void GoToSpiritualityNiche()
        {
            var spiritualityNiche = new MainMenuPage(Automation.Browser);
            spiritualityNiche.GoToSpiritualityNiche();
        }

        public void GoToSportsNiche()
        {
            var sportsNiche = new MainMenuPage(Automation.Browser);
            sportsNiche.GoToSportsNiche();
        }

        public void GoToTravelNiche()
        {
            var travelNiche = new MainMenuPage(Automation.Browser);
            travelNiche.GoToTravelNiche();
        }
    }
}
