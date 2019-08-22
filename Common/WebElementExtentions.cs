using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using TestAutomationEssentials.Common;
using TestAutomationEssentials.Selenium;

namespace Common
{
    public static class WebElementExtentions
    {
        public static IReadOnlyCollection<WebElement> ConvertToWebElements(
            this IEnumerable<BrowserElement> browserElements)
        {
            if (browserElements.IsEmpty())
                return new List<WebElement>();
            return browserElements.Select(el => new WebElement(el)).ToList();
        }
        public static WebElement MoveToDisplayedElement(this IEnumerable<WebElement> webElements)
        {
            foreach (var webElement in webElements)
            {
                webElement.MoveToElement();

                if (webElement.Displayed && webElement.Enabled)
                    return webElement;
            }
            throw new Exception("No displayed element was found");
        }

        public static WebElement ToWebElement(this BrowserElement browserElement)
        {
            return browserElement == null ? null : new WebElement(browserElement);
        }

        public static WebElement GetFirstDisplayedElement(this IEnumerable<BrowserElement> browserElements)
        {
            return browserElements.ConvertToWebElements().GetFirstDisplayedElement();
        }

        public static WebElement GetFirstDisplayedElement(this IEnumerable<WebElement> webElements)
        {
            return webElements.First(e => e.Displayed);
        }
        public static WebElement GetElementByValue(this IEnumerable<WebElement> webElements, string value, Browser browser)
        {
            var wait = browser.CreateWait(TimeSpan.FromSeconds(60));
            wait.Message = "No element  with value was found";

            return wait.Until(d => webElements.FirstOrDefault(e => e.Text.Equals(value)));
        }
        public static WebElement GetElementFromListByTabidAttribute(this IEnumerable<WebElement> webElements, Browser browser)
        {
            var wait = browser.CreateWait(TimeSpan.FromSeconds(60));
            wait.Message = "No displayed element was found";

            return wait.Until(d => webElements.FirstOrDefault(e => e.GetAttribute("tabid").Equals("NotesTab")));
        }
        public static WebElement GetElementFromListByAttribute(this IEnumerable<WebElement> webElements, Browser browser, string attr, string value)
        {
            var wait = browser.CreateWait(TimeSpan.FromSeconds(60));
            wait.Message = "No displayed element was found";

            return wait.Until(d => webElements.FirstOrDefault(e => e.GetAttribute(attr).Equals(value)));
        }
        public static void TryClick(this WebElement element, TimeSpan timeout)
        {
            Wait.Until(() => ClickSucceeded(element), timeout);
        }
        private static bool ClickSucceeded(WebElement webElement)
        {
            try
            {
                webElement.Click();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Element is not clickable"))
                    return false;

                throw;
            }
        }
        public static void MoveToElement(this WebElement parentElement, WebElement targetElement)
        {
            var driver = parentElement.BrowserElement.DOMRoot.Browser.GetWebDriver();

            Actions actions = new Actions(driver);

            actions.MoveToElement(targetElement.BrowserElement).Build().Perform();
        }
    }
}
