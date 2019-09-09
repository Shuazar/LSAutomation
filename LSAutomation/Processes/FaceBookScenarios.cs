using LSAutomation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Report;
using LSAutomation.Enums;
using DAL.Repositories;

namespace LSAutomation.Processes
{
    [TestClass]
    public class FaceBookScenarios : TestBase
    {
        [TestMethod]
        public void JoinToGroup()
        {
            ExcuteScenario(() =>
            {
                var repository = new LSAutomationRepository();
                var list = repository.GetPromoteList();
                var categ = list.Select(prom=>prom.Category).Distinct();
                var user = UserFactory.GetFacebookUsers();
                ReportManager.Report.Test.Info($"Use name {user.Username}");
                Automation.HomeDomain.OpenHomePage(ConfigurationInfo.Where(conf => conf.Name.Equals(ConfigurationEnums.FaceBook)).FirstOrDefault());
                Automation.HomeDomain.Login(user, ConfigurationInfo.Where(conf => conf.Name.Equals(ConfigurationEnums.FaceBook)).FirstOrDefault());

                foreach (var category in categ)
                {
                    Automation.FbAccountDomain.JoinToGroup(category);

                }
            });

        }

    }
}
