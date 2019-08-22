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
                Automation.HomeDomain.OpenHomePage(ConfigurationInfo.Where(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)).FirstOrDefault());
                Automation.HomeDomain.Login(user, ConfigurationInfo.Where(conf => conf.Name.Equals(ConfigurationEnums.ClickBank)).FirstOrDefault());
            });

        }

    }
}
