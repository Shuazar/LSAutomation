using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using OpenQA.Selenium;

namespace LSAutomation.Pages.ClickBank
{
    public class HopeLinkGenerator : PageBase
    {
        public HopeLinkGenerator(Browser browser) : base(browser)
        {
        }

        public string Promocode
        {
            set { Browser.WaitForElement(By.Id("promocode"), "promocode", 20).Text = value; }
        }

        public WebElement GenerateHopLink
        {
            get { return Browser.WaitForElement(By.Id("submit"), "submit", 10); }
        }

        public string GetHopLink()
        {
            return "";
           
        }
    }
}
