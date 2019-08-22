using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Common.BrowserFactory
{
    public class ChromeBrowser : Browser
    {

        public override string Name => "Chrome";

        public ChromeBrowser() : base("Driver", GetDriver())
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
