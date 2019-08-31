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
    }
}
