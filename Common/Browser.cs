using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Common.Report;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationEssentials.Common;
using TestAutomationEssentials.Common.ExecutionContext;
using TestAutomationEssentials.Selenium;

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
            SetImplicitTimeOut(_timeOut);       
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
        public new void NavigateToUrl(string url)
        {
            try
            {
                TryToNavigateToURL(url);
                if (_driver.Url.ToLower().Equals("data:,"))
                    TryToNavigateToURL(url);
                WaitTillPageLoaded(_driver);
                
            }
            catch (Exception ex) when (ex is WebDriverException || ex is WebException)
            {
                ReportManager.Report.Warning($"{ex.InnerException} <br> {ex.Message}");              
                TryToNavigateToURL(url);
            }
        }     
        private List<string> GetOpenWindows()
        {
            try
            {
                return _driver.WindowHandles.ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }  
        private void TryToNavigateToURL(string url)
        {
            ReportManager.Report.Info($"Navigate to '{url}'");
            base.NavigateToUrl(url);
        }
        public void WaitTillPageLoaded(IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            var timeout = 2.Minutes();
            var result = Wait.IfNot(() => IsDocumentStateComplete(js).Item1, timeout);
            ReportManager.Report.Info($"Page loading status: document.readyState = {result}");
        }
        private static Tuple<bool, string> IsDocumentStateComplete(IJavaScriptExecutor js)
        {
            try
            {
                var state = js.ExecuteScript("return document.readyState").ToString();
                if (!state.Equals("complete")) return new Tuple<bool, string>(false, state);
                return new Tuple<bool, string>(true, state);
            }
            catch (WebDriverException)
            {
                ReportManager.Report.Warning("WebDriverException on 'return document.readyState' function!");
                return new Tuple<bool, string>(false, "");
            }
        }
        public void WaitTillPageVisible(IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            var timeout = 1.Minutes();
            var result = Wait.Until(() => IsDocumentStateVisible(js), r => r.Item1, timeout, $"The page failed to load in {timeout} minutes.");
            ReportManager.Report.Info($"The elements are visible: document.visibilityState = {result.Item2}");
        }
        public void RemoveElementFromPage(string element)
        {
            var js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript(element);
        }
        private static Tuple<bool, string> IsDocumentStateVisible(IJavaScriptExecutor js)
        {
            try
            {
                var state = js.ExecuteScript("return document.visibilityState").ToString();
                return new Tuple<bool, string>(state.Equals("visible"), state);
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(true, $"{e.GetType().Name} was thrown!");
            }
        }
        public void DeleteAllCookies()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }
        public void MaximizeWindow()
        {
            _driver.Manage().Window.Maximize();
        }
        public void WaitUntillElementUnvisible(By @by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception ex) { }
        }     
        public bool IsElementDisplayed(By @by, int timeout = 60)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        public ReadOnlyCollection<IWebElement> WaitForIframesList(By @by, string description)
        {
            return _driver.FindElements(by);
        }
        public IReadOnlyCollection<WebElement> WaitForElements(By @by, string description)
        {
            return FindElements(by, description).ConvertToWebElements();
        }
        public bool FindElementWithAttribute(By @by, string attribute)
        {
            var flag = false;
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeOut));
                var elements = wait.Until(d => d.FindElements(by));

                foreach (var item in elements)
                {
                    var value = item.GetAttribute(attribute);
                    if (value != null)
                        flag = true;
                }

            }
            catch (WebDriverTimeoutException)
            {
                ReportManager.Report.Error($"Failed to find element '{attribute}' by criteria '{by}'");
                throw;
            }
            return flag;

        }
        public WebDriverWait CreateWait(int seconds)
        {
            return CreateWait(TimeSpan.FromSeconds(seconds));
        }       
        public void ClearLocalStorage()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.localStorage.clear();");
        }
        public string GetLocalStorageItem(string key)
        {

            string value = (string)((IJavaScriptExecutor)_driver).ExecuteScript("return localStorage.getItem('" + key + "')");
            new Retry(() =>
            {
                RefreshPage();
                value = (string)((IJavaScriptExecutor)_driver).ExecuteScript("return localStorage.getItem('" + key + "')");
            }, 1.Minutes(), $"Failed get {key} cookie from local storage").Until(() => !string.IsNullOrEmpty(value));

            return value;
        }

        public void PageUp()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
        }

        public void PageDown(int num)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"window.scrollTo(document.body.scrollHeight,{num})");
        }

        public ReadOnlyCollection<object> GetCookiesFromJavaScript()
        {
            var accounts = ((IJavaScriptExecutor)_driver).ExecuteScript("return document.cookie;") as ReadOnlyCollection<object>;
            return accounts;
        }
        public void DeleteInternetExplorerCookiesAndData()
        {
            try
            {
                var p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "RunDll32.exe";
                p.StartInfo.Arguments = "InetCpl.cpl,ClearMyTracksByProcess 2";
                p.Start();
                p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                ReportManager.Report.Info("Failed to delete Internet Explorer cookies and data");
                ReportManager.Report.Error(ex);
            }
        }

        public void CloseLastTab()
        {
            Wait.IfNot(() => Tabs.Count > 1, 5.Seconds());
            if (Tabs.Count <= 1) return;

            ReportManager.Report.Info("Closing last tab...................");
            _driver.SwitchTo().Window(Tabs.Last());
            _driver.Close();
            _driver.SwitchTo().Window(Tabs.LastOrDefault());
            ReportManager.Report.Info("Succeeded.");
        }

        public void CloseFirstTab()
        {
            Wait.IfNot(() => Tabs.Count > 1, 10.Seconds());
            if (Tabs.Count <= 1) return;
            ReportManager.Report.Info("Closing first tab...................");
            _driver.SwitchTo().Window(Tabs.First());
            _driver.Close();
            _driver.SwitchTo().Window(Tabs.FirstOrDefault());
            ReportManager.Report.Info("Succeeded.");
        }

        public void WaitAndSwitchToLastTab(string description, int count = 1)
        {
            try
            {
                var endTime = DateTime.Now.AddSeconds(10);
                while (endTime > DateTime.Now)
                {

                    if (_driver.WindowHandles.Count > count)
                    {
                        break;
                    }
                }
                _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            }
            catch (WebDriverTimeoutException)
            {
                ReportManager.Report.Error("Failed to find elements '{description}' ");
                throw;
            }
        }

        public string GetCurrentWindowHandle()
        {
            return _driver.CurrentWindowHandle;
        }

        public ReadOnlyCollection<string> GetWindowHandles()
        {
            return _driver.WindowHandles;
        }

        protected List<string> Tabs => GetWindowHandles().ToList();

        public void SwitchToDefault()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public void SwitchToTab(string windowHandler)
        {
            _driver.SwitchTo().Window(windowHandler);
        }

        public void CloseTab()
        {
            _driver.Close();
        }

        public string GetUserPassword()
        {
            return ((IJavaScriptExecutor)_driver).ExecuteScript("return userDetails.NewAccountPassword").ToString();
        }

        public IAlert GetAlert(int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.AlertIsPresent());

            return _driver.SwitchTo().Alert();
        }

        public string AcceptAlert()
        {
            var text = "";
            try
            {
                var alert = GetAlert();

                text = alert.Text;
                alert.Accept();
            }
            catch (WebDriverTimeoutException)
            {
                ReportManager.Report.Warning("Alert was not found!");
            }

            return text;
        }

        public string AcceptAlert(Alert alertOption)
        {
            string text = "";
            if (alertOption.Equals(Alert.OK))
                text = AcceptAlert();
            else
            {
                try
                {
                    var alert = GetAlert();
                    text = alert.Text;
                    alert.Dismiss();
                }
                catch (WebDriverTimeoutException)
                {
                    ReportManager.Report.Warning("Alert was not found!");
                }
            }

            return text;
        }
        public void RefreshPage()
        {

            _driver.Navigate().Refresh();
            ReportManager.Report.Info("Refreshing the page..............");
        }
        public void RefreshPage(BrowserWindow window)
        {
            window.DOMRoot.Activate();
            window.Browser.GetWebDriver().Navigate().Refresh();
        }
        private bool VerifyUriIsWellFormed(string url)
        {
            Uri uri;
            return Uri.TryCreate(url, UriKind.Absolute, out uri) && uri != null;
        }
        public void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }

        public string GetAllAttributes(By elementBy)
        {
            var element = _driver.FindElements(elementBy).FirstOrDefault();
            return (string)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].innerHTML;", element);
        }

        public void SetValueToAttribute(IWebElement element , string attName, string attValue)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",
                element, attName, attValue);
        }

        public void SetCaptchaToken(string token)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"document.getElementById('g-recaptcha-response').innerHTML='{token}';");
        }

        public void CallBackFunction()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("invisibleCaptchaResponse();");
        }

        public void PrintAllChildElements(WebElement rootElement)
        {
            var children = rootElement.FindElements(By.XPath(".//*"), "Element's children list");

            foreach (var child in children)
            {
                var tagName = ((IWebElement)child.BrowserElement).TagName;
                var id = child.GetAttribute("id");
                var className = child.GetAttribute("class");
                var title = child.GetAttribute("title");
                var name = child.GetAttribute("name");

                ReportManager.Report.Info($"Element tag name: {tagName}, id: {id}, class: {className}, title: {title}, name: {name}. ");
            }
        }

        public IReadOnlyCollection<WebElement> GetAllChildElements(WebElement rootElement)
        {
            return rootElement.FindElements(By.XPath(".//*"), "Element's children list");
        }
        public Size ResizeWindow(IWebDriver driver, int width, int height)
        {
            var currentSize = GetWindowSize(driver);
            var newWidth = currentSize.Width + width;
            var newHeight = currentSize.Height + height;
            ReportManager.Report.Info($"Resizing the window to width: {newHeight}, height: {newHeight}");
            var failMsg = "Failed to resize the window";
            try
            {
                new Retry(() => SetWindowSize(newWidth, newHeight), 5.Seconds(), 1.Seconds(), failMsg).While(() => currentSize.Height == GetWindowSize(driver).Height && currentSize.Width == GetWindowSize(driver).Width);
            }
            catch (TimeoutException)
            {
                ReportManager.Report.Warning(failMsg);
            }

            currentSize = GetWindowSize(driver);
            ReportManager.Report.Info($"Current size width: {currentSize.Width}, height: {currentSize.Height}");
            return currentSize;
        }

        private void SetWindowSize(int width, int height)
        {
            _driver.Manage().Window.Size = new Size(width, height);
        }

        public Size GetWindowSize(IWebDriver driver)
        {
            return driver.Manage().Window.Size;
        }

        public void ClearChromeCache()
        {
            try
            {
                var proc = new Process();
                proc.StartInfo.FileName = "ChromeClearCache.bat";
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
            }
        }

        public void Back()
        {
            _driver.Navigate().Back();
        }

        public OpenQA.Selenium.Cookie GetCookie(string cookieName)
        {
            var cookies = GetWebDriver().Manage().Cookies;
            new Retry(() =>
            {
                RefreshPage();
                cookies = GetWebDriver().Manage().Cookies;
            }, 1.Minutes(), $"Failed get {cookieName} cookie..").Until(() => cookies.AllCookies.Any(cookie => cookie.Name.Equals(cookieName)));
            return GetWebDriver().Manage().Cookies.AllCookies.FirstOrDefault(cookie => cookie.Name.Equals(cookieName));
        }
    }
}
