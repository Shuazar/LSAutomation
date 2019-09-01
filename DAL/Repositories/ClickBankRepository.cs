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
        public List<Promote> GetPromoteList()
        {
            List<Promote> promoteList = new List<Promote>();

            using (var context = new ClickBankDB())
            {
                var promoteResult = (from p in context.PromoteTable
                                     select p).ToList();                
            }

            return promoteList;

        }
    }
}
