using Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LSAutomation.Pages.Facebook
{
    public class FbAccountPage : PageBase
    {
        public FbAccountPage(Browser browser) : base(browser)
        {

        }

        public void JoinToGroup(string category)
        {
            Browser.WaitForElement(By.ClassName("_1frb"), "search", 20).Text = category;
            Thread.Sleep(2000);
            Browser.FindElements(By.Id("facebar_typeahead_view_list"), "").LastOrDefault().Click();
            var navContainer = Browser.WaitForElement(By.XPath("//div[@data-testid='search_navigation_tabs']"), "", 20);
            navContainer.WaitForElement(By.TagName("ul"), "", 20).FindElements(By.TagName("li"), "").ElementAt(7).Click();
            //var totalGroups = Browser.FindElements(By.XPath("//div[@data-testid='browse-result-content']"), "").Count();
            var totalGroups = Browser.FindElements(By.XPath("//div[@data-testid='browse-result-content']"),"");

            foreach (var element in totalGroups)
            {
                element.ToWebElement().MoveToElement();
            }
        }
    }
}
