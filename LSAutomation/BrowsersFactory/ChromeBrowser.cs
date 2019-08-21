using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.BrowsersFactory
{
    public class ChromeBrowser : Browser
    {

        public override string Name => "Chrome";

        public ChromeBrowser() : base(GetDriver())
        {
        }
        private static IWebDriver GetDriver()
        {
            return new ChromeDriver();
        }
    }
}
