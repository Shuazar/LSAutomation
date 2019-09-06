
using LSAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using OpenQA.Selenium;


namespace LSAutomation.Pages.Facebook
{
    public class FaceBookHomePage : HomePageBase
    {
        public FaceBookHomePage(Browser browser) : base(browser)
        {
        }

        public override void Login(User user)
        {
            Browser.WaitForElement(By.Id("email"), "email", 10).Text = user.Username;
            Browser.WaitForElement(By.Id("pass"), "Password", 10).Text = user.Password;
            Browser.WaitForElement(By.Id("loginbutton"), "loginbutton label",10).WaitForElement(By.TagName("input"),"button login",5 ).Click();
           
        }

        public override void OpenHomePage(string url)
        {
            Browser.NavigateToUrl(url);
        }
        
        public override string GetDataSiteKey()
        {
            return "";
        }
    }
}
