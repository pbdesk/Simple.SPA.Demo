using PBDeskDemos.SimpleSPA.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PBDeskDemos.SimpleSPA.DAL
{
    public class CustomerDbMigrationConfiguration: DbMigrationsConfiguration<CustomerContext>
    {
        public CustomerDbMigrationConfiguration()
        {
            bool boolAutomaticMigrationDataLossAllowed = false;
            string strAutomaticMigrationDataLossAllowed = "false";
            if (ConfigurationManager.AppSettings["EF_AutomaticMigrationDataLossAllowed"] != null)
            {
                strAutomaticMigrationDataLossAllowed = ConfigurationManager.AppSettings["EF_AutomaticMigrationDataLossAllowed"].ToString();
            }
            bool.TryParse(strAutomaticMigrationDataLossAllowed, out boolAutomaticMigrationDataLossAllowed);

            bool boolAutomaticMigrationsEnabled = false;
            string strAutomaticMigrationsEnabled = "false";
            if (ConfigurationManager.AppSettings["EF_AutomaticMigrationsEnabled"] != null)
            {
                strAutomaticMigrationsEnabled = ConfigurationManager.AppSettings["EF_AutomaticMigrationDataLossAllowed"].ToString();
            }
            bool.TryParse(strAutomaticMigrationsEnabled, out boolAutomaticMigrationsEnabled);

            if (boolAutomaticMigrationDataLossAllowed)
            {
                this.AutomaticMigrationDataLossAllowed = true; //to be removed later on
            }
            else
            {
                this.AutomaticMigrationDataLossAllowed = false;
            }
            if (boolAutomaticMigrationsEnabled)
            {
                this.AutomaticMigrationsEnabled = true;
            }
            else
            {
                this.AutomaticMigrationsEnabled = false;
            }

        }

        protected override void Seed(CustomerContext context)
        {
            base.Seed(context);

            bool boolRunSeedData = false;
            string strRunSeedData = "false";
            if (ConfigurationManager.AppSettings["EF_RunSeedData"] != null)
            {
                strRunSeedData = ConfigurationManager.AppSettings["EF_RunSeedData"].ToString();
            }
            bool.TryParse(strRunSeedData, out boolRunSeedData);

            if (boolRunSeedData)
            {
                SeedCustomersData(context);
            }
        }

        private void  SeedCustomersData(CustomerContext context)
        {
            var c= new CultureInfo(1033);
            var r = new Random(0);
            List<Customer> builds = new List<Customer>();
            for(int i=0; i<=20; i++)
            {
                    Customer cust = new Customer()
                    {
                        
                        FirstName=c.DateTimeFormat.MonthNames[r.Next(0,11)],
                        LastName = c.DateTimeFormat.DayNames[r.Next(0,6)],
                        Age = r.Next(18,99),
                        IsActive = r.Next(0,1) == 0 ? false : true,
                        Email = string.Format("{0}{3}{2}@{1}.com",  c.DateTimeFormat.MonthNames[r.Next(0,11)],c.DateTimeFormat.DayNames[r.Next(0,6)], i * r.Next(1,200), i+1 ) ,
                        Gender =  r.Next(0,1) == 0 ? "M" : "F"
                            
                    };
                context.Customers.Add(cust);
                context.SaveChanges();

            }            
            
        }
    }
}
