using Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Pages
{
    public class MainMenuPage : PageBase
    {        
        public MainMenuPage(Browser browser) : base(browser)
        {

        }
            
        public void GoToMarketPlace()
        {
            Browser.WaitForElement(By.LinkText("Marketplace"), "marketplace", 10).Click();
        }

        public void GoToArtNiche()
        {
            Browser.WaitForElement(By.Id("cat_1253"), "artNiche", 10).Click();
        }

        public void GoToSeenOnTvNiche()
        {
            Browser.WaitForElement(By.Id("cat_1539"), "tvNiche", 10).Click();
        }

        public void GoToBettingNiche()
        {
            Browser.WaitForElement(By.Id("cat_1510"), "bettingNiche", 10).Click();
        }

        public void GoToInvestingNiche()
        {
            Browser.WaitForElement(By.Id("cat_1266"), "investingNiche", 10).Click();
        }

        public void GoToInternetNiche()
        {
            Browser.WaitForElement(By.Id("cat_1283"), "internetNiche", 10).Click();
        }

        public void GoToCookingNiche()
        {
            Browser.WaitForElement(By.Id("cat_1297"), "cookingNiche", 10).Click();
        }

        public void GoToEBusinessNiche()
        {
            Browser.WaitForElement(By.Id("cat_1308"), "eBusinessNiche", 10).Click();
        }

        public void GoToEducationNiche()
        {
            Browser.WaitForElement(By.Id("cat_1362"), "educationNiche", 10).Click();
        }

        public void GoToJobsNiche()
        {
            Browser.WaitForElement(By.Id("cat_1332"), "jobsNiche", 10).Click();
        }

        public void GoToFictionNiche()
        {
            Browser.WaitForElement(By.Id("cat_1338"), "fictionNiche", 10).Click();
        }

        public void GoToGamesNiche()
        {
            Browser.WaitForElement(By.Id("cat_1340"), "gamesNiche", 10).Click();
        }

        public void GoToGreenProductsNiche()
        {
            Browser.WaitForElement(By.Id("cat_1344"), "greenProductsNiche", 10).Click();
        }

        public void GoToHealthNiche()
        {
            Browser.WaitForElement(By.Id("cat_1347"), "healthNiche", 10).Click();
        }

        public void GoToHomeNiche()
        {
            Browser.WaitForElement(By.Id("cat_1366"), "homeNiche", 10).Click();
        }

        public void GoToLanguagesNiche()
        {
            Browser.WaitForElement(By.Id("cat_1377"), "languagesNiche", 10).Click();
        }

        public void GoToMobileNiche()
        {
            Browser.WaitForElement(By.Id("cat_1392"), "mobileNiche", 10).Click();
        }

        public void GoToFamiliesNiche()
        {
            Browser.WaitForElement(By.Id("cat_1400"), "familiesNiche", 10).Click();
        }

        public void GoToPoliticsNiche()
        {
            Browser.WaitForElement(By.Id("cat_1408"), "politicsNiche", 10).Click();
        }

        public void GoToReferenceNiche()
        {
            Browser.WaitForElement(By.Id("cat_1410"), "referenceNiche", 10).Click();
        }

        public void GoToSelfHelpNiche()
        {
            Browser.WaitForElement(By.Id("cat_1419"), "selfHelpNiche", 10).Click();
        }

        public void GoToSoftwareNiche()
        {
            Browser.WaitForElement(By.Id("cat_1432"), "softwareNiche", 10).Click();
        }

        public void GoToSpiritualityNiche()
        {
            Browser.WaitForElement(By.Id("cat_1461"), "spiritualityNiche", 10).Click();
        }

        public void GoToSportsNiche()
        {
            Browser.WaitForElement(By.Id("cat_1472"), "sportsNiche", 10).Click();
        }

        public void GoToTravelNiche()
        {
            Browser.WaitForElement(By.Id(""), "travelNiche", 10).Click();
        }

    }
}