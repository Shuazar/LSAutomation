using Common;
using DAL.Database;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LSAutomation.Pages.Facebook
{
    public class FbAccountPage : PageBase
    {
        public FbAccountPage(Browser browser) : base(browser)
        {

        }
        private void SearchGroup(string category)
        {
            Browser.WaitForElement(By.ClassName("_1frb"), "search", 20).Text = category;
            Thread.Sleep(2000);
            Browser.FindElements(By.Id("facebar_typeahead_view_list"), "").LastOrDefault().Click();
            var navContainer = Browser.WaitForElement(By.XPath("//div[@data-testid='search_navigation_tabs']"), "", 20);
            navContainer.WaitForElement(By.TagName("ul"), "", 20).FindElements(By.TagName("li"), "").ElementAt(7).Click();
        }
        private void JoinToGroups_(string category)
        {
            int down = 50000;

            while (!Browser.FindElements(By.Id("browse_end_of_results_footer"), "endOfResults").Any())
            {
                Browser.PageDown(down);
                down = down + 50000;
            }

            var totalGroups = Browser.FindElements(By.XPath("//div[@data-testid='browse-result-content']"), "");

            var groupList = new List<FaceBookGroups>();
            TestAutomationEssentials.Selenium.BrowserElement joinButton = null;
            foreach (var element in totalGroups)
            {
                element.ToWebElement().MoveToElement();
                var parent = element.GetParent("");
                parent = parent.GetParent("");
                var classT = parent.GetAttribute("class");
                parent = parent.GetParent("");
                var jsonF = parent.GetAttribute("data-gt");
                
                

                var groupName = element.WaitForElement(By.TagName("a"), "", 10).Text;


                if (element.FindElements(By.TagName("a"), "").Count() < 2)
                {
                    joinButton = element.WaitForElement(By.TagName("button"), "", 10);
                }
                else
                {
                    joinButton = element.FindElements(By.TagName("a"), "").ElementAt(1);
                }


                var statusGroup = joinButton.Text;
                FaceBookGroups group = new FaceBookGroups();
                group.GroupId = GetGroupId(jsonF);
                group.Category = category;
                group.Name = groupName;
                group.Status = statusGroup;
                groupList.Add(group);
            }
            var resultContainer = Browser.WaitForElement(By.Id("BrowseResultsContainer"), "", 10);

            Thread.Sleep(444);

        
    }
        private string GetGroupId(string jsonString)
        {
            var array = jsonString.Split(':');
            var id = array[8];
            var startIndex = id.IndexOf(',');
            id = id.Substring(0, startIndex);
            return id;
        }
        public void JoinToGroup(string category)
        {
            ActAndHandleStaleElementReferenceException(() => SearchGroup(category));
            ActAndHandleStaleElementReferenceException(() => JoinToGroups_(category));
        }
    }
}
