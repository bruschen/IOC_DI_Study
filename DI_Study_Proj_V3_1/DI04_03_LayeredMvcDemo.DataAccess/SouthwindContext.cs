using DI04_03_LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI04_03_LayeredMvcDemo.DataAccess
{
    public class SouthwindContext : DbContext
    {
        public SouthwindContext() : base("SouthwindDB")
        {
            Database.SetInitializer<SouthwindContext>(new SouthwindDBInitializer());
        }
        public DbSet<Customer> Customers { get; set; }
    }

    public class SouthwindDBInitializer
    : CreateDatabaseIfNotExists<SouthwindContext>
    {
        public override void InitializeDatabase(SouthwindContext context)
        {
            base.InitializeDatabase(context);
            context.Customers.Add(new Customer
            {
                Id = 1,
                CompanyName = "MikeSoft",
                Contact = "Michael"
            });
            context.Customers.Add(new Customer
            {
                Id = 2,
                CompanyName = "OralCall",
                Contact = "Vivid"
            });
            context.Customers.Add(new Customer
            {
                Id = 3,
                CompanyName = "SimonTech",
                Contact = "Simon"
            });
            context.Customers.Add(new Customer
            {
                Id = 4,
                CompanyName = "IoSee",
                Contact = "Mark"
            });
            context.SaveChanges();
        }
    }
}
