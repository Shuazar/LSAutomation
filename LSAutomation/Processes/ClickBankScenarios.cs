using LSAutomation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Report;
using System.Linq;
using LSAutomation.Enums;

namespace LSAutomation.Processes
{
    [TestClass]
    public class ClickBankScenarios : TestBase
    {
        [TestMethod]
        public void Login()
        {
            ExcuteScenario(() =>
            {
                var user = UserFactory.GetClickBankUsers();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.HomeDomain.OpenHomePage(ConfigurationInfo.FirstOrDefault(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)));
                Automation.HomeDomain.Login(user, ConfigurationInfo.FirstOrDefault(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)));
            });

        }

    }
}
