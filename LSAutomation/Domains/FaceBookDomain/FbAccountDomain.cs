using LSAutomation.Pages.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Domains.FaceBookDomain
{
    public class FbAccountDomain : DomainBase 
    {
        public FbAccountDomain(Automation automation) : base (automation)
        {

           
        }

        public void JoinToGroup(string category)
        {
            var accountPage = new FbAccountPage(Automation.Browser);
            accountPage.JoinToGroup(category);
        }
    }
}
