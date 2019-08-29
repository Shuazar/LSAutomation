using LSAutomation.Enums;
using LSAutomation.Pages.ClickBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Domains.ClickbankDomain
{
    public class MarketPlaceDomain : DomainBase
    {

        public MarketPlaceDomain(Automation automation) : base (automation)
        {

        }
       public void  ShowResultsByPopularity(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if (clickBankEnums.Equals(ClickBankEnums.Popularity))
            {
                marketPlacePage.ShowResultsByPopularity();
            }
        }

        public void ShowResultsByAvgDollarSale(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if(clickBankEnums.Equals(ClickBankEnums.AvgDollarSale))
            {
                marketPlacePage.ShowResultsByAvgDollarSale();
            }
        }

        public void ShowResultsByInitialDollarSale(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if(clickBankEnums.Equals(ClickBankEnums.InitialDollarSale))
            {
                marketPlacePage.ShowResultsByInitialDollarSale();
            }
        }

        public void ShowResultsByAvgPercentSale(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if(clickBankEnums.Equals(ClickBankEnums.AvgPercentSale))
            {
                marketPlacePage.ShowResultsByAvgPercentSale();
            }
        }

        public void ShowResultsByAvgRebillTotal(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if(marketPlacePage.Equals(ClickBankEnums.AvgRebillTotal))
            {
                marketPlacePage.ShowResultsByAvgRebillTotal();
            }
        }

        public void ShowResultsByAvgPercentRebill(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if(marketPlacePage.Equals(ClickBankEnums.AvgPercentRebill))
            {
                marketPlacePage.ShowResultsByAvgPercentRebill();
            }
        }

        public void ShowResultsByGravity(ClickBankEnums clickBankEnums)
        {
            MarketPlacePage marketPlacePage = new MarketPlacePage(Automation.Browser);

            if(marketPlacePage.Equals(ClickBankEnums.Gravity))
            {
                marketPlacePage.ShowResultsByGravity();
            }
        }




    }
}
