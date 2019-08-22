using LSAutomation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Report;
using LSAutomation.Enums;

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
                var user = UserFactory.GetFacebookUsers();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.HomeDomain.OpenHomePage(ConfigurationInfo.Where(conf => conf.Name.Equals(ConfigurationEnums.FaceBook)).FirstOrDefault());
                Automation.HomeDomain.Login(user, ConfigurationInfo.Where(conf => conf.Name.Equals(ConfigurationEnums.FaceBook)).FirstOrDefault());
            });

        }

    }
}
