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

        public ChromeBrowser(string proxy) : base("Driver", GetDriver(proxy))
        {
        }
      
        public static IWebDriver GetDriver(string proxyUrl)
        {
            
            ChromeOptions options = new ChromeOptions();
            if(!string.IsNullOrEmpty(proxyUrl))
            {
                options.Proxy = GetProxy(proxyUrl);
            }           
            options.AddArguments("--start-maximized");
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-notifications");
            var driverService = ChromeDriverService.CreateDefaultService();
            return new ChromeDriver(driverService, options, TimeSpan.FromSeconds(120));
        }
        private static OpenQA.Selenium.Proxy GetProxy(string proxyUrl)
        { 
            var proxy = new OpenQA.Selenium.Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.IsAutoDetect = false;
            proxy.SslProxy = proxyUrl;
            proxy.HttpProxy = proxyUrl;          
            return proxy;
        }
    }
}
