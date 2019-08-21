using LSAutomation.BrowsersFactory;
using LSAutomation.Domains;
using LSAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation
{
    public class Automation
    {
        public ConfigurationInfo ConfigurationInfo { get; set; }
        public Browser Browser { get; set; }
        public HomeDomain HomeDomain { get; set; }

        public Automation(ConfigurationInfo configurationInfo, Browser browser)
        {
            ConfigurationInfo = configurationInfo;
            Browser = browser;
            HomeDomain = new HomeDomain(this);
        }

    }
}
