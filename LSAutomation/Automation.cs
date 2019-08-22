
using LSAutomation.Domains;
using LSAutomation.Models;
using Common;

namespace LSAutomation
{
    public class Automation
    {
        public ConfigurationInfo ConfigurationInfo { get;  }
        public Browser Browser { get;  }
        public HomeDomain HomeDomain { get;  }

        public Automation(ConfigurationInfo configurationInfo, Browser browser)
        {
            ConfigurationInfo = configurationInfo;
            Browser = browser;
            HomeDomain = new HomeDomain(this);
        }

    }
}
