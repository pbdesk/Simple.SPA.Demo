using PBDeskDemos.SimpleSPA.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBDeskDemos.SimpleSPA.DAL
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("D02_CustomerConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CustomerContext, CustomerDbMigrationConfiguration>()
                );
        }

        public IDbSet<Customer> Customers { get; set; } 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            
        }
    }
}
