using LSAutomation.Models.ClickBank;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class ClickBankDB : DbContext
    {
        public ClickBankDB()
             : base("name=ClickBankDb")
        {

        }
        public DbSet<Promote> PromoteTable { get; set; }
        public DbSet<FaceBookGroups> FaceBookGroupsTable { get; set; }
    }
}
