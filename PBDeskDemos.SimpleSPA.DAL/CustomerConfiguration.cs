using PBDeskDemos.SimpleSPA.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;


namespace PBDeskDemos.SimpleSPA.DAL
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("D01_Customers");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
            Property(x => x.LastName).HasColumnName("LastName").IsOptional();
            Property(x => x.Age).HasColumnName("Age").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional();
            Property(x => x.Gender).HasColumnName("Gender").IsOptional().HasMaxLength(1);
            Property(x => x.IsActive).HasColumnName("IsActive").IsOptional();            
        }
        
    }
}
