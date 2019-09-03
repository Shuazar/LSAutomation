using DAL.Database;
using LSAutomation.Models.ClickBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClickBankRepository
    {
        Type providerService = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        public void SavePromoteList(List<Promote> promoteList)
        {
            using (var context = new ClickBankDB())
            {
                foreach (var promote in promoteList)
                {
                    context.PromoteTable.Add(promote);                   
                }
                context.SaveChanges();
            }

        }
    }
}
