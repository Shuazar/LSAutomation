using Common.Report;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestAutomationEssentials.Selenium;
using Browser = Common.Browser;
namespace LSAutomation.Pages
{
   public abstract class PageBase
   {
       protected Browser Browser { get; }
       protected BrowserWindow Window { get; }

       protected PageBase(Browser browser)
       {
           Browser = browser;
       }
        protected PageBase(Browser browser,BrowserWindow window)
        {
            Browser = browser;
            Window = window;
        }

        protected void ActAndHandleStaleElementReferenceException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e) when (EcxeptionsFilter(e))
            {
                ReportManager.Report.Info(string.Format("Stale element received ...."));
                Thread.Sleep(3000);
                action();
            }
        }
        protected T GetTypeAndHandleStaleElementReferenceException<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception e) when (EcxeptionsFilter(e))
            {
                ReportManager.Report.Info(string.Format("Stale element received ...."));
                Thread.Sleep(3000);
                return func();
            }
        }
        private static bool EcxeptionsFilter(Exception e)
        {
            return
                e is StaleElementReferenceException ||
                e is WebDriverException ||
                e is NullReferenceException ||
                e is InvalidOperationException ||
                e is ArgumentOutOfRangeException ||
                e is TimeoutException;
        }
    }

}

