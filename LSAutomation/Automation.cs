
using LSAutomation.Domains;
using LSAutomation.Models;
using Common;
using System.Collections.Generic;
using LSAutomation.Domains.ClickbankDomain;
using LSAutomation.Domains.FaceBookDomain;

namespace LSAutomation
{
    public class Automation
    {
        public ConfigurationInfo ConfigurationInfo { get; }
        public Browser Browser { get; }
        public HomeDomain HomeDomain { get; }
        public MainMenuDomain  MainMenuDomain {get;}
        public MarketPlaceDomain MarketPlaceDomain { get; }
        public FbAccountDomain FbAccountDomain { get; }
        public List<ConfigurationInfo> ConfigurationList { get;}
        public Automation(List<ConfigurationInfo> configurationInfoList, Browser browser)
        {
            ConfigurationList = configurationInfoList;
            Browser = browser;
            HomeDomain = new HomeDomain(this);
            MainMenuDomain = new MainMenuDomain(this);
            MarketPlaceDomain = new MarketPlaceDomain(this);
            FbAccountDomain = new FbAccountDomain(this);
        }



    }
}
