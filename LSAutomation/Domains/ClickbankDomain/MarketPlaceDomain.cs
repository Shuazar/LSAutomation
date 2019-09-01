using LSAutomation.Enums;
using LSAutomation.Pages.ClickBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSAutomation.Models.ClickBank;

namespace LSAutomation.Domains.ClickbankDomain
{
    public class MarketPlaceDomain : DomainBase
    {

        public MarketPlaceDomain(Automation automation) : base (automation)
        {

        }

        public void SortResultBy(SortResultBy resultBy)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);
            marketPlacePage.ShowResult(resultBy);

        }

        public List<Promote> GetPromotions()
        {               
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);
            return marketPlacePage.GetPromotions();
        }

        
    }
}
