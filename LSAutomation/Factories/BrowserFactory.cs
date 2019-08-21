using LSAutomation.Browsers;
using LSAutomation.BrowsersFactory;
using LSAutomation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace LSAutomation.Factories
{
    class BrowserFactory
    {
        public static Browser GetBrowser()
        {

            var document = XDocument.Load("BrowserConfig.xml");
            var browserName = document.GetValueFromDocument("BrowserName");

            switch (browserName)
            {
                case "Chrome":
                    return new BrowsersFactory.ChromeBrowser();
                default:
                    break;

            }
            return null;
        }
    }
}
