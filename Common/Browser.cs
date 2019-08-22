using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationEssentials.Common.ExecutionContext;

namespace Common
{
    public abstract class Browser : TestAutomationEssentials.Selenium.Browser
    {
        public abstract string Name { get; }
        private IWebDriver _driver;
        private int _timeOut = 5;
        public Browser(string description, IWebDriver webDriver) : base(description, webDriver)
        {
            _driver = webDriver;
            DriverInitialization();
        }

        public Browser(string description, IWebDriver webDriver, TestExecutionScopesManager testExecutionScopesManager) : base(description, webDriver, testExecutionScopesManager)
        {
        }
        public string GetCurrentUrl()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            return wait.Until(d =>
            {
                try
                {
                    return _driver.Url;
                }
                catch (NoSuchWindowException)
                {
                    return null;
                }
            });
        }
        private void DriverInitialization()
        {
            //_driver.Manage().Timeouts().SetPageLoadTimeout(1.Minutes());
            //_driver.Manage().Timeouts().SetScriptTimeout(1.Minutes());
            SetImplicitTimeOut(_timeOut);

            if (!Name.Equals("AndroidChrome") && !Name.Equals("iPodSafari") && !Name.Equals("IPhone6Safari"))
                _driver.Manage().Window.Maximize();
        }
        private void SetImplicitTimeOut(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        public void DisableImplicitTimeout(Action action, int newTimeoutSeconds = 2)
        {
            SetImplicitTimeOut(newTimeoutSeconds);
            action();
            SetImplicitTimeOut(_timeOut);
        }
        public new WebElement WaitForElement(By @by, string description, int timeout = 60)
        {
            var browserElement = base.WaitForElement(by, description, timeout);
            return new WebElement(browserElement);
        }
        public WebDriverWait CreateWait(TimeSpan timeSpan)
        {
            return new WebDriverWait(_driver, timeSpan);
        }
    }
}
