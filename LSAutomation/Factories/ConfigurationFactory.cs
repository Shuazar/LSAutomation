using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LSAutomation.Extensions;
using LSAutomation.Models;

namespace LSAutomation.Factories
{
    class ConfigurationFactory
    {

        public static ConfigurationInfo GetConfiguration()
        {
            ConfigurationInfo config = new ConfigurationInfo();
            var document = XDocument.Load("Configuration.xml");
            config.Name = document.GetValueFromDocument("Name");
            config.Url = document.GetValueFromDocument("Url");
            config.Language = document.GetValueFromDocument("Language");
            config.Country = document.GetValueFromDocument("Country");
            config.ReportFolder = document.GetValueFromDocument("ReportFolder");
            return config;
        }
    }
}
