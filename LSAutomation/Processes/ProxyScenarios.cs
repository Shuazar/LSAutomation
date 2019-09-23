using Common.Models;
using DAL.Database;
using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LSAutomation.Processes
{
    [TestClass]
    public class ProxyScenarios : TestBase
    {
        [TestMethod]
        public void GetProxies()
        {         
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.proxy-list.download/api/v0/get?l=en&t=https");
                // Set some reasonable limits on resources used by this request
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;
                // Set credentials to use for this request.
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var result = readStream.ReadToEnd();
                var str = getBetween(result, "LISTA");
                var lists = new JavaScriptSerializer().Deserialize<List<Proxy>>(str);
                LSAutomationRepository LSAutomationRep = new LSAutomationRepository();
                LSAutomationRep.SaveProxies(lists);
       }

        
        private string getBetween(string strSource, string strStart)
        {
            int Start, End;
            if (strSource.Contains(strStart))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length + 3;         
                return strSource.Substring(Start, (strSource.Length - 2) - Start);
            }
            else
            {
                return "";
            }
        }

    }
}
