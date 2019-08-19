using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomationEssentials.Common.ExecutionContext;

namespace LSAutomation.Browsers
{
    public class ChromeBrowser : BrowserBase
    {
        public ChromeBrowser() : base("Driver", GetDriver())
        {
        }

        public ChromeBrowser(string description, IWebDriver webDriver, TestExecutionScopesManager testExecutionScopesManager) : base(description, webDriver, testExecutionScopesManager)
        {
        }
        public static IWebDriver GetDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-notifications");
            var driverService = ChromeDriverService.CreateDefaultService();
            return new ChromeDriver(driverService, options, TimeSpan.FromSeconds(120));
        }
    }
}
