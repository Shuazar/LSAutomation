using Common;
using LSAutomation.Enums;
using LSAutomation.Models;
using LSAutomation.Pages.ClickBank;
using LSAutomation.Pages.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Pages
{
    public static class HomePageFactory
    {
        public static HomePageBase GetHomePage(ConfigurationInfo configInfo,Browser browser)
        {
            switch (configInfo.Name)
            {
                case ConfigurationEnums.ClickBank:
                        return new ClickBankHomePage(browser);
                    break;
                case ConfigurationEnums.FaceBook:
                    return new FaceBookHomePage(browser);
                    break;
            }
            return null;
        }
    }
}
