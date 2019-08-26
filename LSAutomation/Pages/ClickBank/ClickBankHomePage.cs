using LSAutomation.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CaptchaSolver.Api;
using Common.CaptchaSolver.Helper;
using TestAutomationEssentials.Selenium;
using Browser = Common.Browser;

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
            var siteKey = GetDataSiteKey();
            DebugHelper.VerboseMode = true;
            var captcha = new NoCaptchaProxyless
            {
                ClientKey = "0ed958d95bc3aa1d68e3c84317516d0b",
                WebsiteUrl = new Uri("https://accounts.clickbank.com/login.htm"),
                WebsiteKey = siteKey,
            };
            if (!captcha.CreateTask())
            {
                DebugHelper.Out("API v2 send failed. " + captcha.ErrorMessage, DebugHelper.Type.Error);
            }
            else if (!captcha.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
            {
                DebugHelper.Out("Result: " + captcha.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
                var hashcode = captcha.GetTaskSolution().GRecaptchaResponse;
            }
            
        }

        public override void OpenHomePage(string url)
        {
            Browser.NavigateToUrl(url);
        }
        public override string GetDataSiteKey()
        {
            //Frame frame = Browser.GetFrame(By.XPath("//iframe[@title='recaptcha challenge']"), "");
            return Browser.WaitForElement(By.Id("login"), "loginbutton label", 10).GetAttribute("data-sitekey");
        }
    }
}
