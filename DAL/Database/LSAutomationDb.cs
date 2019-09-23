﻿using Common.Models;
using LSAutomation.Models.ClickBank;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class LSAutomationDB : DbContext
    {
        public LSAutomationDB()
             : base("name=LSAutomationDB")
        {

        }
        public DbSet<Promote> PromoteTable { get; set; }
        public DbSet<FaceBookGroups> FaceBookGroupsTable { get; set; }
        public DbSet<Proxy> ProxiesTable { get; set; }
    }
}
