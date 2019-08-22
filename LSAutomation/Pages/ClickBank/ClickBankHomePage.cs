using Common;
using LSAutomation.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Pages.ClickBank
{
    public class ClickBankHomePage : HomePageBase
    {
        public ClickBankHomePage(Browser browser) : base(browser)
        {

        }

        public override void Login(User user)
        {
            Browser.WaitForElement(By.Id("nick"), "nick", 10).Text = user.Username;
            Browser.WaitForElement(By.Id("pass"), "Password", 10).Text = user.Password;
            Browser.WaitForElement(By.Id("login"), "login", 10).Click();
        }

        public override void OpenHomePage(string url)
        {
            Browser.NavigateToUrl(url);
        }
    }
}
