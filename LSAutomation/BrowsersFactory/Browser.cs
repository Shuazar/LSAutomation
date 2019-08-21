using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSAutomation.Report;
using OpenQA.Selenium;

namespace LSAutomation.BrowsersFactory
{
    public abstract class Browser
    {
        public abstract string Name { get; }
        private IWebDriver WebDriver { get; set; }

        public Browser(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            DriverInit();
        }

        public void DriverInit()
        {
            WebDriver.Manage().Window.Maximize();

        }
        public void NavigateToUrl(string url)
        {
            ReportManager.Report.Info($"Navigate to: {url}");
            WebDriver.Navigate().GoToUrl(url);
        }

        public IWebDriver GetWebDriver()
        {
            return WebDriver;
        }
        //public void WaitTillPageLoaded(IWebDriver driver)
        //{
        //    var js = (IJavaScriptExecutor)driver;
        //    var timeout = 2.Minutes();
        //    var result = Wait.IfNot(() => IsDocumentStateComplete(js).Item1, timeout);
        //    ReportManager.Report.Info($"Page loading status: document.readyState = {result}");
        //}
    }
}
