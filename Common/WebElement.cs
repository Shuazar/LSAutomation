using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Report;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestAutomationEssentials.Common;
using TestAutomationEssentials.Selenium;

namespace Common
{
    public class WebElement
    {

        public BrowserElement BrowserElement;
       
        public WebElement(BrowserElement browserElement)
        {
            BrowserElement = browserElement;
        }
       
        public string Description => BrowserElement.Description;
        public bool Enabled => BrowserElement.Enabled;

        public bool Selected => BrowserElement.Selected;

        public bool Displayed => BrowserElement.Displayed;

        ///<summary>
        /// Checks if the element's attribute 'style' contains 'block'
        /// </summary>
        public bool IsVisible
        {
            get
            {
                if (BrowserElement == null) return false;
                var style = BrowserElement.GetAttribute("style");

                return Wait.IfNot(() => style.Contains("block"), 2.Seconds());
            }
        }

        ///<summary>
        /// Checks if the element's attribute 'style' contains 'none'
        /// </summary>
        public bool IsNotVisible
        {
            get
            {
                if (BrowserElement == null) return true;
                var style = BrowserElement.GetAttribute("style");
                var isNotVisible = Wait.IfNot(() => style.Contains("none"), 2.Seconds());

                return isNotVisible || string.IsNullOrEmpty(style);
            }
        }

        public string Text
        {
            get { return BrowserElement.Text; }
            set
            {
                BrowserElement.Text = value;
                ReportManager.Report.Info($"Insert text '{value}' to '{BrowserElement.Description}'");
            }
        }

        public void MoveToElement()
        {
            ((IJavaScriptExecutor)BrowserElement.DOMRoot.Browser.GetWebDriver()).ExecuteScript("arguments[0].scrollIntoView(true);", BrowserElement);
        }

        public void MoveToCoordinateY(int delta = 200)
        {
            var elementPosition = BrowserElement.Location.Y - delta;
            string js = $"window.scroll(0, {elementPosition})";
            //Thread.Sleep(1000);
            ((IJavaScriptExecutor)BrowserElement.DOMRoot.Browser.GetWebDriver()).ExecuteScript(js);
        }

        public WebElement WaitForElement(By by, string description, int timeout = 60)
        {
            return new WebElement(BrowserElement.WaitForElement(by, description, timeout));
        }

        public IReadOnlyCollection<WebElement> FindElements(By @by, string description)
        {
            var elements = BrowserElement.FindElements(by, description);
            return elements.ConvertToWebElements();
        }

        public IReadOnlyCollection<WebElement> FindElements(By @by, int count, string description)
        {
            IReadOnlyCollection<WebElement> elements;
            var webDriver = BrowserElement.DOMRoot.Browser.GetWebDriver();
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
                wait.Until(d => BrowserElement.FindElements(by, description).Count() == count);
                elements = BrowserElement.FindElements(by, description).ConvertToWebElements();

            }
            catch (WebDriverTimeoutException)
            {
                ReportManager.Report.Error($"Failed to find elements under element '{description}' by criteria '{by}' ");
                throw;
            }
            return elements;
        }

        public void Clear()
        {
            ((IWebElement)BrowserElement).Clear();
        }

        public void Submit()
        {
            ReportManager.Report.Info($"Submit {BrowserElement.Description}");
            ((IWebElement)BrowserElement).Submit();
            ReportManager.Report.StepSucceeded();
        }
        public void Click()
        {
            ReportManager.Report.Info($"Click on '{BrowserElement.Description}'");

            try
            {
                BrowserElement.Click();
            }
            catch (Exception ex) when (ex is StaleElementReferenceException || ex is InvalidOperationException || ex is WebDriverException)
            {
                ReportManager.Report.Warning($"{ex.GetType()} was thrown while clicking.");
                if (!(ex.GetType() == typeof(WebDriverException)))
                {
                    Thread.Sleep(2000);
                    ReportManager.Report.Info($"Click on '{BrowserElement.Description}'");
                    BrowserElement.Click();
                }
            }

            ReportManager.Report.StepSucceeded();
        }

