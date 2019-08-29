using Common;
using LSAutomation.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Pages.ClickBank
{
    class MarketPlacePage : PageBase
    {
        public MarketPlacePage(Browser browser) : base(browser)
        {

        }

        public void ShowResultsByPopularity()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("POPULARITY");
        }

        public void ShowResultsByAvgDollarSale()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("AVERAGE_EARNINGS_PER_SALE");
        }

        public void ShowResultsByInitialDollarSale()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("INITIAL_EARNINGS_PER_SALE");
        }

        public void ShowResultsByAvgPercentSale()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("PCT_EARNINGS_PER_SALE");
        }

        public void ShowResultsByAvgRebillTotal()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("TOTAL_REBILL");
        }

        public void ShowResultsByAvgPercentRebill()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("PCT_EARNINGS_PER_REBILL");
        }

        public void ShowResultsByGravity()
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue("GRAVITY");
        }


    }
}
