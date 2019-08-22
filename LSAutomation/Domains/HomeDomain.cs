using LSAutomation.Models;
using LSAutomation.Pages.Facebook;

namespace LSAutomation.Domains
{
    public class HomeDomain : DomainBase
    {
        public HomeDomain(Automation automation) : base(automation)
        {

        }
        public void Login(User user)
        {
            var homePage = new FaceBookHomePage(Automation.Browser);
            homePage.Login(user);
        }
    }
}
