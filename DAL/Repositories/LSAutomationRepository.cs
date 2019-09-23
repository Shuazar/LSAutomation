using Common.Models;
using DAL.Database;
using LSAutomation.Models.ClickBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LSAutomationRepository
    {
       Type providerService = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        public void SavePromoteList(System.Collections.Generic.List<Promote> promoteList)
        {
            using (var context = new LSAutomationDB())
            {
                foreach (var promote in promoteList)
                {
                    context.PromoteTable.Add(promote);                   
                }
                context.SaveChanges();
            }

        }

        public List<Promote> GetPromoteList()
        {
            var promoteList = new List<Promote>();

            using (var context = new LSAutomationDB())
            {
                 promoteList = (from p in context.PromoteTable
                                   select p).ToList();
            }
            return promoteList;
        }

        public void SaveFbGroups(List<FaceBookGroups> facebookGroupsList)
        {
            using (var context = new LSAutomationDB())
            {
                foreach (var group in facebookGroupsList)
                {
                    context.FaceBookGroupsTable.Add(group);
                }
                context.SaveChanges();
            }

        }

        public List<FaceBookGroups> GetFacebookGroups()
        {
            var fbGroupsList = new List<FaceBookGroups>();

            using (var context = new LSAutomationDB())
            {
                fbGroupsList = (from p in context.FaceBookGroupsTable
                               select p).ToList();
            }
            return fbGroupsList;
        }

        public List<Proxy> GetProxies()
        {          
            var proxies = new List<Proxy>();

            using (var context = new LSAutomationDB())
            {
                        
                proxies = (from p in context.ProxiesTable
                           select p).ToList();
                
            }
            return proxies;
        }

        public void SaveProxies(List<Proxy> proxies)
        {
            using (var context = new LSAutomationDB())
            {
                foreach (var proxy in proxies)
                {
                    context.ProxiesTable.Add(proxy);
                }
                context.SaveChanges();
            }

        }
    }


}
