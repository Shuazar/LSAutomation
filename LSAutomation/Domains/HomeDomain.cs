using System;
using LSAutomation.Models;
using LSAutomation.Pages;
using LSAutomation.Pages.Facebook;

namespace LSAutomation.Domains
{
    public class HomeDomain : DomainBase
    {
        HomePageBase _homePage { get; set; }

        public HomeDomain(Automation automation) : base(automation)
        {
           
        }
        public void Login(User user, ConfigurationInfo configurationInfo)
        {

            _homePage = HomePageFactory.GetHomePage(configurationInfo,Automation.Browser);
            _homePage.Login(user);
        }

        public void OpenHomePage(ConfigurationInfo configurationInfo)
        {
            _homePage = HomePageFactory.GetHomePage(configurationInfo,Automation.Browser);
            _homePage.OpenHomePage(configurationInfo.Url);
        }


    }
}