        public void MoveAndClick()
        {
            ReportManager.Report.Info($"Move and Click on '{BrowserElement.Description}'");
            var actions = new OpenQA.Selenium.Interactions.Actions(BrowserElement.DOMRoot.Browser.GetWebDriver());
            actions.MoveToElement(BrowserElement).Click(BrowserElement).Build().Perform();
            ReportManager.Report.StepSucceeded();
        }

        public void MoveToElementWithMouse()
        {
            var action = new OpenQA.Selenium.Interactions.Actions(BrowserElement.DOMRoot.Browser.GetWebDriver());
            action.MoveToElement(BrowserElement);
            action.Build().Perform();
        }
        public void DoubleClick()
        {
            ReportManager.Report.Info($"Double Click on '{BrowserElement.Description}'");
            var action = new OpenQA.Selenium.Interactions.Actions(BrowserElement.DOMRoot.Browser.GetWebDriver());
            action.DoubleClick(BrowserElement).Build().Perform();
            ReportManager.Report.StepSucceeded();
        }

        public string GetAttribute(string attributeName)
        {
            try
            {
                return BrowserElement.GetAttribute(attributeName);
            }
            catch (StaleElementReferenceException)
            {
                return BrowserElement.GetAttribute(attributeName);
            }
        }

        public string GetCssValue(string propertyName)
        {
            return ((IWebElement)this).GetCssValue(propertyName);
        }

        public void SelectByValue(string value)
        {
            ReportManager.Report.Info($"Select by value'{value}' at '{BrowserElement.Description}'");
            var selectElement = new SelectElement(BrowserElement);
            selectElement.SelectByValue(value);
            ReportManager.Report.StepSucceeded();
        }
        public void SelectByIndex(int index)
        {
            ReportManager.Report.Info($"Select by index'{index}' at '{BrowserElement.Description}'");
            var selectElement = new SelectElement(BrowserElement);
            selectElement.SelectByIndex(index);
            ReportManager.Report.StepSucceeded();
        }
        public void SelectByText(string text)
        {
            ReportManager.Report.Info($"Select by text:'{text}' at '{BrowserElement.Description}'");
            var selectElement = new SelectElement(BrowserElement);
            selectElement.SelectByText(text);
            ReportManager.Report.StepSucceeded();
        }

        public void WaitUntilVisible(int seconds = 60)
        {
            var wait = new WebDriverWait(BrowserElement.DOMRoot.Browser.GetWebDriver(), TimeSpan.FromSeconds(seconds))
            {
                Message = $"Element '{BrowserElement.Description}' isn't displayed or enabled"
            };
            wait.Until(d => BrowserElement.Displayed && BrowserElement.Enabled);
        }

        public void WaitUntilClickable(int seconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(BrowserElement.DOMRoot.Browser.GetWebDriver(), TimeSpan.FromSeconds(seconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(BrowserElement));
            }
            catch (WebDriverTimeoutException e)
            {
                //ReportManager.Report.Warning($"{e.InnerException} <br> {e.Message}");
                //ReportManager.Report.Warning($"Element '{BrowserElement.Description}' is not clickable");
            }
        }
        public void SendKeyTab()
        {
            ((IWebElement)BrowserElement).SendKeys(Keys.Tab);
            ((IWebElement)BrowserElement).SendKeys(Keys.Enter);
        }
        public void SendKeyTabWithoutEnter()
        {
            ((IWebElement)BrowserElement).SendKeys(Keys.Tab);

        }
        public string GetTagName(BrowserElement element)
        {
            return ((IWebElement)element).TagName;
        }

        public void SendKeys(string s)
        {
            ((IWebElement)BrowserElement).SendKeys(s);
        }

        public void SetAttribute(IWebDriver driver, string attribute, string value)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", BrowserElement as IWebElement, attribute, value);
        }

        public void PageDown()
        {
            BrowserElement.ToWebElement().SendKeys(Keys.PageDown);
        }

        public void PageUp()
        {
            BrowserElement.ToWebElement().SendKeys(Keys.PageUp);
        }

        public void CheckBoxActionClick(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(BrowserElement, 10, 30).Click().Build().Perform();
        }
    }
}

