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

        //public void  ShowResultsByPopularity(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if (clickBankEnums.Equals(SortResultBy.Popularity))
        //    {
        //        marketPlacePage.ShowResultsByPopularity();
        //    }
        //}

        //public void ShowResultsByAvgDollarSale(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if(clickBankEnums.Equals(SortResultBy.AvgDollarSale))
        //    {
        //        marketPlacePage.ShowResultsByAvgDollarSale();
        //    }
        //}

        //public void ShowResultsByInitialDollarSale(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if(clickBankEnums.Equals(SortResultBy.InitialDollarSale))
        //    {
        //        marketPlacePage.ShowResultsByInitialDollarSale();
        //    }
        //}

        //public void ShowResultsByAvgPercentSale(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if(clickBankEnums.Equals(SortResultBy.AvgPercentSale))
        //    {
        //        marketPlacePage.ShowResultsByAvgPercentSale();
        //    }
        //}

        //public void ShowResultsByAvgRebillTotal(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if(marketPlacePage.Equals(SortResultBy.AvgRebillTotal))
        //    {
        //        marketPlacePage.ShowResultsByAvgRebillTotal();
        //    }
        //}

        //public void ShowResultsByAvgPercentRebill(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if(marketPlacePage.Equals(SortResultBy.AvgPercentRebill))
        //    {
        //        marketPlacePage.ShowResultsByAvgPercentRebill();
        //    }
        //}

        //public void ShowResultsByGravity(SortResultBy clickBankEnums)
        //{
        //    MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

        //    if(marketPlacePage.Equals(SortResultBy.Gravity))
        //    {
        //        marketPlacePage.ShowResultsByGravity();
        //    }
        //}




    }
}
