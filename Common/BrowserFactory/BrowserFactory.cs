using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Common.Exstentions;

namespace Common.BrowserFactory
{
    public class BrowserFactory
    {
        public static Browser GetBrowser()
        {

            var document = XDocument.Load("BrowserConfiguration.xml");
            var browserName = document.GetValueFromDocument("BrowserName");

            switch (browserName)
            {
                case "Chrome":
                    return new ChromeBrowser();
                default:
                    break;

            }
            return null;
        }
    }
}
