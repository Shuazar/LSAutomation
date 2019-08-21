using LSAutomation.Factories;
using LSAutomation.Report;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Processes
{
    [TestClass]
    public class FaceBookScenarios : TestBase
    {
        [TestMethod]
        public void Login()
        {
            ExcuteScenario(() =>
            {
                var user = UserFactory.GetUser();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.Browser.NavigateToUrl(Automation.ConfigurationInfo.Url);
                Automation.HomeDomain.Login(user);
            });

        }

    }
}
