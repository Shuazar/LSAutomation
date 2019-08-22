
using LSAutomation.Domains;
using LSAutomation.Models;
using Common;
using System.Collections.Generic;

namespace LSAutomation
{
    public class Automation
    {
        public ConfigurationInfo ConfigurationInfo { get;  }
        public Browser Browser { get;  }
        public HomeDomain HomeDomain { get;  }
        public List<ConfigurationInfo> ConfigurationList { get;}
        public Automation(List<ConfigurationInfo> configurationInfoList, Browser browser)
        {
            ConfigurationList = configurationInfoList;
            Browser = browser;
            HomeDomain = new HomeDomain(this);
        }



    }
}
