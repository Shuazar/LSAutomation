using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestAutomationEssentials.Common.ExecutionContext;

namespace Common
{
    public class BrowserBase : TestAutomationEssentials.Selenium.Browser
    {
        public BrowserBase(string description, IWebDriver webDriver) : base(description, webDriver)
        {
        }

        public BrowserBase(string description, IWebDriver webDriver, TestExecutionScopesManager testExecutionScopesManager) : base(description, webDriver, testExecutionScopesManager)
        {
        }
    }
}
