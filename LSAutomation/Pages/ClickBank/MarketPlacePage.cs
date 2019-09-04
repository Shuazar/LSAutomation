using Common;
using LSAutomation.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSAutomation.Models.ClickBank;
using TestAutomationEssentials.Selenium;
using Browser = Common.Browser;

namespace LSAutomation.Pages.ClickBank
{
    class MarketPlacePage : PageBase
    {
        public MarketPlacePage(Browser browser) : base(browser)
        {

        }
        public MarketPlacePage(Browser browser, BrowserWindow window) : base(browser,window)
        {

        }
        public void ShowResult(SortResultBy resultBy)
        {
            var sortField = Browser.WaitForElement(By.Id("sortField"), "sortField", 10);
            sortField.SelectByValue(resultBy.ToString().ToUpper());
        }

        public List<Promote> GetPromotions()
        {           
            var promotionList = new List<Promote>();
            var marketingRows = Browser.FindElements(By.CssSelector(".marketplaceStats"), "marketingRows");
            var promoteRows = Browser.WaitForElement(By.Id("results"),"Result container",20).FindElements(By.CssSelector(".result"), "Results");
            int i = 0;
            foreach (var row in promoteRows)
            {
               
                var promote = new Promote();
                row.MoveToElement();
                promote.Title = row.WaitForElement(By.CssSelector(".recordTitle"),"").Text;
                if (row.FindElements(By.CssSelector(".affiliateToolsUrlContent"), "").Any(el=>el.Displayed))
                    promote.AffiliatePage = row.WaitForElement(By.CssSelector(".affiliateToolsUrlContent"), "").GetAttribute("href");

                promote.Description =
                    row.WaitForElement(By.CssSelector(".descriptionContent"), "descriptionContent", 5).Text;
                promote.CommissionAverageDollarsPerSale =
                    row.WaitForElement(By.CssSelector(".commission.averageDollarsPerSaleContent.dollar"),
                        "Commission Average").Text;


                var category = marketingRows.ElementAt(i).WaitForElement(By.CssSelector(".stat.categoryContent"), "desc", 10).Text;
                var startIndex = category.IndexOf(":");
                category = category.Substring(startIndex, category.Length - startIndex).Replace(":", "");
                promote.Category = category;

                var element = row.FindElements(By.CssSelector(".stat.categoryContent"), "description");
                
                var hopLinkGeneratorWindow = Browser.OpenWindow(()=> row.WaitForElement(By.CssSelector(".promoteBtn"), "Button container", 10).WaitForElement(By.TagName("button"), "Button promote").Click(),"");
               // SetPromocode(hopLinkGeneratorWindow,"31234123");
                GenerateHopLink(hopLinkGeneratorWindow);
                promote.HopLink= GetHopLink(hopLinkGeneratorWindow);
                hopLinkGeneratorWindow.Close();
                promotionList.Add(promote);
                i++;
            }
            return promotionList;
        }        

        #region GeneratedHopLink

        private void SetPromocode(BrowserWindow window, string code)
        {
            window.WaitForElement(By.Id("promocode"), "promocode", 20).Text = code;
        }

        private void GenerateHopLink(BrowserWindow window)
        {
           window.WaitForElement(By.Id("submit"), "submit", 10).Click();
        }

        private string GetHopLink(BrowserWindow window)
        {
            return window.WaitForElement(By.CssSelector(".hoplinkUrlBox"), "hop link contaner", 10)
                .FindElements(By.TagName("td"), "Columns from table")
                .ElementAt(1).Text;
        }

        #endregion
    }
}
