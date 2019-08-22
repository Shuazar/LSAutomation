using LSAutomation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Report;

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
                var user = UserFactory.GetUser();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.Browser.NavigateToUrl(Automation.ConfigurationInfo.Url);
                Automation.HomeDomain.Login(user);
            });

        }

    }
}
